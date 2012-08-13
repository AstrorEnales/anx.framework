﻿using System;
using SharpDX;
using SharpDX.Direct3D;
using Windows.Foundation;
using Dx11 = SharpDX.Direct3D11;
using PresentationParameters = ANX.Framework.Graphics.PresentationParameters;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.RenderSystem.Windows.Metro
{
	public class NativeDxDevice : IDisposable
	{
		#region Private
		private PresentationParameters presentationParameters;
		private FeatureLevel featureLevel;
		private Dx11.RenderTargetView renderTargetView;
		private Dx11.DepthStencilView depthStencilView;
		private SwapChainMetro swapChain;
		private Dx11.Device1 nativeDevice;
		private Dx11.DeviceContext1 nativeContext;

		internal Dx11.Device1 NativeDevice
		{
			get
			{
				return nativeDevice;
			}
		}

		internal Dx11.DeviceContext1 NativeContext
		{
			get
			{
				return nativeContext;
			}
		}
		#endregion

		#region Public
		public Rect RenderTargetBounds
		{
			get;
			protected set;
		}
		#endregion

		#region Constructor
		public NativeDxDevice(PresentationParameters presentationParameters)
		{
			this.presentationParameters = presentationParameters;
			swapChain = new SwapChainMetro(this, presentationParameters);

			var creationFlags = Dx11.DeviceCreationFlags.VideoSupport | Dx11.DeviceCreationFlags.BgraSupport;
#if DEBUG
			creationFlags |= Dx11.DeviceCreationFlags.Debug;
#endif
			using (var defaultDevice = new Dx11.Device(DriverType.Hardware, creationFlags))
			{
				nativeDevice = defaultDevice.QueryInterface<Dx11.Device1>();
			}
			featureLevel = NativeDevice.FeatureLevel;

			nativeContext = NativeDevice.ImmediateContext.QueryInterface<Dx11.DeviceContext1>();
		}
		#endregion

		#region Resize
		public void Resize(PresentationParameters presentationParameters)
		{
			DisposeScreenBuffers();

			swapChain.ResizeOrCreate(presentationParameters);

			using (var backBuffer = swapChain.CreateTexture())
			{
				renderTargetView = new Dx11.RenderTargetView(NativeDevice, backBuffer);

				var backBufferDesc = backBuffer.Description;
				RenderTargetBounds = new Rect(0, 0, backBufferDesc.Width, backBufferDesc.Height);
			}

			using (var depthBuffer = new Dx11.Texture2D(NativeDevice, new Dx11.Texture2DDescription()
			{
				Format = FormatConverter.Translate(presentationParameters.DepthStencilFormat),
				ArraySize = 1,
				MipLevels = 1,
				Width = (int)RenderTargetBounds.Width,
				Height = (int)RenderTargetBounds.Height,
				SampleDescription = new SharpDX.DXGI.SampleDescription(1, 0),
				BindFlags = Dx11.BindFlags.DepthStencil,
			}))
			{
				depthStencilView = new Dx11.DepthStencilView(NativeDevice, depthBuffer, new Dx11.DepthStencilViewDescription()
				{
					Dimension = Dx11.DepthStencilViewDimension.Texture2D
				});
			}

			var viewport = new Dx11.Viewport((float)RenderTargetBounds.X, (float)RenderTargetBounds.Y,
					(float)RenderTargetBounds.Width, (float)RenderTargetBounds.Height, 0.0f, 1.0f);

			NativeContext.Rasterizer.SetViewports(viewport);

			NativeContext.OutputMerger.SetTargets(depthStencilView, renderTargetView);
		}
		#endregion

		#region ClearDepthAndStencil
		public void ClearDepthAndStencil(Dx11.DepthStencilClearFlags flags, float depth, byte stencil)
		{
			// TODO: find better solution to lazy init the swapChain from the coreWindow!!
			EnsureScreenBuffersAvailable();

			NativeContext.ClearDepthStencilView(depthStencilView, flags, depth, stencil);
		}
		#endregion
		
		#region Clear
		public void Clear(Color4 color)
		{
			// TODO: find better solution to lazy init the swapChain from the coreWindow!!
			EnsureScreenBuffersAvailable();

			NativeContext.ClearRenderTargetView(renderTargetView, color);
		}
		#endregion
		
		#region EnsureScreenBuffersAvailable
		private void EnsureScreenBuffersAvailable()
		{
			if (renderTargetView == null)
			{
				Resize(presentationParameters);
			}
		}
		#endregion

		#region Present
		public void Present(int interval)
		{
			swapChain.Present(interval);
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			DisposeScreenBuffers();

			SafeDispose(ref swapChain);
			SafeDispose(ref nativeDevice);
			SafeDispose(ref nativeContext);
		}

		private void DisposeScreenBuffers()
		{
			SafeDispose(ref renderTargetView);
			SafeDispose(ref depthStencilView);
		}

		private void SafeDispose<T>(ref T disposable)
			where T : class, IDisposable
		{
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
		}
		#endregion
	}
}