using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Arua_content_importer.Common.GraphicsHandler
{
	public class textureControl : GraphicsDeviceControl
	{
		private bool ScreenShot;

		private string ScreeShotPath;

		private SpriteBatch spriteBatch;

		private List<Sprite> listSprite
		{
			get;
			set;
		}

		private List<Aera> listAera
		{
			get;
			set;
		}

		private List<Text> listText
		{
			get;
			set;
		}

		protected override void Initialize()
		{
			base.GraphicsDevice.PresentationParameters.AutoDepthStencilFormat = DepthFormat.Depth24;
			base.GraphicsDevice.PresentationParameters.BackBufferCount = 1;
			base.GraphicsDevice.PresentationParameters.BackBufferFormat = SurfaceFormat.Color;
			base.GraphicsDevice.PresentationParameters.EnableAutoDepthStencil = true;
			base.GraphicsDevice.PresentationParameters.FullScreenRefreshRateInHz = 0;
			base.GraphicsDevice.PresentationParameters.IsFullScreen = false;
			base.GraphicsDevice.PresentationParameters.MultiSampleQuality = 0;
			base.GraphicsDevice.PresentationParameters.MultiSampleType = MultiSampleType.NonMaskable;
			base.GraphicsDevice.PresentationParameters.PresentationInterval = PresentInterval.One;
			base.GraphicsDevice.PresentationParameters.PresentOptions = PresentOptions.None;
			base.GraphicsDevice.PresentationParameters.RenderTargetUsage = RenderTargetUsage.DiscardContents;
			base.GraphicsDevice.PresentationParameters.SwapEffect = SwapEffect.Discard;
			this.spriteBatch = new SpriteBatch(base.GraphicsDevice);
			this.listSprite = new List<Sprite>();
			this.listAera = new List<Aera>();
			this.listText = new List<Text>();
			Application.Idle += delegate
			{
				base.Invalidate();
			};
		}

		public new void Update()
		{
		}

		public void AddSprite(Sprite sprite)
		{
			this.listSprite.Add(sprite);
		}

		public void ClearSprites()
		{
			this.listSprite.Clear();
		}

		public void AddAera(Aera aera)
		{
			this.listAera.Add(aera);
		}

		public void ClearAeras()
		{
			this.listAera.Clear();
		}

		public void AddText(Text text)
		{
			this.listText.Add(text);
		}

		public void ClearTexts()
		{
			this.listText.Clear();
		}

		public void TakeScreenShot(string path)
		{
			this.spriteBatch.Begin();
			for (int num = 0; num != this.listSprite.Count; num++)
			{
				this.listSprite[num].Draw(this.spriteBatch);
			}
			this.spriteBatch.End();
			ResolveTexture2D resolveTexture2D = new ResolveTexture2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth, base.GraphicsDevice.PresentationParameters.BackBufferHeight, 1, SurfaceFormat.Color);
			base.GraphicsDevice.ResolveBackBuffer(resolveTexture2D);
			resolveTexture2D.Save(path, ImageFileFormat.Bmp);
		}

		protected override void Draw()
		{
			base.GraphicsDevice.Clear(Color.White);
			this.spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None);
			for (int i = 0; i < this.listSprite.Count; i++)
			{
				this.listSprite[i].Draw(this.spriteBatch);
			}
			for (int i = 0; i < this.listAera.Count; i++)
			{
				this.listAera[i].Draw(this.spriteBatch);
			}
			for (int i = 0; i < this.listText.Count; i++)
			{
				this.listText[i].Draw(this.spriteBatch);
			}
			this.spriteBatch.End();
		}
	}
}
