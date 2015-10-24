using Arua_content_importer.Common.FileHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Arua_content_importer.Common.GraphicsHandler
{
	public class previewControl : GraphicsDeviceControl
	{
		private VertexDeclaration vertexDeclaration;

		public BasicEffect effect;

		private Stopwatch timer;

		private List<ZMS> listZMS = new List<ZMS>();

		public int zoom;

		protected override void Initialize()
		{
			this.vertexDeclaration = new VertexDeclaration(base.GraphicsDevice, VertexPositionNormalTexture.VertexElements);
			this.effect = new BasicEffect(base.GraphicsDevice, null);
			this.timer = Stopwatch.StartNew();
			this.zoom = -3;
			Application.Idle += delegate
			{
				base.Invalidate();
			};
		}

		public new void Update()
		{
			float num = (float)this.timer.Elapsed.TotalSeconds;
			float roll = num * 1f;
			float aspectRatio = base.GraphicsDevice.Viewport.AspectRatio;
			this.effect.World = Matrix.CreateFromYawPitchRoll(0f, -1f, roll);
			this.effect.View = Matrix.CreateLookAt(new Vector3(0f, 4f, (float)this.zoom), new Vector3(0f, 1f, 0f), Vector3.Up);
			this.effect.Projection = Matrix.CreatePerspectiveFieldOfView(1f, aspectRatio, 1f, 10f);
		}

		protected override void Draw()
		{
			base.GraphicsDevice.Clear(Color.White);
			this.Update();
			base.GraphicsDevice.RenderState.CullMode = CullMode.None;
			base.GraphicsDevice.VertexDeclaration = this.vertexDeclaration;
			for (int i = 0; i < this.listZMS.Count; i++)
			{
				this.listZMS[i].Draw(base.GraphicsDevice, this.effect);
			}
		}

		public void AddZMSToRender(ZMS zms)
		{
			this.listZMS.Add(zms);
		}

		public void ClearZMS()
		{
			this.listZMS = new List<ZMS>();
		}
	}
}
