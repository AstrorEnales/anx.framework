﻿using System;
using ANX.Framework;
using ANX.Framework.Graphics;
using ANX.Framework.NonXNA;
using Sce.PlayStation.Core.Graphics;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.RenderSystem.PsVita
{
	public class PsVitaGraphicsDevice : INativeGraphicsDevice
	{
		#region Private
		internal static PsVitaGraphicsDevice Current
		{
			get;
			private set;
		}

		private uint? lastClearColor;

		internal GraphicsContext NativeContext
		{
			get;
			private set;
		}
		#endregion

		#region Public
	    public bool VSync
	    {
	        get { return true; }
	        set { }
	    }

	    public Rectangle ScissorRectangle
	    {
	        get
	        {
	            var rect = NativeContext.GetScissor();
	            return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
	        }
	        set { NativeContext.SetScissor(value.X, value.Y, value.Width, value.Height); }
	    }
	    #endregion

		#region Constructor
		public PsVitaGraphicsDevice(PresentationParameters presentationParameters)
		{
			Current = this;
			// TODO
			NativeContext = new GraphicsContext(presentationParameters.BackBufferWidth,
				presentationParameters.BackBufferHeight, PixelFormat.Rgba,
				PixelFormat.Depth24Stencil8, MultiSampleMode.None);
		}
		#endregion

		#region Clear
		public void Clear(ref Color color)
		{
			uint newClearColor = color.PackedValue;
			if (lastClearColor.HasValue == false ||
				lastClearColor != newClearColor)
			{
				lastClearColor = newClearColor;
				NativeContext.SetClearColor(color.R, color.G, color.B, color.A);
			}

			NativeContext.Clear(ClearMask.Color | ClearMask.Depth);
		}

		public void Clear(ClearOptions options, Vector4 color, float depth, int stencil)
		{
			NativeContext.SetClearColor(color.X, color.Y, color.Z, color.W);

			ClearMask mask = ClearMask.None;
			if ((options | ClearOptions.Target) == options)
			{
				mask |= ClearMask.Color;
			}
			if ((options | ClearOptions.Stencil) == options)
			{
				mask |= ClearMask.Stencil;
			}
			if ((options | ClearOptions.DepthBuffer) == options)
			{
				mask |= ClearMask.Depth;
			}

			NativeContext.SetClearDepth(depth);
			NativeContext.SetClearStencil(stencil);
			NativeContext.Clear(mask);
		}
		#endregion

		#region Present
		public void Present()
		{
			NativeContext.SwapBuffers();
		}
		#endregion

		#region DrawPrimitives (TODO: check)
		public void DrawPrimitives(PrimitiveType primitiveType, int vertexOffset,
			int primitiveCount)
		{
			int count;
			DrawMode mode = DatatypesMapping.PrimitiveTypeToBeginMode(primitiveType,
				primitiveCount, out count);
			NativeContext.DrawArrays(mode, vertexOffset, count);
		}
		#endregion

		#region INativeGraphicsDevice Member
		public void DrawIndexedPrimitives(PrimitiveType primitiveType,
			int baseVertex, int minVertexIndex, int numVertices, int startIndex,
			int primitiveCount, IndexBuffer indexBuffer)
		{
			throw new NotImplementedException();
		}

		public void DrawInstancedPrimitives(PrimitiveType primitiveType,
			int baseVertex, int minVertexIndex, int numVertices, int startIndex,
			int primitiveCount, int instanceCount, IndexBuffer indexBuffer)
		{
			throw new NotImplementedException();
		}

		public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType,
			T[] vertexData, int vertexOffset, int numVertices, Array indexData,
			int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration,
			IndexElementSize indexFormat) where T : struct, IVertexType
		{
			throw new NotImplementedException();
		}

		public void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData,
			int vertexOffset, int primitiveCount, VertexDeclaration vertexDeclaration)
			where T : struct, IVertexType
		{
			throw new NotImplementedException();
		}

#if XNAEXT
        public void SetConstantBuffer(int slot, ConstantBuffer constantBuffer)
        {
            throw new NotImplementedException();
        }
#endif

		public void SetVertexBuffers(VertexBufferBinding[] vertexBuffers)
		{
			throw new NotImplementedException();
		}

		public void SetIndexBuffer(IndexBuffer indexBuffer)
		{
			throw new NotImplementedException();
		}

		public void SetRenderTargets(params RenderTargetBinding[] renderTargets)
		{
			throw new NotImplementedException();
		}

		public void GetBackBufferData<T>(Rectangle? rect, T[] data, int startIndex,
			int elementCount) where T : struct
		{
			throw new NotImplementedException();
		}

		public void GetBackBufferData<T>(T[] data) where T : struct
		{
			throw new NotImplementedException();
		}

		public void GetBackBufferData<T>(T[] data, int startIndex, int elementCount)
			where T : struct
		{
			throw new NotImplementedException();
		}

		public void ResizeBuffers(PresentationParameters presentationParameters)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region SetViewport
		public void SetViewport(Viewport viewport)
		{
			NativeContext.SetViewport(viewport.X, viewport.Y, viewport.Width, viewport.Height);
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			NativeContext.Dispose();
			NativeContext = null;
		}
		#endregion
	}
}
