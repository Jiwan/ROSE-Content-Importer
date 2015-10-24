using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Arua_content_importer.Common.FileHandler
{
	public class ZMS
	{
		private string formatCode;

		public Vector3 minBounds;

		public Vector3 maxBounds;

		private short boneCount;

		private short[] boneID;

		private short vertCount;

		private short faceCount;

		private short stripCount;

		private Texture2D texture;

		private ZSC.Materiel Materiel;

		public string path
		{
			get;
			set;
		}

		public ClientType clientType
		{
			get;
			set;
		}

		public VertexPositionNormalTexture[] vertex
		{
			get;
			set;
		}

		public short[] Indices
		{
			get;
			set;
		}

		public void Load(string Path, ClientType myClientType)
		{
			this.path = Path;
			this.clientType = myClientType;
			BinaryReader binaryReader = new BinaryReader(File.Open(this.path, FileMode.Open));
			binaryReader.BaseStream.Seek(8L, SeekOrigin.Begin);
			int num = binaryReader.ReadInt32();
			binaryReader.BaseStream.Seek(24L, SeekOrigin.Current);
			this.boneCount = binaryReader.ReadInt16();
			binaryReader.BaseStream.Seek((long)(this.boneCount * 2), SeekOrigin.Current);
			this.vertCount = binaryReader.ReadInt16();
			this.vertex = new VertexPositionNormalTexture[(int)this.vertCount];
			if ((num & 2) > 0)
			{
				for (int i = 0; i < (int)this.vertCount; i++)
				{
					this.vertex[i].Position.X = binaryReader.ReadSingle();
					this.vertex[i].Position.Y = binaryReader.ReadSingle();
					this.vertex[i].Position.Z = binaryReader.ReadSingle();
				}
			}
			if ((num & 4) > 0)
			{
				binaryReader.BaseStream.Seek((long)(12 * this.vertCount), SeekOrigin.Current);
			}
			if ((num & 8) > 0)
			{
				binaryReader.BaseStream.Seek((long)(4 * this.vertCount), SeekOrigin.Current);
			}
			if ((num & 16) > 0 && (num & 32) > 0)
			{
				binaryReader.BaseStream.Seek((long)(24 * this.vertCount), SeekOrigin.Current);
			}
			if ((num & 64) > 0)
			{
				binaryReader.BaseStream.Seek((long)(12 * this.vertCount), SeekOrigin.Current);
			}
			int num2 = 0;
			if ((num & 128) > 0)
			{
				num2++;
			}
			if ((num & 256) > 0)
			{
				num2++;
			}
			if ((num & 512) > 0)
			{
				num2++;
			}
			if ((num & 1024) > 0)
			{
				num2++;
			}
			if (num2 >= 1)
			{
				for (int i = 0; i < (int)this.vertCount; i++)
				{
					this.vertex[i].TextureCoordinate.X = binaryReader.ReadSingle();
					this.vertex[i].TextureCoordinate.Y = binaryReader.ReadSingle();
				}
			}
			if (num2 >= 2)
			{
				for (int i = 0; i < (int)this.vertCount; i++)
				{
					this.vertex[i].Normal.X = binaryReader.ReadSingle();
					this.vertex[i].Normal.Y = binaryReader.ReadSingle();
				}
			}
			this.faceCount = binaryReader.ReadInt16();
			this.Indices = new short[(int)(this.faceCount * 3)];
			for (int i = 0; i < (int)this.faceCount; i++)
			{
				this.Indices[i * 3] = binaryReader.ReadInt16();
				this.Indices[i * 3 + 1] = binaryReader.ReadInt16();
				this.Indices[i * 3 + 2] = binaryReader.ReadInt16();
			}
			binaryReader.Close();
		}

		public void LoadTexture(string clientPath, GraphicsDevice graphics, ZSC.Materiel Materiel)
		{
			this.texture = Texture2D.FromFile(graphics, clientPath + "\\" + Materiel.path);
			this.Materiel = Materiel;
		}

		public void Draw(GraphicsDevice graphics, BasicEffect effect)
		{
			effect.LightingEnabled = true;
			effect.AmbientLightColor = new Vector3(1f, 1f, 1f);
			effect.Texture = this.texture;
			effect.TextureEnabled = true;
			effect.Alpha = this.Materiel.alpha;
			effect.Begin();
			graphics.RenderState.AlphaBlendEnable = Convert.ToBoolean(this.Materiel.alpha_enabled);
			if (Convert.ToBoolean(this.Materiel.alpha_enabled))
			{
				graphics.RenderState.AlphaTestEnable = Convert.ToBoolean(this.Materiel.alpha_test_enabled);
				if (this.Materiel.blending_mode == 1)
				{
					graphics.RenderState.SourceBlend = Blend.One;
				}
				else
				{
					graphics.RenderState.SourceBlend = Blend.SourceAlpha;
				}
				if (this.Materiel.blending_mode == 1)
				{
					graphics.RenderState.DestinationBlend = Blend.One;
				}
				else
				{
					graphics.RenderState.DestinationBlend = Blend.InverseSourceAlpha;
				}
				graphics.RenderState.ReferenceAlpha = (int)this.Materiel.alpha_ref_enabled;
				graphics.RenderState.AlphaFunction = CompareFunction.GreaterEqual;
				graphics.RenderState.BlendFunction = BlendFunction.Add;
			}
			else
			{
				graphics.RenderState.AlphaTestEnable = false;
				graphics.RenderState.SourceBlend = Blend.One;
				graphics.RenderState.DestinationBlend = Blend.Zero;
				graphics.RenderState.ReferenceAlpha = 0;
				graphics.RenderState.AlphaFunction = CompareFunction.Always;
				graphics.RenderState.BlendFunction = BlendFunction.Add;
			}
			for (int i = 0; i < effect.CurrentTechnique.Passes.Count; i++)
			{
				effect.CurrentTechnique.Passes[i].Begin();
				graphics.DrawUserIndexedPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, this.vertex, 0, this.vertex.Length, this.Indices, 0, this.Indices.Length / 3);
				effect.CurrentTechnique.Passes[i].End();
			}
			effect.End();
		}
	}
}
