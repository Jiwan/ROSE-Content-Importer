using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;

namespace Arua_content_importer.Common.GraphicsHandler
{
	internal class GraphicsDeviceService : IGraphicsDeviceService
	{
		private static GraphicsDeviceService singletonInstance;

		private static int referenceCount;

		private GraphicsDevice graphicsDevice;

		private PresentationParameters parameters;

		public event EventHandler DeviceCreated;

		public event EventHandler DeviceDisposing;

		public event EventHandler DeviceReset;

		public event EventHandler DeviceResetting;

		public GraphicsDevice GraphicsDevice
		{
			get
			{
				return this.graphicsDevice;
			}
		}

		private GraphicsDeviceService(IntPtr windowHandle, int width, int height)
		{
			this.parameters = new PresentationParameters();
			this.parameters.BackBufferWidth = Math.Max(width, 1);
			this.parameters.BackBufferHeight = Math.Max(height, 1);
			this.parameters.BackBufferFormat = SurfaceFormat.Color;
			this.parameters.EnableAutoDepthStencil = true;
			this.parameters.AutoDepthStencilFormat = DepthFormat.Depth24;
			this.graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, DeviceType.Hardware, windowHandle, this.parameters);
		}

		public static GraphicsDeviceService AddRef(IntPtr windowHandle, int width, int height)
		{
			if (Interlocked.Increment(ref GraphicsDeviceService.referenceCount) == 1)
			{
				GraphicsDeviceService.singletonInstance = new GraphicsDeviceService(windowHandle, width, height);
			}
			return GraphicsDeviceService.singletonInstance;
		}

		public void Release(bool disposing)
		{
			if (Interlocked.Decrement(ref GraphicsDeviceService.referenceCount) == 0)
			{
				if (disposing)
				{
					if (this.DeviceDisposing != null)
					{
						this.DeviceDisposing(this, EventArgs.Empty);
					}
					this.graphicsDevice.Dispose();
				}
				this.graphicsDevice = null;
			}
		}

		public void ResetDevice(int width, int height)
		{
			if (this.DeviceResetting != null)
			{
				this.DeviceResetting(this, EventArgs.Empty);
			}
			this.parameters.BackBufferWidth = Math.Max(this.parameters.BackBufferWidth, width);
			this.parameters.BackBufferHeight = Math.Max(this.parameters.BackBufferHeight, height);
			this.graphicsDevice.Reset(this.parameters);
			if (this.DeviceReset != null)
			{
				this.DeviceReset(this, EventArgs.Empty);
			}
		}
	}
}
