using Arua_content_importer.Common.FileHandler;
using Arua_content_importer.Common.GraphicsHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Arua_content_importer
{
	public class IconForm : Form
	{
		private const string ResFolder = "\\3DDATA\\Control\\RES\\";

		private Sprite copiedIcon;

		private string ImportedContentFolder;

		private string ExportedContentFolder;

		private TSI ImportedTSI;

		private TSI ExportedTSI;

		public int DDSIndex;

		public int iconIndex;

		public Bitmap DDSBmp;

		public Bitmap IconBmp;

		private IContainer components = null;

		private textureControl textureControl;

		private Label label1;

		private Button button1;

		private PictureBox pictureBox;

		private GroupBox groupBox1;

		private Label label2;

		private GroupBox groupBox2;

		private Label label3;

		private TextBox textBoxClipboard;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem copyIconToolStripMenuItem;

		private Label label4;

		private NumericUpDown numericUpDownDDS;

		private NumericUpDown numericUpDownIcon;

		public IconForm(string importpath, string exportpath)
		{
			this.InitializeComponent();
			this.ImportedContentFolder = importpath;
			this.ExportedContentFolder = exportpath;
			this.ExportedTSI = new TSI();
			this.ImportedTSI = new TSI();
			this.LoadContent();
			if (File.Exists("Imported Icon.bmp"))
			{
				File.Delete("Imported Icon.bmp");
			}
			if (File.Exists("DDS imported.bmp"))
			{
				File.Delete("DDS imported.bmp");
			}
			if (File.Exists("DDS Modified.png"))
			{
				File.Delete("DDS Modified.png");
			}
		}

		public void LoadContent()
		{
			if (File.Exists(this.ExportedContentFolder + "\\3DDATA\\Control\\RES\\ITEM1.TSI"))
			{
				this.ExportedTSI.Load(this.ExportedContentFolder + "\\3DDATA\\Control\\RES\\ITEM1.TSI");
				this.ImportedTSI.Load(this.ImportedContentFolder + "\\3DDATA\\Control\\RES\\ITEM1.TSI");
			}
			else
			{
				MessageBox.Show(this.ExportedContentFolder + "\\3DDATA\\Control\\RES\\ITEM1.TSI can't be found");
			}
		}

		private void numericUpDownDDS_ValueChanged(object sender, EventArgs e)
		{
			int index = Convert.ToInt32(--this.numericUpDownDDS.Value);
			Sprite sprite = new Sprite(this.textureControl.GraphicsDevice);
			try
			{
				if (this.DDSBmp != null)
				{
					this.DDSBmp.Dispose();
				}
				sprite.LoadTextureFromFile(this.ExportedContentFolder + "\\3DDATA\\Control\\RES\\" + this.ExportedTSI.listDDS[index].Path, new Vector2(0f, 0f), new Microsoft.Xna.Framework.Rectangle(0, 0, 512, 512));
				this.textureControl.ClearSprites();
				this.textureControl.AddSprite(sprite);
				this.DDSIndex = Convert.ToInt32(--this.numericUpDownDDS.Value);
				sprite.texture.Save("DDS imported.bmp", ImageFileFormat.Bmp);
				this.DDSBmp = new Bitmap("DDS imported.bmp");
			}
			catch
			{
			}
		}

		private void textureControl_MouseMove(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element.Count; i++)
			{
				Microsoft.Xna.Framework.Rectangle rect = new Microsoft.Xna.Framework.Rectangle(this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[i].X, this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[i].Y, this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[i].Width, this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[i].Height);
				if (rect.Contains(e.X, e.Y))
				{
					Aera aera = new Aera(this.textureControl.GraphicsDevice, rect, Microsoft.Xna.Framework.Graphics.Color.Red);
					this.textureControl.ClearAeras();
					this.textureControl.AddAera(aera);
					this.textBoxClipboard.Text = (this.DDSIndex * 169 + i).ToString();
					this.iconIndex = i;
				}
			}
		}

		private void UpDownIcon_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.IconBmp != null)
				{
					this.IconBmp.Dispose();
				}
				PresentationParameters presentationParameters = new PresentationParameters();
				presentationParameters.AutoDepthStencilFormat = DepthFormat.Depth24;
				presentationParameters.BackBufferCount = 1;
				presentationParameters.BackBufferFormat = SurfaceFormat.Color;
				presentationParameters.BackBufferHeight = 39;
				presentationParameters.BackBufferWidth = 39;
				presentationParameters.EnableAutoDepthStencil = true;
				presentationParameters.FullScreenRefreshRateInHz = 0;
				presentationParameters.IsFullScreen = false;
				presentationParameters.MultiSampleQuality = 0;
				presentationParameters.MultiSampleType = MultiSampleType.NonMaskable;
				presentationParameters.PresentationInterval = PresentInterval.One;
				presentationParameters.PresentOptions = PresentOptions.None;
				presentationParameters.RenderTargetUsage = RenderTargetUsage.DiscardContents;
				presentationParameters.SwapEffect = SwapEffect.Discard;
				GraphicsDevice graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, DeviceType.Hardware, new Panel().Handle, presentationParameters);
				this.copiedIcon = new Sprite(graphicsDevice);
				int index = Convert.ToInt32(this.numericUpDownIcon.Value) / 169;
				int index2 = Convert.ToInt32(this.numericUpDownIcon.Value) % 169;
				this.copiedIcon.LoadTextureFromFile(this.ImportedContentFolder + "\\3DDATA\\Control\\RES\\" + this.ImportedTSI.listDDS[index].Path, new Vector2(0f, 0f), new Microsoft.Xna.Framework.Rectangle(this.ImportedTSI.listDDS[index].ListDDS_element[index2].X, this.ImportedTSI.listDDS[index].ListDDS_element[index2].Y, this.ImportedTSI.listDDS[index].ListDDS_element[index2].Width, this.ImportedTSI.listDDS[index].ListDDS_element[index2].Height));
				graphicsDevice.Clear(Microsoft.Xna.Framework.Graphics.Color.White);
				SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
				spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
				spriteBatch.Draw(this.copiedIcon.texture, new Vector2(0f, 0f), new Microsoft.Xna.Framework.Rectangle?(this.copiedIcon.sourceRectangle), Microsoft.Xna.Framework.Graphics.Color.White);
				spriteBatch.End();
				using (ResolveTexture2D resolveTexture2D = new ResolveTexture2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, 1, SurfaceFormat.Color))
				{
					graphicsDevice.ResolveBackBuffer(resolveTexture2D);
					resolveTexture2D.Save("Imported Icon.bmp", ImageFileFormat.Bmp);
				}
				this.pictureBox.ImageLocation = "Imported Icon.bmp";
				this.IconBmp = new Bitmap("Imported Icon.bmp");
				this.copiedIcon = new Sprite(this.textureControl.GraphicsDevice);
				this.copiedIcon.LoadTextureFromFile(this.ImportedContentFolder + "\\3DDATA\\Control\\RES\\" + this.ImportedTSI.listDDS[index].Path, new Vector2(0f, 0f), new Microsoft.Xna.Framework.Rectangle(this.ImportedTSI.listDDS[index].ListDDS_element[index2].X, this.ImportedTSI.listDDS[index].ListDDS_element[index2].Y, this.ImportedTSI.listDDS[index].ListDDS_element[index2].Width + 1, this.ImportedTSI.listDDS[index].ListDDS_element[index2].Height + 1));
			}
			catch
			{
			}
		}

		private void copyIconToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[this.iconIndex].Height - 1; i++)
			{
				for (int j = 0; j < this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[this.iconIndex].Width - 1; j++)
				{
					System.Drawing.Color pixel = this.IconBmp.GetPixel(j, i);
					this.DDSBmp.SetPixel(j + this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[this.iconIndex].X, i + this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[this.iconIndex].Y, pixel);
				}
			}
			this.copiedIcon.Move(new Vector2((float)this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[this.iconIndex].X, (float)this.ExportedTSI.listDDS[this.DDSIndex].ListDDS_element[this.iconIndex].Y));
			this.textureControl.AddSprite(this.copiedIcon);
			this.DDSBmp.Save("DDS Modified.png", ImageFormat.Png);
			Texture2D texture2D = Texture2D.FromFile(this.textureControl.GraphicsDevice, "DDS Modified.png");
			texture2D.Save(this.ExportedContentFolder + "\\3DDATA\\Control\\RES\\" + this.ExportedTSI.listDDS[this.DDSIndex].Path, ImageFileFormat.Dds);
		}

		private void IconForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.IconBmp != null)
			{
				this.IconBmp.Dispose();
			}
			if (this.DDSBmp != null)
			{
				this.DDSBmp.Dispose();
			}
			this.pictureBox.Image = null;
			if (File.Exists("Imported Icon.bmp"))
			{
				File.Delete("Imported Icon.bmp");
			}
			if (File.Exists("DDS imported.bmp"))
			{
				File.Delete("DDS imported.bmp");
			}
			if (File.Exists("DDS Modified.png"))
			{
				File.Delete("DDS Modified.png");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			this.label1 = new Label();
			this.button1 = new Button();
			this.pictureBox = new PictureBox();
			this.groupBox1 = new GroupBox();
			this.numericUpDownIcon = new NumericUpDown();
			this.label2 = new Label();
			this.groupBox2 = new GroupBox();
			this.label3 = new Label();
			this.textBoxClipboard = new TextBox();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.copyIconToolStripMenuItem = new ToolStripMenuItem();
			this.label4 = new Label();
			this.numericUpDownDDS = new NumericUpDown();
			this.textureControl = new textureControl();
			((ISupportInitialize)this.pictureBox).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.numericUpDownIcon).BeginInit();
			this.groupBox2.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			((ISupportInitialize)this.numericUpDownDDS).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new Size(317, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Add an icon and select it , or simply select an already existing icon";
			this.button1.Location = new System.Drawing.Point(7, 125);
			this.button1.Name = "button1";
			this.button1.Size = new Size(142, 30);
			this.button1.TabIndex = 5;
			this.button1.Text = "Copy in press papier";
			this.button1.UseVisualStyleBackColor = true;
			this.pictureBox.Location = new System.Drawing.Point(54, 19);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new Size(39, 39);
			this.pictureBox.TabIndex = 6;
			this.pictureBox.TabStop = false;
			this.groupBox1.Controls.Add(this.numericUpDownIcon);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.pictureBox);
			this.groupBox1.Location = new System.Drawing.Point(530, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(148, 113);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Imported icon :";
			this.numericUpDownIcon.Location = new System.Drawing.Point(84, 76);
			NumericUpDown arg_302_0 = this.numericUpDownIcon;
			int[] array = new int[4];
			array[0] = 10000;
			arg_302_0.Maximum = new decimal(array);
			this.numericUpDownIcon.Name = "numericUpDownIcon";
			this.numericUpDownIcon.Size = new Size(58, 20);
			this.numericUpDownIcon.TabIndex = 9;
			this.numericUpDownIcon.ValueChanged += new EventHandler(this.UpDownIcon_ValueChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 78);
			this.label2.Name = "label2";
			this.label2.Size = new Size(72, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Icon number :";
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.textBoxClipboard);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Location = new System.Drawing.Point(530, 153);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(155, 88);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Selected icon :";
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 47);
			this.label3.Name = "label3";
			this.label3.Size = new Size(72, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Icon number :";
			this.textBoxClipboard.Location = new System.Drawing.Point(86, 44);
			this.textBoxClipboard.Name = "textBoxClipboard";
			this.textBoxClipboard.ReadOnly = true;
			this.textBoxClipboard.Size = new Size(56, 20);
			this.textBoxClipboard.TabIndex = 6;
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.copyIconToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new Size(129, 26);
			this.copyIconToolStripMenuItem.Name = "copyIconToolStripMenuItem";
			this.copyIconToolStripMenuItem.Size = new Size(128, 22);
			this.copyIconToolStripMenuItem.Text = "Paste icon";
			this.copyIconToolStripMenuItem.Click += new EventHandler(this.copyIconToolStripMenuItem_Click);
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(168, 548);
			this.label4.Name = "label4";
			this.label4.Size = new Size(74, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "DDS number :";
			this.numericUpDownDDS.Location = new System.Drawing.Point(248, 546);
			NumericUpDown arg_664_0 = this.numericUpDownDDS;
			array = new int[4];
			array[0] = 1;
			arg_664_0.Minimum = new decimal(array);
			this.numericUpDownDDS.Name = "numericUpDownDDS";
			this.numericUpDownDDS.Size = new Size(37, 20);
			this.numericUpDownDDS.TabIndex = 11;
			NumericUpDown arg_6B5_0 = this.numericUpDownDDS;
			array = new int[4];
			array[0] = 1;
			arg_6B5_0.Value = new decimal(array);
			this.numericUpDownDDS.ValueChanged += new EventHandler(this.numericUpDownDDS_ValueChanged);
			this.textureControl.ContextMenuStrip = this.contextMenuStrip;
			this.textureControl.Location = new System.Drawing.Point(12, 25);
			this.textureControl.Name = "textureControl";
			this.textureControl.Size = new Size(514, 514);
			this.textureControl.TabIndex = 2;
			this.textureControl.Text = "textureControl";
			this.textureControl.MouseMove += new MouseEventHandler(this.textureControl_MouseMove);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(684, 577);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.numericUpDownDDS);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textureControl);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "IconForm";
			this.Text = "Icon Manager :";
			base.FormClosed += new FormClosedEventHandler(this.IconForm_FormClosed);
			((ISupportInitialize)this.pictureBox).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.numericUpDownIcon).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			((ISupportInitialize)this.numericUpDownDDS).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
