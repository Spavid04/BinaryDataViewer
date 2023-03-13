using System;
using System.Buffers.Binary;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Numerics;

namespace DataViewer
{
    public static class BitmapOperations
    {
        public enum DataPixelFormat
        {
            GRAYSCALE,
            RGB,
            BGR,
            RGBA,
            BGRA,
            ARGB,
            ABGR
        }

        public static DataPixelFormat StringToDataPixelFormat(string text)
        {
            switch (text)
            {
                case "Grayscale (using palette)":
                    return DataPixelFormat.GRAYSCALE;
                case "RGB":
                    return DataPixelFormat.RGB;
                case "BGR":
                    return DataPixelFormat.BGR;
                case "RGBA":
                    return DataPixelFormat.RGBA;
                case "BGRA":
                    return DataPixelFormat.BGRA;
                case "ARGB":
                    return DataPixelFormat.ARGB;
                case "ABGR":
                    return DataPixelFormat.ABGR;

                default:
                    throw new ArgumentOutOfRangeException(nameof(text), text, "Invalid data pixel format!");
            }
        }

        public static PixelFormat DataPixelFormatToPixelFormat(DataPixelFormat format)
        {
            switch (format)
            {
                case DataPixelFormat.GRAYSCALE:
                    return PixelFormat.Format8bppIndexed;
                case DataPixelFormat.RGB:
                case DataPixelFormat.BGR:
                    return PixelFormat.Format24bppRgb;
                case DataPixelFormat.RGBA:
                case DataPixelFormat.BGRA:
                case DataPixelFormat.ARGB:
                case DataPixelFormat.ABGR:
                    return PixelFormat.Format32bppArgb;

                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, "Invalid data pixel format!");
            }
        }

        public static int GetBytesPerPixel(PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.Format8bppIndexed:
                    return 1;
                case PixelFormat.Format24bppRgb:
                    return 3;
                case PixelFormat.Format32bppArgb:
                    return 4;

                default:
                    throw new ArgumentException("Invalid pixel format!");
            }
        }
        
        private static void EnsureBuffer(ref byte[] buffer, long size)
        {
            if (buffer == null || size > buffer.Length)
            {
                buffer = new byte[size];
            }
        }

        private static byte[] DataBuffer = null;
        public static void CopyDataAsPixels(Stream from, long offset, Bitmap to, int pixelsPerLine,
            int pixelScaling, DataPixelFormat dataPixelFormat)
        {
            int imageWidth = to.Width;
            int imageHeight = to.Height;
            var pixelFormat = to.PixelFormat;
            int bytesPerPixel = GetBytesPerPixel(pixelFormat);
            
            int usableScaledLines = imageHeight / pixelScaling;

            long maxPossibleDataPixels = ((long)pixelsPerLine * imageHeight) / (pixelScaling * pixelScaling);
            EnsureBuffer(ref DataBuffer, maxPossibleDataPixels * bytesPerPixel * pixelScaling * pixelScaling);

            int totalUsefulPixels = usableScaledLines * pixelsPerLine;
            int totalBytesToRead = totalUsefulPixels * bytesPerPixel;

            from.Seek(offset, SeekOrigin.Begin);
            int actualBytesRead = from.Read(DataBuffer, 0, totalBytesToRead);

            var bitmapData = to.LockBits(new Rectangle(0, 0, imageWidth, usableScaledLines * pixelScaling), ImageLockMode.WriteOnly,
                pixelFormat);

            // in most cases where we have to flip bytes around, the last pixel will very often be "wrong"
            switch (dataPixelFormat)
            {
                case DataPixelFormat.GRAYSCALE:
                    // nothing special to be done
                    break;
                case DataPixelFormat.RGB:
                    // flip BGR to RGB
                    FlipToRGB(DataBuffer, actualBytesRead);
                    break;
                case DataPixelFormat.BGR:
                    // nothing special to be done
                    break;
                case DataPixelFormat.RGBA:
                    FlipToRGBA(DataBuffer, actualBytesRead);
                    break;
                case DataPixelFormat.BGRA:
                    // nothing special to be done
                    break;
                case DataPixelFormat.ARGB:
                    FlipToARGB(DataBuffer, actualBytesRead);
                    break;
                case DataPixelFormat.ABGR:
                    FlipToABGR(DataBuffer, actualBytesRead);
                    break;
            }

            if (pixelScaling > 1)
            {
                ScaleData(DataBuffer, actualBytesRead, pixelsPerLine, usableScaledLines, pixelScaling, bytesPerPixel);
            }
            CopyPixels(bitmapData.Scan0, bitmapData.Stride, imageHeight, DataBuffer, actualBytesRead * pixelScaling * pixelScaling, pixelsPerLine * pixelScaling, bytesPerPixel);

            to.UnlockBits(bitmapData);
        }

        #region Pixel manipulators

        private static byte[] ScalingLineBuffer = null;
        private static unsafe void ScaleData(byte[] data, int dataSize, int dataPixelsPerLine, int lines, int scaling, int bytesPerPixel)
        {
            if (scaling <= 1)
            {
                return;
            }

            int bytesPerUnscaledLine = dataPixelsPerLine * bytesPerPixel;
            int bytesPerScaledLine = bytesPerUnscaledLine * scaling;

            EnsureBuffer(ref ScalingLineBuffer, bytesPerScaledLine);

            fixed (byte* p1 = &data[0])
            fixed (byte* p2 = &ScalingLineBuffer[0])
            {
                IntPtr dataPtr = (IntPtr)p1;

                IntPtr srcPtr = dataPtr + bytesPerUnscaledLine * (lines - 1);
                IntPtr destPtr = dataPtr + bytesPerScaledLine * (lines * scaling - 1);

                for (int line = 0; line < lines; line++)
                {
                    IntPtr bufferPtr;

                    IntPtr offsetSrcPtr = srcPtr;
                    bufferPtr = (IntPtr)p2;
                    for (int i = 0; i < dataPixelsPerLine; i++)
                    {
                        for (int j = 0; j < scaling; j++)
                        {
                            Utils.Memcpy(bufferPtr, offsetSrcPtr, bytesPerPixel);
                            bufferPtr += bytesPerPixel;
                        }
                        offsetSrcPtr += bytesPerPixel;
                    }

                    bufferPtr = (IntPtr)p2;
                    for (int j = 0; j < scaling; j++)
                    {
                        Utils.Memcpy(destPtr, bufferPtr, bytesPerScaledLine);
                        destPtr -= bytesPerScaledLine;
                    }

                    srcPtr -= bytesPerUnscaledLine;
                }
            }
        }

        private static unsafe void CopyPixels(IntPtr bitmapBits, int stride, int imageHeight, byte[] newData,
            int actualDataBytes, int dataPixelsPerLine, int bytesPerPixel)
        {
            int relevantBytesPerRow = dataPixelsPerLine * bytesPerPixel;
            int toZeroEndOfRow = stride - relevantBytesPerRow;

            int fullLines = actualDataBytes / relevantBytesPerRow;
            int lastLineBytes = actualDataBytes - fullLines * relevantBytesPerRow;
            int emptyLines = imageHeight - fullLines - (lastLineBytes > 0 ? 1 : 0);

            IntPtr dest = bitmapBits;
            fixed (byte* pinned = &newData[0])
            {
                IntPtr src = (IntPtr)pinned;

                for (int i = 0; i < fullLines; i++)
                {
                    Utils.Memcpy(dest, src, relevantBytesPerRow);
                    dest += relevantBytesPerRow;
                    src += relevantBytesPerRow;

                    Utils.Memset(dest, 0, toZeroEndOfRow);
                    dest += toZeroEndOfRow;
                }

                if (lastLineBytes > 0)
                {
                    Utils.Memcpy(dest, src, lastLineBytes);
                    dest += lastLineBytes;
                    src += lastLineBytes;

                    Utils.Memset(dest, 0, stride - lastLineBytes);
                    dest += stride - lastLineBytes;
                }

                Utils.Memset(dest, 0, emptyLines * stride);
            }
        }

        #region Byte order flippers

        private static unsafe void FlipToRGB(byte[] data, int count)
        {
            count = (count / 3) * 3;

            fixed (byte* pinned = &data[0])
            {
                byte temp;
                for (int i = 0; i < count; i += 3)
                {
                    temp = pinned[i];
                    pinned[i] = pinned[i + 2];
                    pinned[i + 2] = temp;
                }
            }
        }

        private static unsafe void FlipToARGB(byte[] data, int count)
        {
            count = count / 4;

            fixed (byte* pinned = &data[0])
            {
                UInt32* asUint = (UInt32*)pinned;
                for (int i = 0; i < count; i += 4)
                {
                    asUint[i] = BinaryPrimitives.ReverseEndianness(asUint[i]);
                }
            }
        }

        private static unsafe void FlipToRGBA(byte[] data, int count)
        {
            count = (count / 4) * 4;

            fixed (byte* pinned = &data[0])
            {
                byte temp;
                for (int i = 0; i < count; i += 4)
                {
                    temp = pinned[i];
                    pinned[i] = pinned[i + 2];
                    pinned[i + 2] = temp;
                }
            }
        }

        private static unsafe void FlipToABGR(byte[] data, int count)
        {
            count = count / 4;

            fixed (byte* pinned = &data[0])
            {
                UInt32* asUint = (UInt32*)pinned;
                for (int i = 0; i < count; i += 4)
                {
                    asUint[i] = BitOperations.RotateRight(asUint[i], 8);
                }
            }
        }

        #endregion

        #endregion
    }
}
