namespace UltimateManagementTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnLoadDb = new System.Windows.Forms.Button();
			this.btnConnect2Server = new System.Windows.Forms.Button();
			this.btnCreateNewDb = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(12, 86);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(268, 249);
			this.treeView1.TabIndex = 0;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(289, 87);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(698, 247);
			this.dataGridView1.TabIndex = 1;
			// 
			// btnLoadDb
			// 
			this.btnLoadDb.Location = new System.Drawing.Point(12, 13);
			this.btnLoadDb.Name = "btnLoadDb";
			this.btnLoadDb.Size = new System.Drawing.Size(133, 21);
			this.btnLoadDb.TabIndex = 2;
			this.btnLoadDb.Text = "Load database";
			this.btnLoadDb.UseVisualStyleBackColor = true;
			this.btnLoadDb.Click += new System.EventHandler(this.btnLoadDb_Click);
			// 
			// btnConnect2Server
			// 
			this.btnConnect2Server.Location = new System.Drawing.Point(151, 12);
			this.btnConnect2Server.Name = "btnConnect2Server";
			this.btnConnect2Server.Size = new System.Drawing.Size(129, 21);
			this.btnConnect2Server.TabIndex = 3;
			this.btnConnect2Server.Text = "Connect to server";
			this.btnConnect2Server.UseVisualStyleBackColor = true;
			// 
			// btnCreateNewDb
			// 
			this.btnCreateNewDb.Location = new System.Drawing.Point(12, 39);
			this.btnCreateNewDb.Name = "btnCreateNewDb";
			this.btnCreateNewDb.Size = new System.Drawing.Size(133, 24);
			this.btnCreateNewDb.TabIndex = 4;
			this.btnCreateNewDb.Text = "Create new database";
			this.btnCreateNewDb.UseVisualStyleBackColor = true;
			this.btnCreateNewDb.Click += new System.EventHandler(this.btnCreateNewDb_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1002, 347);
			this.Controls.Add(this.btnCreateNewDb);
			this.Controls.Add(this.btnConnect2Server);
			this.Controls.Add(this.btnLoadDb);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.treeView1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnLoadDb;
		private System.Windows.Forms.Button btnConnect2Server;
		private System.Windows.Forms.Button btnCreateNewDb;
	}
}

