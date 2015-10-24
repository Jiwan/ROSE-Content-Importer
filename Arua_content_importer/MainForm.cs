using Arua_content_importer.Common.FileHandler;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Arua_content_importer
{
	public class MainForm : Form
	{
		public sealed class STBFile
		{
			public static readonly string ARMS = "3DDATA\\STB\\LIST_ARMS.STB";

			public static readonly string BACK = "3DDATA\\STB\\LIST_BACK.STB";

			public static readonly string BODY = "3DDATA\\STB\\LIST_BODY.STB";

			public static readonly string CAP = "3DDATA\\STB\\LIST_CAP.STB";

			public static readonly string FACEITEM = "3DDATA\\STB\\LIST_FACEITEM.STB";

			public static readonly string FOOT = "3DDATA\\STB\\LIST_FOOT.STB";

			public static readonly string NATURAL = "3DDATA\\STB\\LIST_NATURAL.STB";

			public static readonly string USEITEM = "3DDATA\\STB\\LIST_USEITEM.STB";

			public static readonly string WEAPONS = "3DDATA\\STB\\LIST_WEAPON.STB";

			public static readonly string SUBWPN = "3DDATA\\STB\\LIST_SUBWPN.STB";

			public static readonly string PAT = "3DDATA\\STB\\LIST_PAT.STB";

			public static readonly string NPC = "3DDATA\\STB\\LIST_NPC.STB";
		}

		public sealed class STLFile
		{
			public static readonly string ARMS = "3DDATA\\STB\\LIST_ARMS_S.STL";

			public static readonly string BACK = "3DDATA\\STB\\LIST_BACK_S.STL";

			public static readonly string BODY = "3DDATA\\STB\\LIST_BODY_S.STL";

			public static readonly string CAP = "3DDATA\\STB\\LIST_CAP_S.STL";

			public static readonly string FACEITEM = "3DDATA\\STB\\LIST_FACEITEM_S.STL";

			public static readonly string FOOT = "3DDATA\\STB\\LIST_FOOT_S.STL";

			public static readonly string NATURAL = "3DDATA\\STB\\LIST_NATURAL_S.STL";

			public static readonly string USEITEM = "3DDATA\\STB\\LIST_USEITEM_S.STL";

			public static readonly string WEAPONS = "3DDATA\\STB\\LIST_WEAPON_S.STL";

			public static readonly string SUBWPN = "3DDATA\\STB\\LIST_SUBWPN_S.STL";

			public static readonly string PAT = "3DDATA\\STB\\LIST_PAT_S.STL";

			public static readonly string NPC = "3DDATA\\STB\\LIST_NPC_S.STL";
		}

		public sealed class STLPrefix
		{
			public static readonly string ARMS = "LARM";

			public static readonly string BACK = "LBAC";

			public static readonly string BODY = "LBOD";

			public static readonly string CAP = "LCAP";

			public static readonly string FACEITEM = "LFAC";

			public static readonly string FOOT = "LFOO";

			public static readonly string NATURAL = "LNAT";

			public static readonly string USEITEM = "LUSE";

			public static readonly string WEAPONS = "LWEA";

			public static readonly string PAT = "PAT";

			public static readonly string SUBWPN = "LSUB";

			public static readonly string NPC = "LNPC";
		}

		public sealed class ZSCFile
		{
			public static readonly string MARMS = "3DDATA\\AVATAR\\LIST_MARMS.ZSC";

			public static readonly string WARMS = "3DDATA\\AVATAR\\LIST_WARMS.ZSC";

			public static readonly string BACK = "3DDATA\\AVATAR\\LIST_BACK.ZSC";

			public static readonly string MBODY = "3DDATA\\AVATAR\\LIST_MBODY.ZSC";

			public static readonly string WBODY = "3DDATA\\AVATAR\\LIST_WBODY.ZSC";

			public static readonly string MCAP = "3DDATA\\AVATAR\\LIST_MCAP.ZSC";

			public static readonly string WCAP = "3DDATA\\AVATAR\\LIST_WCAP.ZSC";

			public static readonly string FACEITEM = "3DDATA\\AVATAR\\LIST_FACEIEM.ZSC";

			public static readonly string MFOOT = "3DDATA\\AVATAR\\LIST_MFOOT.ZSC";

			public static readonly string WFOOT = "3DDATA\\AVATAR\\LIST_WFOOT.ZSC";

			public static readonly string NATURAL = "";

			public static readonly string USEITEM = "";

			public static readonly string WEAPONS = "3DDATA\\WEAPON\\LIST_WEAPON.ZSC";

			public static readonly string SUBWPN = "3DDATA\\WEAPON\\LIST_SUBWPN.ZSC";

			public static readonly string PAT = "3DDATA\\PAT\\LIST_PAT.ZSC";

			public static readonly string NPC = "3DDATA\\NPC\\PART_NPC.ZSC";
		}

		public sealed class CHRFile
		{
			public static readonly string NPC = "3DDATA\\NPC\\LIST_NPC.CHR";
		}

		private PreviewForm previewForm;

		private IconForm iconForm;

		public ClientType ImportedType;

		public STB ImportedSTB;

		public STB ExportedSTB;

		public STL ImportedSTL;

		public STL ExportedSTL;

		public ZSC ImportedMZSC;

		public ZSC ImportedWZSC;

		public ZSC ExportedMZSC;

		public ZSC ExportedWZSC;

		public CHR ImportedCHR;

		public CHR ExportedCHR;

		public int ImportedItemIndex;

		public int ExportedItemIndex;

		private IContainer components = null;

		private TabControl tabControl;

		private TabPage tabFolderSelection;

		private TabPage tabObjectSelection;

		private Label label2;

		private Label label1;

		private Button buttonBrowse2;

		private Button buttonBrowse;

		private TextBox textBoxExportedFolder;

		private TextBox textBoxImportedFolder;

		private Button buttonNextTab1;

		private FolderBrowserDialog folderBrowserDialog;

		private Label label3;

		private ComboBox comboBoxObjetType;

		private GroupBox groupBoxImported;

		private RadioButton radioButtonIroseImported;

		private GroupBox groupBoxExported;

		private RadioButton radioButtonNaroseImported;

		private RadioButton radioButtonJroseImported;

		private ListBox listBoxImported;

		private TabPage tabObjectEditing;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripStatusLabel toolStripStatus;

		private ListBox listBoxExported;

		private Button buttonNextTab2;

		private Label label5;

		private Label label4;

		private Label label6;

		private GroupBox groupBoxSTB;

		private GroupBox groupBoxSTL;

		private TextBox textBoxDescription;

		private Label label8;

		private TextBox textBoxName;

		private Label label7;

		private DataGridView dataGridView;

		private Button buttonImport;

		private TabPage tabHistory;

		private Button buttonNew;

		private RichTextBox richTextBoxHistory;

		private Label label9;

		public MainForm()
		{
			this.InitializeComponent();
			this.ImportedSTB = new STB();
			this.ExportedSTB = new STB();
			this.ImportedSTL = new STL();
			this.ExportedSTL = new STL();
			this.ImportedMZSC = new ZSC();
			this.ImportedWZSC = new ZSC();
			this.ExportedMZSC = new ZSC();
			this.ExportedWZSC = new ZSC();
			this.ImportedCHR = new CHR();
			this.ExportedCHR = new CHR();
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				this.textBoxImportedFolder.Text = this.folderBrowserDialog.SelectedPath;
			}
		}

		private void buttonBrowse2_Click(object sender, EventArgs e)
		{
			if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				this.textBoxExportedFolder.Text = this.folderBrowserDialog.SelectedPath;
			}
		}

		private void buttonNextTab1_Click(object sender, EventArgs e)
		{
			if (this.comboBoxObjetType.Text == "")
			{
				MessageBox.Show("Please pick up an object type", "Error", MessageBoxButtons.OK);
			}
			else if (this.textBoxImportedFolder.Text == "" || this.textBoxExportedFolder.Text == "")
			{
				MessageBox.Show("Please select two folders", "Error", MessageBoxButtons.OK);
			}
			else
			{
				if (this.radioButtonIroseImported.Checked)
				{
					this.ImportedType = ClientType.IROSE;
				}
				else if (this.radioButtonNaroseImported.Checked)
				{
					this.ImportedType = ClientType.NAROSE;
				}
				else
				{
					this.ImportedType = ClientType.JROSE;
				}
				try
				{
					string text = this.comboBoxObjetType.Text;
					switch (text)
					{
					case "Arms":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.ARMS, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.ARMS, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.ARMS, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.ARMS, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.MARMS);
						this.ImportedWZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.WARMS);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.MARMS);
						this.ExportedWZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.WARMS);
						break;
					case "Back":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.BACK, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.BACK, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.BACK, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.BACK, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.BACK);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.BACK);
						break;
					case "Body":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.BODY, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.BODY, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.BODY, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.BODY, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.MBODY);
						this.ImportedWZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.WBODY);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.MBODY);
						this.ExportedWZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.WBODY);
						break;
					case "Cap":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.CAP, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.CAP, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.CAP, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.CAP, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.MCAP);
						this.ImportedWZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.WCAP);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.MCAP);
						this.ExportedWZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.WCAP);
						break;
					case "Face item":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.FACEITEM, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.FACEITEM, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.FACEITEM, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.FACEITEM, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.FACEITEM);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.FACEITEM);
						break;
					case "Foot":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.FOOT, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.FOOT, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.FOOT, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.FOOT, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.MFOOT);
						this.ImportedWZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.WFOOT);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.MFOOT);
						this.ExportedWZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.WFOOT);
						break;
					case "Natural":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.NATURAL, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.NATURAL, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.NATURAL, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.NATURAL, ClientType.IROSE);
						break;
					case "Use item":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.USEITEM, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.USEITEM, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.USEITEM, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.USEITEM, ClientType.IROSE);
						break;
					case "PAT":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.PAT, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.PAT, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.PAT, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.PAT, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.PAT);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.PAT);
						break;
					case "SUBWPN":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.SUBWPN, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.SUBWPN, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.SUBWPN, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.SUBWPN, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.SUBWPN);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.SUBWPN);
						break;
					case "Weapons":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.WEAPONS, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.WEAPONS, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.WEAPONS, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.WEAPONS, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.WEAPONS);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.WEAPONS);
						break;
					case "NPC":
						this.ImportedSTB.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STBFile.NPC, this.ImportedType);
						this.ExportedSTB.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STBFile.NPC, ClientType.IROSE);
						this.ImportedSTL.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.STLFile.NPC, this.ImportedType);
						this.ExportedSTL.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.STLFile.NPC, ClientType.IROSE);
						this.ImportedMZSC.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.ZSCFile.NPC);
						this.ExportedMZSC.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.ZSCFile.NPC);
						this.ImportedCHR.Load(this.textBoxImportedFolder.Text + "\\" + MainForm.CHRFile.NPC);
						this.ExportedCHR.Load(this.textBoxExportedFolder.Text + "\\" + MainForm.CHRFile.NPC);
						break;
					}
					this.previewForm = new PreviewForm();
					this.previewForm.Show();
					this.previewForm.SetZSC(this.ImportedMZSC, this.ImportedWZSC);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error to open file : " + ex.Message);
				}
				this.LoadSecondTab();
				this.tabControl.SelectedIndex++;
			}
		}

		private int GetSTLLinkColumn(bool import)
		{
			int result;
			if (import)
			{
				if (this.comboBoxObjetType.Text.Equals("NPC"))
				{
					if (this.ImportedSTB.clientType == ClientType.IROSE)
					{
						result = this.ImportedSTB.columnCount - 3;
					}
					else if (this.ImportedSTB.clientType == ClientType.NAROSE || this.ImportedSTB.clientType == ClientType.JROSE)
					{
						result = this.ImportedSTB.columnCount - 9;
					}
					else
					{
						result = this.ImportedSTB.columnCount - 1;
					}
				}
				else
				{
					result = this.ImportedSTB.columnCount - 1;
				}
			}
			else if (this.comboBoxObjetType.Text.Equals("NPC"))
			{
				if (this.ExportedSTB.clientType == ClientType.IROSE)
				{
					result = this.ExportedSTB.columnCount - 3;
				}
				else if (this.ExportedSTB.clientType == ClientType.NAROSE || this.ExportedSTB.clientType == ClientType.JROSE)
				{
					result = this.ExportedSTB.columnCount - 9;
				}
				else
				{
					result = this.ExportedSTB.columnCount - 1;
				}
			}
			else
			{
				result = this.ExportedSTB.columnCount - 1;
			}
			return result;
		}

		public void LoadSecondTab()
		{
			int sTLLinkColumn = this.GetSTLLinkColumn(true);
			for (int i = 0; i < this.ImportedSTB.rowCount; i++)
			{
				if (!this.ImportedSTB.EmptyRow(i))
				{
					int entryIndex = this.ImportedSTL.GetEntryIndex(this.ImportedSTB.cell[i, sTLLinkColumn]);
					if (entryIndex == -1)
					{
						this.listBoxImported.Items.Add("Object[" + i + "] : Probably empty(no STL entry)");
					}
					else if (this.ImportedSTL.languageCount >= 2)
					{
						this.listBoxImported.Items.Add(string.Concat(new object[]
						{
							"Object[",
							i,
							"] : ",
							this.ImportedSTL.entry[entryIndex].text[1]
						}));
					}
					else
					{
						this.listBoxImported.Items.Add(string.Concat(new object[]
						{
							"Object[",
							i,
							"] : ",
							this.ImportedSTL.entry[entryIndex].text[0]
						}));
					}
				}
				else
				{
					this.listBoxImported.Items.Add("Object[" + i + "] : Empty");
				}
			}
			sTLLinkColumn = this.GetSTLLinkColumn(false);
			for (int i = 0; i < this.ExportedSTB.rowCount; i++)
			{
				if (!this.ExportedSTB.EmptyRow(i))
				{
					int entryIndex = this.ExportedSTL.GetEntryIndex(this.ExportedSTB.cell[i, sTLLinkColumn]);
					if (entryIndex == -1)
					{
						this.listBoxExported.Items.Add("Object[" + i + "] : Probably empty(no STL entry)");
					}
					else if (this.ExportedSTL.languageCount >= 2)
					{
						this.listBoxExported.Items.Add(string.Concat(new object[]
						{
							"Object[",
							i,
							"] : ",
							this.ExportedSTL.entry[entryIndex].text[1]
						}));
					}
					else
					{
						this.listBoxExported.Items.Add(string.Concat(new object[]
						{
							"Object[",
							i,
							"] : ",
							this.ExportedSTL.entry[entryIndex].text[0]
						}));
					}
				}
				else
				{
					this.listBoxExported.Items.Add("Object[" + i + "] : Empty");
				}
			}
		}

		private void buttonNextTab2_Click(object sender, EventArgs e)
		{
			if (this.listBoxImported.SelectedItems.Count == 0 || this.listBoxExported.SelectedItems.Count == 0)
			{
				MessageBox.Show("Please select one row in each client", "Error", MessageBoxButtons.OK);
			}
			else if (this.ImportedSTB.EmptyRow(this.listBoxImported.SelectedIndex))
			{
				MessageBox.Show("An empty row can't be import", "Error", MessageBoxButtons.OK);
			}
			else if (this.listBoxExported.SelectedIndex >= this.ExportedMZSC.listObject.Count && !this.comboBoxObjetType.Text.Equals("NPC"))
			{
				MessageBox.Show("Your zsc file haven't enough entry to add this item !!! Please add more empty entry in your zsc with your favorite zsc editor", "Error", MessageBoxButtons.OK);
			}
			else if (this.comboBoxObjetType.Text.Equals("NPC") && this.listBoxExported.SelectedIndex >= this.ExportedCHR.list_character.Count)
			{
				MessageBox.Show("Your chr file haven't enough entry to add this item !!! Please add more empty entry in your chr with your favorite zsc editor", "Error", MessageBoxButtons.OK);
			}
			else
			{
				this.ImportedItemIndex = this.listBoxImported.SelectedIndex;
				this.ExportedItemIndex = this.listBoxExported.SelectedIndex;
				this.previewForm.Close();
				this.previewForm.Dispose();
				this.iconForm = new IconForm(this.textBoxImportedFolder.Text, this.textBoxExportedFolder.Text);
				this.iconForm.Show();
				this.LoadThirdTab();
				this.tabControl.SelectedIndex++;
			}
		}

		private void LoadThirdTab()
		{
			int sTLLinkColumn = this.GetSTLLinkColumn(true);
			for (int i = 0; i < this.ImportedSTL.entryCount; i++)
			{
				if (this.ImportedSTB.cell[this.ImportedItemIndex, sTLLinkColumn] == this.ImportedSTL.entry[i].string_ID)
				{
					if (this.ImportedSTL.languageCount >= 2)
					{
						this.textBoxName.Text = this.ImportedSTL.entry[i].text[1];
						this.textBoxDescription.Text = this.ImportedSTL.entry[i].comment[1];
					}
					else
					{
						this.textBoxName.Text = this.ImportedSTL.entry[i].text[0];
						this.textBoxDescription.Text = this.ImportedSTL.entry[i].comment[0];
					}
				}
			}
			int num;
			if (this.comboBoxObjetType.Text.Equals("NPC"))
			{
				num = this.ExportedSTB.columnCount;
			}
			else
			{
				num = this.ExportedSTB.columnCount - 1;
			}
			this.dataGridView.ColumnCount = num;
			for (int j = 0; j < num; j++)
			{
				this.dataGridView.Columns[j].Name = this.ExportedSTB.column[j].title;
				this.dataGridView.Columns[j].Width = (int)this.ExportedSTB.column[j].width;
				this.dataGridView.Rows[0].Cells[j].Value = this.ImportedSTB.cell[this.ImportedItemIndex, j];
			}
		}

		private void buttonImport_Click(object sender, EventArgs e)
		{
			if (this.textBoxName.Text == "")
			{
				MessageBox.Show("Please give a name to the object", "error", MessageBoxButtons.OK);
			}
			else
			{
				this.tabControl.SelectedIndex++;
				if (this.iconForm != null)
				{
					this.iconForm.Close();
					this.iconForm.Dispose();
				}
				this.ImportObject();
			}
		}

		public void ImportObject()
		{
			string text = this.textBoxName.Text;
			string text2 = this.textBoxDescription.Text;
			this.richTextBoxHistory.AppendText(string.Concat(new string[]
			{
				"Starting importation from client ",
				this.textBoxImportedFolder.Text,
				" to our client ",
				this.textBoxExportedFolder.Text,
				"\n"
			}));
			this.richTextBoxHistory.AppendText(string.Concat(new object[]
			{
				"Object that where at position [",
				this.ImportedItemIndex,
				"] will be in our client at position [",
				this.ExportedItemIndex,
				"]\n"
			}));
			this.richTextBoxHistory.AppendText(text + " : " + text2 + "\n");
			int num;
			if (this.comboBoxObjetType.Text.Equals("NPC"))
			{
				num = this.ExportedSTB.columnCount;
			}
			else
			{
				num = this.ExportedSTB.columnCount - 1;
			}
			string[] array = new string[this.ExportedSTB.columnCount];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.dataGridView.Rows[0].Cells[i].Value.ToString();
			}
			int sTLLinkColumn = this.GetSTLLinkColumn(false);
			string text3 = this.comboBoxObjetType.Text;
			switch (text3)
			{
			case "Arms":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.ARMS + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.ARMS + this.ExportedItemIndex;
				break;
			case "Back":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.BACK + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.BACK + this.ExportedItemIndex;
				break;
			case "Body":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.BODY + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.BODY + this.ExportedItemIndex;
				break;
			case "Cap":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.CAP + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.CAP + this.ExportedItemIndex;
				break;
			case "Face item":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.FACEITEM + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.FACEITEM + this.ExportedItemIndex;
				break;
			case "Foot":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.FOOT + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.FOOT + this.ExportedItemIndex;
				break;
			case "SUBWPN":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.SUBWPN + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.SUBWPN + this.ExportedItemIndex;
				break;
			case "PAT":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.PAT + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.PAT + this.ExportedItemIndex;
				break;
			case "Weapons":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.WEAPONS + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.WEAPONS + this.ExportedItemIndex;
				break;
			case "NPC":
				this.ExportedSTL.AddEntry(this.ExportedItemIndex, MainForm.STLPrefix.NPC + this.ExportedItemIndex, text, text2);
				array[sTLLinkColumn] = MainForm.STLPrefix.NPC + this.ExportedItemIndex;
				break;
			}
			if (this.comboBoxObjetType.Text.Equals("NPC"))
			{
				CHR.Character character = this.ImportedCHR.list_character[this.ImportedItemIndex];
				int count = character.List_Mesh.Count;
				int num3 = -1;
				int num4 = 0;
				for (int i = 0; i < this.ExportedMZSC.listObject.Count; i++)
				{
					if (this.ExportedMZSC.listObject[i].list_mesh.Count == 0 && this.ExportedMZSC.listObject[i].list_effect.Count == 0)
					{
						num4++;
						if (num4 == count)
						{
							num3 = i - count + 1;
							break;
						}
					}
					else
					{
						num4 = 0;
					}
				}
				if (num3 == -1)
				{
					this.richTextBoxHistory.AppendText("Error : Not enough space to copy " + count + " entries in our client \n");
					return;
				}
				this.ExportedSTB.ReplaceRow(this.ExportedItemIndex, array);
				this.ExportedSTB.Save();
				this.richTextBoxHistory.AppendText("Item succefully import into STB : " + this.ExportedSTB.path + "\n");
				this.ExportedSTL.Save();
				this.richTextBoxHistory.AppendText("Item succefully import into STL : " + this.ExportedSTL.path + "\n");
				this.ExportedCHR.list_mesh.Add(this.ImportedCHR.list_mesh[(int)character.Bone_id]);
				character.Bone_id = Convert.ToInt16(this.ExportedCHR.list_mesh.Count - 1);
				character.is_active = 1;
				this.CopyFile(this.ExportedCHR.list_mesh[(int)character.Bone_id].Mesh_path);
				for (int i = 0; i < character.List_Motion.Count; i++)
				{
					this.ExportedCHR.list_motion.Add(this.ImportedCHR.list_motion[(int)character.List_Motion[i].Motion_id]);
					character.List_Motion[i].Motion_id = Convert.ToInt16(this.ExportedCHR.list_motion.Count - 1);
					this.CopyFile(this.ExportedCHR.list_motion[(int)character.List_Motion[i].Motion_id].Motion_path);
				}
				for (int i = 0; i < character.List_Effect.Count; i++)
				{
					this.ExportedCHR.list_effect.Add(this.ImportedCHR.list_effect[(int)character.List_Effect[i].Effect_id]);
					character.List_Effect[i].Effect_id = Convert.ToInt16(this.ExportedCHR.list_effect.Count - 1);
					this.CopyFile(this.ExportedCHR.list_effect[(int)character.List_Effect[i].Effect_id].Effect_path);
				}
				for (int j = 0; j < character.List_Mesh.Count; j++)
				{
					ZSC.Object @object = new ZSC.Object();
					@object = this.ImportedMZSC.listObject[(int)character.List_Mesh[j].zsc_obj_id];
					for (int i = 0; i < @object.list_mesh.Count; i++)
					{
						if (@object.list_mesh[i].mesh_id != -1)
						{
							this.ExportedMZSC.listMesh.Add(this.ImportedMZSC.listMesh[(int)@object.list_mesh[i].mesh_id]);
							@object.list_mesh[i].mesh_id = Convert.ToInt16(this.ExportedMZSC.listMesh.Count - 1);
							this.CopyFile(this.ExportedMZSC.listMesh[(int)@object.list_mesh[i].mesh_id].path);
						}
						if (@object.list_mesh[i].material_id != -1)
						{
							this.ExportedMZSC.listMateriel.Add(this.ImportedMZSC.listMateriel[(int)@object.list_mesh[i].material_id]);
							@object.list_mesh[i].material_id = Convert.ToInt16(this.ExportedMZSC.listMateriel.Count - 1);
							this.CopyFile(this.ExportedMZSC.listMateriel[(int)@object.list_mesh[i].material_id].path);
						}
					}
					for (int i = 0; i < @object.list_effect.Count; i++)
					{
						if (@object.list_effect[i].effect_id != -1)
						{
							this.ExportedMZSC.listEffect.Add(this.ImportedMZSC.listEffect[(int)@object.list_effect[i].effect_id]);
							@object.list_effect[i].effect_id = Convert.ToInt16(this.ExportedMZSC.listEffect.Count - 1);
							this.CopyFile(this.ExportedMZSC.listEffect[(int)@object.list_effect[i].effect_id].path);
						}
					}
					character.List_Mesh[j].zsc_obj_id = Convert.ToInt16(num3 + j);
					this.ExportedMZSC.listObject[num3 + j] = @object;
					this.richTextBoxHistory.AppendText(string.Concat(new object[]
					{
						"Item succefully import into ZSC at entry : ",
						num3 + j,
						" in ",
						this.ExportedMZSC.path,
						"\n"
					}));
				}
				this.ExportedMZSC.Save();
				this.richTextBoxHistory.AppendText("Item succefully import into ZSC : " + this.ExportedMZSC.path + "\n");
				this.ExportedCHR.list_character[this.ExportedItemIndex] = character;
				this.ExportedCHR.Save();
				this.richTextBoxHistory.AppendText("Item succefully import into CHR : " + this.ExportedCHR.path + "\n");
			}
			else
			{
				this.ExportedSTB.ReplaceRow(this.ExportedItemIndex, array);
				this.ExportedSTB.Save();
				this.richTextBoxHistory.AppendText("Item succefully import into STB : " + this.ExportedSTB.path + "\n");
				this.ExportedSTL.Save();
				this.richTextBoxHistory.AppendText("Item succefully import into STL : " + this.ExportedSTL.path + "\n");
				ZSC.Object @object = new ZSC.Object();
				@object = this.ImportedMZSC.listObject[this.ImportedItemIndex];
				for (int i = 0; i < @object.list_mesh.Count; i++)
				{
					if (@object.list_mesh[i].mesh_id != -1)
					{
						this.ExportedMZSC.listMesh.Add(this.ImportedMZSC.listMesh[(int)@object.list_mesh[i].mesh_id]);
						@object.list_mesh[i].mesh_id = Convert.ToInt16(this.ExportedMZSC.listMesh.Count - 1);
						this.CopyFile(this.ExportedMZSC.listMesh[(int)@object.list_mesh[i].mesh_id].path);
					}
					if (@object.list_mesh[i].material_id != -1)
					{
						this.ExportedMZSC.listMateriel.Add(this.ImportedMZSC.listMateriel[(int)@object.list_mesh[i].material_id]);
						@object.list_mesh[i].material_id = Convert.ToInt16(this.ExportedMZSC.listMateriel.Count - 1);
						this.CopyFile(this.ExportedMZSC.listMateriel[(int)@object.list_mesh[i].material_id].path);
					}
				}
				for (int i = 0; i < @object.list_effect.Count; i++)
				{
					if (@object.list_effect[i].effect_id != -1)
					{
						this.ExportedMZSC.listEffect.Add(this.ImportedMZSC.listEffect[(int)@object.list_effect[i].effect_id]);
						@object.list_effect[i].effect_id = Convert.ToInt16(this.ExportedMZSC.listEffect.Count - 1);
						this.CopyFile(this.ExportedMZSC.listEffect[(int)@object.list_effect[i].effect_id].path);
					}
				}
				this.ExportedMZSC.listObject[this.ExportedItemIndex] = @object;
				this.ExportedMZSC.Save();
				this.richTextBoxHistory.AppendText("Item succefully import into ZSC : " + this.ExportedMZSC.path + "\n");
				if (this.ExportedWZSC.listObject.Count != 0)
				{
					ZSC.Object object2 = this.ImportedWZSC.listObject[this.ImportedItemIndex];
					for (int i = 0; i < object2.list_mesh.Count; i++)
					{
						if (object2.list_mesh[i].mesh_id != -1)
						{
							this.ExportedWZSC.listMesh.Add(this.ImportedWZSC.listMesh[(int)object2.list_mesh[i].mesh_id]);
							object2.list_mesh[i].mesh_id = Convert.ToInt16(this.ExportedWZSC.listMesh.Count - 1);
							this.CopyFile(this.ExportedWZSC.listMesh[(int)object2.list_mesh[i].mesh_id].path);
						}
						if (object2.list_mesh[i].material_id != -1)
						{
							this.ExportedWZSC.listMateriel.Add(this.ImportedWZSC.listMateriel[(int)object2.list_mesh[i].material_id]);
							object2.list_mesh[i].material_id = Convert.ToInt16(this.ExportedWZSC.listMateriel.Count - 1);
							this.CopyFile(this.ExportedWZSC.listMateriel[(int)object2.list_mesh[i].material_id].path);
						}
					}
					for (int i = 0; i < object2.list_effect.Count; i++)
					{
						if (object2.list_effect[i].effect_id != -1)
						{
							this.ExportedWZSC.listEffect.Add(this.ImportedWZSC.listEffect[(int)object2.list_effect[i].effect_id]);
							object2.list_effect[i].effect_id = Convert.ToInt16(this.ExportedWZSC.listEffect.Count - 1);
							this.CopyFile(this.ExportedWZSC.listEffect[(int)object2.list_effect[i].effect_id].path);
						}
					}
					this.ExportedWZSC.listObject[this.ExportedItemIndex] = object2;
					this.ExportedWZSC.Save();
					this.richTextBoxHistory.AppendText("Item succefully import into ZSC : " + this.ExportedWZSC.path + "\n");
				}
			}
			this.richTextBoxHistory.AppendText("Importation succefully done.");
		}

		public void CopyFile(string path)
		{
			try
			{
				if (File.Exists(this.textBoxExportedFolder.Text + "\\" + path))
				{
					this.richTextBoxHistory.AppendText("File " + path + " is already in our client \n");
				}
				else
				{
					string directoryName = Path.GetDirectoryName(this.textBoxExportedFolder.Text + "\\" + path);
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					File.Copy(this.textBoxImportedFolder.Text + "\\" + path, this.textBoxExportedFolder.Text + "\\" + path);
					this.richTextBoxHistory.AppendText("File " + path + " is now added to our client \n");
				}
			}
			catch
			{
				this.richTextBoxHistory.AppendText("File " + path + " can't be import from imported client , are you sure that you import from an extracted client \n");
			}
		}

		private void buttonNew_Click(object sender, EventArgs e)
		{
			this.listBoxImported.Items.Clear();
			this.listBoxExported.Items.Clear();
			this.richTextBoxHistory.Text = "";
			this.ImportedSTB = new STB();
			this.ExportedSTB = new STB();
			this.ImportedSTL = new STL();
			this.ExportedSTL = new STL();
			this.ImportedMZSC = new ZSC();
			this.ImportedWZSC = new ZSC();
			this.ExportedMZSC = new ZSC();
			this.ExportedWZSC = new ZSC();
			this.ImportedCHR = new CHR();
			this.ExportedCHR = new CHR();
			this.textBoxName.Clear();
			this.textBoxDescription.Clear();
			this.tabControl.SelectedIndex = 0;
		}

		private void listBoxImported_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.previewForm.Clear();
			if (this.comboBoxObjetType.Text.Equals("NPC"))
			{
				int[] array = new int[this.ImportedCHR.list_character[this.listBoxImported.SelectedIndex].List_Mesh.Count];
				for (int i = 0; i < this.ImportedCHR.list_character[this.listBoxImported.SelectedIndex].List_Mesh.Count; i++)
				{
					array[i] = (int)this.ImportedCHR.list_character[this.listBoxImported.SelectedIndex].List_Mesh[i].zsc_obj_id;
				}
				this.previewForm.RenderMesh(array, this.textBoxImportedFolder.Text);
			}
			else
			{
				this.previewForm.RenderMesh(this.listBoxImported.SelectedIndex, this.textBoxImportedFolder.Text);
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\AruaContentImporter\\Client Paths");
			if (registryKey == null)
			{
				registryKey = Registry.CurrentUser.CreateSubKey("Software\\AruaContentImporter\\Client Paths", RegistryKeyPermissionCheck.ReadWriteSubTree);
				registryKey.SetValue("Imported", "empty");
				registryKey.SetValue("Exported", "empty");
			}
			else
			{
				this.textBoxImportedFolder.Text = (string)registryKey.GetValue("Imported");
				this.textBoxExportedFolder.Text = (string)registryKey.GetValue("Exported");
				registryKey.Close();
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.previewForm != null)
			{
				this.previewForm.Close();
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\AruaContentImporter\\Client Paths", RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (!this.textBoxImportedFolder.Text.Equals(""))
			{
				registryKey.SetValue("Imported", this.textBoxImportedFolder.Text);
			}
			if (!this.textBoxExportedFolder.Text.Equals(""))
			{
				registryKey.SetValue("Exported", this.textBoxExportedFolder.Text);
			}
		}

		private void buttonIcon_Click(object sender, EventArgs e)
		{
			this.iconForm = new IconForm(this.textBoxImportedFolder.Text, this.textBoxExportedFolder.Text);
			this.iconForm.Show();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
			this.tabControl = new TabControl();
			this.tabFolderSelection = new TabPage();
			this.groupBoxExported = new GroupBox();
			this.label9 = new Label();
			this.label2 = new Label();
			this.textBoxExportedFolder = new TextBox();
			this.buttonBrowse2 = new Button();
			this.groupBoxImported = new GroupBox();
			this.radioButtonNaroseImported = new RadioButton();
			this.radioButtonJroseImported = new RadioButton();
			this.radioButtonIroseImported = new RadioButton();
			this.label1 = new Label();
			this.textBoxImportedFolder = new TextBox();
			this.buttonBrowse = new Button();
			this.label3 = new Label();
			this.comboBoxObjetType = new ComboBox();
			this.buttonNextTab1 = new Button();
			this.tabObjectSelection = new TabPage();
			this.label5 = new Label();
			this.label4 = new Label();
			this.buttonNextTab2 = new Button();
			this.listBoxExported = new ListBox();
			this.listBoxImported = new ListBox();
			this.tabObjectEditing = new TabPage();
			this.buttonImport = new Button();
			this.groupBoxSTB = new GroupBox();
			this.dataGridView = new DataGridView();
			this.groupBoxSTL = new GroupBox();
			this.textBoxDescription = new TextBox();
			this.label8 = new Label();
			this.textBoxName = new TextBox();
			this.label7 = new Label();
			this.label6 = new Label();
			this.tabHistory = new TabPage();
			this.buttonNew = new Button();
			this.richTextBoxHistory = new RichTextBox();
			this.folderBrowserDialog = new FolderBrowserDialog();
			this.statusStrip1 = new StatusStrip();
			this.toolStripStatusLabel1 = new ToolStripStatusLabel();
			this.toolStripStatus = new ToolStripStatusLabel();
			this.tabControl.SuspendLayout();
			this.tabFolderSelection.SuspendLayout();
			this.groupBoxExported.SuspendLayout();
			this.groupBoxImported.SuspendLayout();
			this.tabObjectSelection.SuspendLayout();
			this.tabObjectEditing.SuspendLayout();
			this.groupBoxSTB.SuspendLayout();
			((ISupportInitialize)this.dataGridView).BeginInit();
			this.groupBoxSTL.SuspendLayout();
			this.tabHistory.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.tabControl.Controls.Add(this.tabFolderSelection);
			this.tabControl.Controls.Add(this.tabObjectSelection);
			this.tabControl.Controls.Add(this.tabObjectEditing);
			this.tabControl.Controls.Add(this.tabHistory);
			this.tabControl.Dock = DockStyle.Fill;
			this.tabControl.Location = new Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new Size(684, 562);
			this.tabControl.TabIndex = 0;
			this.tabFolderSelection.Controls.Add(this.groupBoxExported);
			this.tabFolderSelection.Controls.Add(this.groupBoxImported);
			this.tabFolderSelection.Controls.Add(this.label3);
			this.tabFolderSelection.Controls.Add(this.comboBoxObjetType);
			this.tabFolderSelection.Controls.Add(this.buttonNextTab1);
			this.tabFolderSelection.Location = new Point(4, 22);
			this.tabFolderSelection.Name = "tabFolderSelection";
			this.tabFolderSelection.Padding = new Padding(3);
			this.tabFolderSelection.Size = new Size(676, 536);
			this.tabFolderSelection.TabIndex = 0;
			this.tabFolderSelection.Text = "1) Folder Selection";
			this.tabFolderSelection.UseVisualStyleBackColor = true;
			this.groupBoxExported.Controls.Add(this.label9);
			this.groupBoxExported.Controls.Add(this.label2);
			this.groupBoxExported.Controls.Add(this.textBoxExportedFolder);
			this.groupBoxExported.Controls.Add(this.buttonBrowse2);
			this.groupBoxExported.Location = new Point(0, 316);
			this.groupBoxExported.Name = "groupBoxExported";
			this.groupBoxExported.Size = new Size(676, 112);
			this.groupBoxExported.TabIndex = 13;
			this.groupBoxExported.TabStop = false;
			this.groupBoxExported.Text = "Exported client :";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(122, 36);
			this.label9.Name = "label9";
			this.label9.Size = new Size(214, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "It's our client , so it must be an irose client ...";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(77, 16);
			this.label2.Name = "label2";
			this.label2.Size = new Size(42, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Folder :";
			this.textBoxExportedFolder.Location = new Point(125, 13);
			this.textBoxExportedFolder.Name = "textBoxExportedFolder";
			this.textBoxExportedFolder.Size = new Size(460, 20);
			this.textBoxExportedFolder.TabIndex = 3;
			this.textBoxExportedFolder.Text = "D:\\jeux\\AruaROSE";
			this.buttonBrowse2.Location = new Point(591, 8);
			this.buttonBrowse2.Name = "buttonBrowse2";
			this.buttonBrowse2.Size = new Size(78, 28);
			this.buttonBrowse2.TabIndex = 5;
			this.buttonBrowse2.Text = "Browse";
			this.buttonBrowse2.UseVisualStyleBackColor = true;
			this.buttonBrowse2.Click += new EventHandler(this.buttonBrowse2_Click);
			this.groupBoxImported.Controls.Add(this.radioButtonNaroseImported);
			this.groupBoxImported.Controls.Add(this.radioButtonJroseImported);
			this.groupBoxImported.Controls.Add(this.radioButtonIroseImported);
			this.groupBoxImported.Controls.Add(this.label1);
			this.groupBoxImported.Controls.Add(this.textBoxImportedFolder);
			this.groupBoxImported.Controls.Add(this.buttonBrowse);
			this.groupBoxImported.Location = new Point(0, 124);
			this.groupBoxImported.Name = "groupBoxImported";
			this.groupBoxImported.Size = new Size(676, 112);
			this.groupBoxImported.TabIndex = 12;
			this.groupBoxImported.TabStop = false;
			this.groupBoxImported.Text = "Imported client :";
			this.radioButtonNaroseImported.AutoSize = true;
			this.radioButtonNaroseImported.Location = new Point(284, 39);
			this.radioButtonNaroseImported.Name = "radioButtonNaroseImported";
			this.radioButtonNaroseImported.Size = new Size(114, 17);
			this.radioButtonNaroseImported.TabIndex = 12;
			this.radioButtonNaroseImported.Text = "Narose client (evo)";
			this.radioButtonNaroseImported.UseVisualStyleBackColor = true;
			this.radioButtonJroseImported.AutoSize = true;
			this.radioButtonJroseImported.Location = new Point(202, 39);
			this.radioButtonJroseImported.Name = "radioButtonJroseImported";
			this.radioButtonJroseImported.Size = new Size(78, 17);
			this.radioButtonJroseImported.TabIndex = 11;
			this.radioButtonJroseImported.Text = "Jrose client";
			this.radioButtonJroseImported.UseVisualStyleBackColor = true;
			this.radioButtonIroseImported.AutoSize = true;
			this.radioButtonIroseImported.Checked = true;
			this.radioButtonIroseImported.Location = new Point(120, 39);
			this.radioButtonIroseImported.Name = "radioButtonIroseImported";
			this.radioButtonIroseImported.Size = new Size(76, 17);
			this.radioButtonIroseImported.TabIndex = 10;
			this.radioButtonIroseImported.TabStop = true;
			this.radioButtonIroseImported.Text = "Irose client";
			this.radioButtonIroseImported.UseVisualStyleBackColor = true;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(69, 16);
			this.label1.Name = "label1";
			this.label1.Size = new Size(45, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Folder  :";
			this.textBoxImportedFolder.Location = new Point(120, 13);
			this.textBoxImportedFolder.Name = "textBoxImportedFolder";
			this.textBoxImportedFolder.Size = new Size(460, 20);
			this.textBoxImportedFolder.TabIndex = 2;
			this.textBoxImportedFolder.Text = "C:\\Program Files\\Triggersoft\\ROSE Online Evolution";
			this.buttonBrowse.Location = new Point(586, 8);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new Size(78, 28);
			this.buttonBrowse.TabIndex = 4;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new EventHandler(this.buttonBrowse_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(110, 100);
			this.label3.Name = "label3";
			this.label3.Size = new Size(115, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Objects type to import :";
			this.comboBoxObjetType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxObjetType.FormattingEnabled = true;
			this.comboBoxObjetType.Items.AddRange(new object[]
			{
				"Arms",
				"Back",
				"Body",
				"Cap",
				"Face item",
				"Foot",
				"PAT",
				"SUBWPN",
				"Weapons",
				"NPC"
			});
			this.comboBoxObjetType.Location = new Point(231, 97);
			this.comboBoxObjetType.Name = "comboBoxObjetType";
			this.comboBoxObjetType.Size = new Size(342, 21);
			this.comboBoxObjetType.TabIndex = 8;
			this.buttonNextTab1.Location = new Point(408, 488);
			this.buttonNextTab1.Name = "buttonNextTab1";
			this.buttonNextTab1.Size = new Size(75, 27);
			this.buttonNextTab1.TabIndex = 6;
			this.buttonNextTab1.Text = "Next >>";
			this.buttonNextTab1.UseVisualStyleBackColor = true;
			this.buttonNextTab1.Click += new EventHandler(this.buttonNextTab1_Click);
			this.tabObjectSelection.Controls.Add(this.label5);
			this.tabObjectSelection.Controls.Add(this.label4);
			this.tabObjectSelection.Controls.Add(this.buttonNextTab2);
			this.tabObjectSelection.Controls.Add(this.listBoxExported);
			this.tabObjectSelection.Controls.Add(this.listBoxImported);
			this.tabObjectSelection.Location = new Point(4, 22);
			this.tabObjectSelection.Name = "tabObjectSelection";
			this.tabObjectSelection.Padding = new Padding(3);
			this.tabObjectSelection.Size = new Size(676, 536);
			this.tabObjectSelection.TabIndex = 1;
			this.tabObjectSelection.Text = "2) Object selection";
			this.tabObjectSelection.UseVisualStyleBackColor = true;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(405, 429);
			this.label5.Name = "label5";
			this.label5.Size = new Size(153, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Select where you want to put it";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(6, 429);
			this.label4.Name = "label4";
			this.label4.Size = new Size(176, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Select the object you want to import";
			this.buttonNextTab2.Location = new Point(408, 488);
			this.buttonNextTab2.Name = "buttonNextTab2";
			this.buttonNextTab2.Size = new Size(75, 27);
			this.buttonNextTab2.TabIndex = 7;
			this.buttonNextTab2.Text = "Next >>";
			this.buttonNextTab2.UseVisualStyleBackColor = true;
			this.buttonNextTab2.Click += new EventHandler(this.buttonNextTab2_Click);
			this.listBoxExported.FormattingEnabled = true;
			this.listBoxExported.Location = new Point(408, 6);
			this.listBoxExported.Name = "listBoxExported";
			this.listBoxExported.Size = new Size(260, 420);
			this.listBoxExported.TabIndex = 1;
			this.listBoxImported.FormattingEnabled = true;
			this.listBoxImported.Location = new Point(6, 6);
			this.listBoxImported.Name = "listBoxImported";
			this.listBoxImported.Size = new Size(260, 420);
			this.listBoxImported.TabIndex = 0;
			this.listBoxImported.SelectedIndexChanged += new EventHandler(this.listBoxImported_SelectedIndexChanged);
			this.tabObjectEditing.Controls.Add(this.buttonImport);
			this.tabObjectEditing.Controls.Add(this.groupBoxSTB);
			this.tabObjectEditing.Controls.Add(this.groupBoxSTL);
			this.tabObjectEditing.Controls.Add(this.label6);
			this.tabObjectEditing.Location = new Point(4, 22);
			this.tabObjectEditing.Name = "tabObjectEditing";
			this.tabObjectEditing.Padding = new Padding(3);
			this.tabObjectEditing.Size = new Size(676, 536);
			this.tabObjectEditing.TabIndex = 2;
			this.tabObjectEditing.Text = "3) Object editing";
			this.tabObjectEditing.UseVisualStyleBackColor = true;
			this.buttonImport.Location = new Point(408, 488);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new Size(75, 27);
			this.buttonImport.TabIndex = 8;
			this.buttonImport.Text = "Import";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new EventHandler(this.buttonImport_Click);
			this.groupBoxSTB.Controls.Add(this.dataGridView);
			this.groupBoxSTB.Location = new Point(0, 231);
			this.groupBoxSTB.Name = "groupBoxSTB";
			this.groupBoxSTB.Size = new Size(675, 200);
			this.groupBoxSTB.TabIndex = 2;
			this.groupBoxSTB.TabStop = false;
			this.groupBoxSTB.Text = "STB :";
			this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new Point(3, 19);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new Size(670, 175);
			this.dataGridView.TabIndex = 0;
			this.groupBoxSTL.Controls.Add(this.textBoxDescription);
			this.groupBoxSTL.Controls.Add(this.label8);
			this.groupBoxSTL.Controls.Add(this.textBoxName);
			this.groupBoxSTL.Controls.Add(this.label7);
			this.groupBoxSTL.Location = new Point(0, 25);
			this.groupBoxSTL.Name = "groupBoxSTL";
			this.groupBoxSTL.Size = new Size(675, 200);
			this.groupBoxSTL.TabIndex = 1;
			this.groupBoxSTL.TabStop = false;
			this.groupBoxSTL.Text = "STL :";
			this.textBoxDescription.Location = new Point(82, 60);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new Size(591, 20);
			this.textBoxDescription.TabIndex = 3;
			this.label8.AutoSize = true;
			this.label8.Location = new Point(3, 63);
			this.label8.Name = "label8";
			this.label8.Size = new Size(66, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Description :";
			this.textBoxName.Location = new Point(82, 22);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new Size(593, 20);
			this.textBoxName.TabIndex = 1;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(3, 25);
			this.label7.Name = "label7";
			this.label7.Size = new Size(73, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Object name :";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(3, 3);
			this.label6.Name = "label6";
			this.label6.Size = new Size(177, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Little modifications before importing :";
			this.tabHistory.Controls.Add(this.buttonNew);
			this.tabHistory.Controls.Add(this.richTextBoxHistory);
			this.tabHistory.Location = new Point(4, 22);
			this.tabHistory.Name = "tabHistory";
			this.tabHistory.Padding = new Padding(3);
			this.tabHistory.Size = new Size(676, 536);
			this.tabHistory.TabIndex = 3;
			this.tabHistory.Text = "4) Import history";
			this.tabHistory.UseVisualStyleBackColor = true;
			this.buttonNew.Location = new Point(408, 488);
			this.buttonNew.Name = "buttonNew";
			this.buttonNew.Size = new Size(75, 27);
			this.buttonNew.TabIndex = 9;
			this.buttonNew.Text = "New import";
			this.buttonNew.UseVisualStyleBackColor = true;
			this.buttonNew.Click += new EventHandler(this.buttonNew_Click);
			this.richTextBoxHistory.Location = new Point(0, 4);
			this.richTextBoxHistory.Name = "richTextBoxHistory";
			this.richTextBoxHistory.ReadOnly = true;
			this.richTextBoxHistory.Size = new Size(675, 400);
			this.richTextBoxHistory.TabIndex = 0;
			this.richTextBoxHistory.Text = "";
			this.folderBrowserDialog.Description = "Select a client folder";
			this.statusStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripStatusLabel1,
				this.toolStripStatus
			});
			this.statusStrip1.Location = new Point(0, 540);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new Size(684, 22);
			this.statusStrip1.TabIndex = 8;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new Size(45, 17);
			this.toolStripStatusLabel1.Text = "Status :";
			this.toolStripStatus.Name = "toolStripStatus";
			this.toolStripStatus.Size = new Size(0, 17);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(684, 562);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.tabControl);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MainForm";
			this.Text = "Arua's content importer";
			base.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
			base.Load += new EventHandler(this.MainForm_Load);
			this.tabControl.ResumeLayout(false);
			this.tabFolderSelection.ResumeLayout(false);
			this.tabFolderSelection.PerformLayout();
			this.groupBoxExported.ResumeLayout(false);
			this.groupBoxExported.PerformLayout();
			this.groupBoxImported.ResumeLayout(false);
			this.groupBoxImported.PerformLayout();
			this.tabObjectSelection.ResumeLayout(false);
			this.tabObjectSelection.PerformLayout();
			this.tabObjectEditing.ResumeLayout(false);
			this.tabObjectEditing.PerformLayout();
			this.groupBoxSTB.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView).EndInit();
			this.groupBoxSTL.ResumeLayout(false);
			this.groupBoxSTL.PerformLayout();
			this.tabHistory.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
