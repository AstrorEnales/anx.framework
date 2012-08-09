#region Using Statements
using System;
using ANX.Framework.Graphics;
using SharpDX.Direct3D11;
using SharpDX.Direct3D;
using SharpDX.DXGI;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Windows.Metro
{
    internal class FormatConverter
    {

        public static int FormatSize(SurfaceFormat format)
        {
            switch (format)
            {
                case SurfaceFormat.Vector4:
                    return 16;
                //case SurfaceFormat.Vector3:
                //    return 12;
                case SurfaceFormat.Vector2:
                    return 8;
                case SurfaceFormat.Single:
                case SurfaceFormat.Color:
                    //case SurfaceFormat.RGBA1010102:
                    //case SurfaceFormat.RG32:
                    return 4;
                //case SurfaceFormat.BGR565:
                //case SurfaceFormat.BGRA5551:
                //    return 2;
                case SurfaceFormat.Dxt1:
                case SurfaceFormat.Dxt3:
                case SurfaceFormat.Dxt5:
                case SurfaceFormat.Alpha8:
                    return 1;
                default:
                    throw new ArgumentException("Invalid format");
            }
        }
        
        public static SharpDX.DXGI.Format Translate(SurfaceFormat surfaceFormat)
        {
            switch (surfaceFormat)
            {
                case SurfaceFormat.Color:
                    return SharpDX.DXGI.Format.R8G8B8A8_UNorm;
                case SurfaceFormat.Dxt3:
                    return SharpDX.DXGI.Format.BC2_UNorm;
                case SurfaceFormat.Dxt5:
                    return SharpDX.DXGI.Format.BC3_UNorm;
            }

            throw new Exception("can't translate SurfaceFormat: " + surfaceFormat.ToString());
        }

        public static Format Translate(ANX.Framework.Graphics.DepthFormat depthFormat)
        {
            switch (depthFormat)
            {
                case DepthFormat.Depth16:
                    return Format.D16_UNorm;
                case DepthFormat.Depth24:
                    //TODO: no DirectX10 24Bit depth format???                    
                case DepthFormat.Depth24Stencil8:
                    return Format.D24_UNorm_S8_UInt;
                case DepthFormat.None:
                    return Format.Unknown;
            }

            throw new Exception("can't translate DepthFormat: " + depthFormat.ToString());
        }

        public static SurfaceFormat Translate(SharpDX.DXGI.Format format)
        {
            switch (format)
            {
                case SharpDX.DXGI.Format.R8G8B8A8_UNorm:
                    return SurfaceFormat.Color;
                case SharpDX.DXGI.Format.BC2_UNorm:
                    return SurfaceFormat.Dxt3;
                case SharpDX.DXGI.Format.BC3_UNorm:
                    return SurfaceFormat.Dxt5;
            }

            throw new Exception("can't translate Format: " + format.ToString());
        }

        public static Filter Translate(TextureFilter filter)
        {
            switch (filter)
            {
                case TextureFilter.Anisotropic:
                    return Filter.Anisotropic;
                case TextureFilter.Linear:
                    return Filter.MinMagMipLinear;
                case TextureFilter.LinearMipPoint:
                    return Filter.MinMagMipPoint;
                case TextureFilter.MinLinearMagPointMipLinear:
                    return Filter.MinLinearMagPointMipLinear;
                case TextureFilter.MinLinearMagPointMipPoint:
                    return Filter.MinLinearMagMipPoint;
                case TextureFilter.MinPointMagLinearMipLinear:
                    return Filter.MinPointMagMipLinear;
                case TextureFilter.MinPointMagLinearMipPoint:
                    return Filter.MinPointMagLinearMipPoint;
                case TextureFilter.Point:
                    return Filter.MinMagMipPoint;
                case TextureFilter.PointMipLinear:
                    return Filter.MinMagPointMipLinear;
            }

            throw new NotImplementedException();
        }

        public static SharpDX.Direct3D11.TextureAddressMode Translate(ANX.Framework.Graphics.TextureAddressMode addressMode)
        {
            switch (addressMode)
            {
                case Graphics.TextureAddressMode.Clamp:
                    return SharpDX.Direct3D11.TextureAddressMode.Clamp;
                case Graphics.TextureAddressMode.Mirror:
                    return SharpDX.Direct3D11.TextureAddressMode.Mirror;
                case Graphics.TextureAddressMode.Wrap:
                    return SharpDX.Direct3D11.TextureAddressMode.Wrap;
            }

            return SharpDX.Direct3D11.TextureAddressMode.Clamp;
        }

        public static PrimitiveTopology Translate(PrimitiveType primitiveType)
        {
            switch (primitiveType)
            {
                case PrimitiveType.LineList:
                    return PrimitiveTopology.LineList;
                case PrimitiveType.LineStrip:
                    return PrimitiveTopology.LineStrip;
                case PrimitiveType.TriangleList:
                    return PrimitiveTopology.TriangleList;
                case PrimitiveType.TriangleStrip:
                    return PrimitiveTopology.TriangleStrip;
                default:
                    throw new InvalidOperationException("unknown PrimitiveType: " + primitiveType.ToString());
            }
        }

        public static SharpDX.DXGI.Format Translate(IndexElementSize indexElementSize)
        {
            switch (indexElementSize)
            {
                case IndexElementSize.SixteenBits:
                    return Format.R16_UInt;
                case IndexElementSize.ThirtyTwoBits:
                    return Format.R32_UInt;
                default:
                    throw new InvalidOperationException("unknown IndexElementSize: " + indexElementSize.ToString());
            }
        }

        public static string Translate(VertexElementUsage usage)
        {
            //TODO: map the other Usages
            if (usage == VertexElementUsage.TextureCoordinate)
            {
                return "TEXCOORD";
            }
            else
            {
                return usage.ToString().ToUpperInvariant();
            }
        }

        public static BlendOperation Translate(BlendFunction blendFunction)
        {
            switch (blendFunction)
            {
                case BlendFunction.Add:
                    return BlendOperation.Add;
                case BlendFunction.Max:
                    return BlendOperation.Maximum;
                case BlendFunction.Min:
                    return BlendOperation.Minimum;
                case BlendFunction.ReverseSubtract:
                    return BlendOperation.ReverseSubtract;
                case BlendFunction.Subtract:
                    return BlendOperation.Subtract;
            }

            throw new NotImplementedException();
        }

        public static BlendOption Translate(Blend blend)
        {
            switch (blend)
            {
                case Blend.BlendFactor:
                    return BlendOption.BlendFactor;
                case Blend.DestinationAlpha:
                    return BlendOption.DestinationAlpha;
                case Blend.DestinationColor:
                    return BlendOption.DestinationColor;
                case Blend.InverseBlendFactor:
                    return BlendOption.InverseBlendFactor;
                case Blend.InverseDestinationAlpha:
                    return BlendOption.InverseDestinationAlpha;
                case Blend.InverseDestinationColor:
                    return BlendOption.InverseDestinationColor;
                case Blend.InverseSourceAlpha:
                    return BlendOption.InverseSourceAlpha;
                case Blend.InverseSourceColor:
                    return BlendOption.InverseSourceColor;
                case Blend.One:
                    return BlendOption.One;
                case Blend.SourceAlpha:
                    return BlendOption.SourceAlpha;
                case Blend.SourceAlphaSaturation:
                    return BlendOption.SourceAlphaSaturate;
                case Blend.SourceColor:
                    return BlendOption.SourceColor;
                case Blend.Zero:
                    return BlendOption.Zero;
            }

            throw new NotImplementedException();
        }

        public static ColorWriteMaskFlags Translate(ColorWriteChannels colorWriteChannels)
        {
            ColorWriteMaskFlags mask = 0;

            if ((colorWriteChannels & ColorWriteChannels.All) == ColorWriteChannels.All)
            {
                mask |= ColorWriteMaskFlags.All;
            }

            if ((colorWriteChannels & ColorWriteChannels.Alpha) == ColorWriteChannels.Alpha)
            {
                mask |= ColorWriteMaskFlags.Alpha;
            }

            if ((colorWriteChannels & ColorWriteChannels.Blue) == ColorWriteChannels.Blue)
            {
                mask |= ColorWriteMaskFlags.Blue;
            }

            if ((colorWriteChannels & ColorWriteChannels.Green) == ColorWriteChannels.Green)
            {
                mask |= ColorWriteMaskFlags.Green;
            }

            if ((colorWriteChannels & ColorWriteChannels.Red) == ColorWriteChannels.Red)
            {
                mask |= ColorWriteMaskFlags.Red;
            }

            return mask;
        }

        public static SharpDX.Direct3D11.StencilOperation Translate(ANX.Framework.Graphics.StencilOperation stencilOperation)
        {
            switch (stencilOperation)
            {
                case Graphics.StencilOperation.Decrement:
                    return SharpDX.Direct3D11.StencilOperation.Decrement;
                case Graphics.StencilOperation.DecrementSaturation:
                    return SharpDX.Direct3D11.StencilOperation.DecrementAndClamp;
                case Graphics.StencilOperation.Increment:
                    return SharpDX.Direct3D11.StencilOperation.Increment;
                case Graphics.StencilOperation.IncrementSaturation:
                    return SharpDX.Direct3D11.StencilOperation.IncrementAndClamp;
                case Graphics.StencilOperation.Invert:
                    return SharpDX.Direct3D11.StencilOperation.Invert;
                case Graphics.StencilOperation.Keep:
                    return SharpDX.Direct3D11.StencilOperation.Keep;
                case Graphics.StencilOperation.Replace:
                    return SharpDX.Direct3D11.StencilOperation.Replace;
                case Graphics.StencilOperation.Zero:
                    return SharpDX.Direct3D11.StencilOperation.Zero;
            }

            throw new NotImplementedException("unknown StencilOperation");
        }

        public static Comparison Translate(ANX.Framework.Graphics.CompareFunction compareFunction)
        {
            switch (compareFunction)
            {
                case ANX.Framework.Graphics.CompareFunction.Always:
                    return Comparison.Always;
                case ANX.Framework.Graphics.CompareFunction.Equal:
                    return Comparison.Equal;
                case ANX.Framework.Graphics.CompareFunction.Greater:
                    return Comparison.Greater;
                case ANX.Framework.Graphics.CompareFunction.GreaterEqual:
                    return Comparison.GreaterEqual;
                case ANX.Framework.Graphics.CompareFunction.Less:
                    return Comparison.Less;
                case ANX.Framework.Graphics.CompareFunction.LessEqual:
                    return Comparison.LessEqual;
                case ANX.Framework.Graphics.CompareFunction.Never:
                    return Comparison.Never;
                case ANX.Framework.Graphics.CompareFunction.NotEqual:
                    return Comparison.NotEqual;
            }

            throw new NotImplementedException("unknown CompareFunction");
        }

        public static SharpDX.Direct3D11.CullMode Translate(ANX.Framework.Graphics.CullMode cullMode)
        {
            if (cullMode == Graphics.CullMode.CullClockwiseFace)
            {
                return SharpDX.Direct3D11.CullMode.Front;
            }
            else if (cullMode == Graphics.CullMode.CullCounterClockwiseFace)
            {
                return SharpDX.Direct3D11.CullMode.Back;
            }
            else
            {
                return SharpDX.Direct3D11.CullMode.None;
            }
        }

        public static SharpDX.Direct3D11.FillMode Translate(ANX.Framework.Graphics.FillMode fillMode)
        {
            if (fillMode == Graphics.FillMode.WireFrame)
            {
                return SharpDX.Direct3D11.FillMode.Wireframe;
            }
            else
            {
                return SharpDX.Direct3D11.FillMode.Solid;
            }
        }

    }
}
