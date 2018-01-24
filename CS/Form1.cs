using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace StoreInDB
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DevExpress.XtraTreeList.TreeList treeList1;
		private System.Data.DataSet dataSet1;
		private System.Data.DataTable dataTable1;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
		private DevExpress.XtraEditors.SimpleButton simpleButtonLoad;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonLoad = new DevExpress.XtraEditors.SimpleButton();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(472, 173);
            this.treeList1.TabIndex = 0;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Location = new System.Drawing.Point(13, 187);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(114, 20);
            this.simpleButtonSave.TabIndex = 1;
            this.simpleButtonSave.Text = "Save";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // simpleButtonLoad
            // 
            this.simpleButtonLoad.Location = new System.Drawing.Point(140, 187);
            this.simpleButtonLoad.Name = "simpleButtonLoad";
            this.simpleButtonLoad.Size = new System.Drawing.Size(113, 20);
            this.simpleButtonLoad.TabIndex = 2;
            this.simpleButtonLoad.Text = "Load";
            this.simpleButtonLoad.Click += new System.EventHandler(this.simpleButtonLoad_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTable1.TableName = "LayoutData";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "LayoutName";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Data";
            this.dataColumn2.DataType = typeof(byte[]);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(472, 261);
            this.Controls.Add(this.simpleButtonLoad);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.treeList1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e) {
			new DevExpress.XtraTreeList.Design.XViews(treeList1);
			dataTable1.Rows.Add(new object[] {"Layout1"});
		}

		byte[] GetLayoutData(DevExpress.XtraTreeList.TreeList tree) {
			MemoryStream stream = new MemoryStream();
			tree.SaveLayoutToStream(stream);
			return stream.GetBuffer();
		}
		void SetLayoutData(DevExpress.XtraTreeList.TreeList tree, byte[] data) {
			if(data == null || data.Length == 0) return;
			MemoryStream stream = new MemoryStream(data);
			try {
				tree.RestoreLayoutFromStream(stream);
			}
			catch(Exception ex) {
				throw new Exception("Wrong data format", ex);
			}
		}

		private void simpleButtonSave_Click(object sender, System.EventArgs e) {
			dataTable1.Rows[0]["Data"] = GetLayoutData(treeList1);
		}

		private void simpleButtonLoad_Click(object sender, System.EventArgs e) {
			byte[] data = dataTable1.Rows[0]["Data"] as byte[];
			SetLayoutData(treeList1, data);
		}
	}
}
