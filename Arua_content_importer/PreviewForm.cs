using Arua_content_importer.Common.FileHandler;
using Arua_content_importer.Common.GraphicsHandler;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Arua_content_importer
{
	public class PreviewForm : Form
	{
		public ZSC MZSC;

		public ZSC WZSC;

		private bool Male = true;

		private int itemIndice;

		private string clientFolder;

		private IContainer components = null;

		private previewControl previewControl;

		private ComboBox comboBoxSex;

		private TrackBar trackBarZoom;

		private Label label1;

		public PreviewForm()
		{
			this.InitializeComponent();
		}

		public void Clear()
		{
			this.previewControl.ClearZMS();
		}

		public void SetZSC(ZSC MZSC, ZSC WZSC)
		{
			this.previewControl.ClearZMS();
			this.MZSC = MZSC;
			this.WZSC = WZSC;
		}

		public void RenderMesh(int[] indice, string clientFolder)
		{
			for (int i = 0; i < indice.Length; i++)
			{
				this.RenderMesh(indice[i], clientFolder);
			}
		}

		public void RenderMesh(int indice, string clientFolder)
		{
			try
			{
				this.clientFolder = clientFolder;
				this.itemIndice = indice;
				for (int i = 0; i < this.MZSC.listObject[indice].list_mesh.Count; i++)
				{
					if (this.Male || this.WZSC == null)
					{
						ZMS zMS = new ZMS();
						zMS.Load(clientFolder + "\\" + this.MZSC.listMesh[(int)this.MZSC.listObject[indice].list_mesh[i].mesh_id].path, ClientType.IROSE);
						zMS.LoadTexture(clientFolder, this.previewControl.GraphicsDevice, this.MZSC.listMateriel[(int)this.MZSC.listObject[indice].list_mesh[i].material_id]);
						this.previewControl.AddZMSToRender(zMS);
					}
					else
					{
						ZMS zMS = new ZMS();
						zMS.Load(clientFolder + "\\" + this.WZSC.listMesh[(int)this.WZSC.listObject[indice].list_mesh[i].mesh_id].path, ClientType.IROSE);
						zMS.LoadTexture(clientFolder, this.previewControl.GraphicsDevice, this.WZSC.listMateriel[(int)this.WZSC.listObject[indice].list_mesh[i].material_id]);
						this.previewControl.AddZMSToRender(zMS);
					}
				}
			}
			catch
			{
				MessageBox.Show("Error to load preview");
			}
		}

		private void comboBoxSex_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBoxSex.SelectedIndex == 0)
			{
				this.Male = true;
			}
			else
			{
				this.Male = false;
			}
			this.RenderMesh(this.itemIndice, this.clientFolder);
		}

		private void trackBarZoom_Scroll(object sender, EventArgs e)
		{
			this.previewControl.zoom = this.trackBarZoom.Value;
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
			this.comboBoxSex = new ComboBox();
			this.trackBarZoom = new TrackBar();
			this.label1 = new Label();
			this.previewControl = new previewControl();
			((ISupportInitialize)this.trackBarZoom).BeginInit();
			base.SuspendLayout();
			this.comboBoxSex.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxSex.FormattingEnabled = true;
			this.comboBoxSex.Items.AddRange(new object[]
			{
				"Male",
				"Female"
			});
			this.comboBoxSex.Location = new Point(12, 12);
			this.comboBoxSex.Name = "comboBoxSex";
			this.comboBoxSex.Size = new Size(103, 21);
			this.comboBoxSex.TabIndex = 2;
			this.comboBoxSex.SelectedIndexChanged += new EventHandler(this.comboBoxSex_SelectedIndexChanged);
			this.trackBarZoom.Location = new Point(554, 12);
			this.trackBarZoom.Maximum = -1;
			this.trackBarZoom.Minimum = -7;
			this.trackBarZoom.Name = "trackBarZoom";
			this.trackBarZoom.Size = new Size(226, 45);
			this.trackBarZoom.TabIndex = 3;
			this.trackBarZoom.Value = -3;
			this.trackBarZoom.Scroll += new EventHandler(this.trackBarZoom_Scroll);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(508, 20);
			this.label1.Name = "label1";
			this.label1.Size = new Size(40, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Zoom :";
			this.previewControl.Dock = DockStyle.Fill;
			this.previewControl.Location = new Point(0, 0);
			this.previewControl.Name = "previewControl";
			this.previewControl.Size = new Size(792, 573);
			this.previewControl.TabIndex = 1;
			this.previewControl.Text = "spinningTriangleControl";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(792, 573);
			base.ControlBox = false;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.trackBarZoom);
			base.Controls.Add(this.comboBoxSex);
			base.Controls.Add(this.previewControl);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "PreviewForm";
			this.Text = "Preview :";
			((ISupportInitialize)this.trackBarZoom).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
