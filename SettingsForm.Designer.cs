namespace RobotControlPanel
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.defaultDBTextBox = new System.Windows.Forms.TextBox();
            this.defaultDBOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openDB = new System.Windows.Forms.OpenFileDialog();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultDBTextBox
            // 
            this.defaultDBTextBox.Location = new System.Drawing.Point(18, 40);
            this.defaultDBTextBox.Name = "defaultDBTextBox";
            this.defaultDBTextBox.Size = new System.Drawing.Size(218, 20);
            this.defaultDBTextBox.TabIndex = 0;
            // 
            // defaultDBOpen
            // 
            this.defaultDBOpen.Location = new System.Drawing.Point(242, 38);
            this.defaultDBOpen.Name = "defaultDBOpen";
            this.defaultDBOpen.Size = new System.Drawing.Size(27, 23);
            this.defaultDBOpen.TabIndex = 1;
            this.defaultDBOpen.Text = "...";
            this.defaultDBOpen.UseVisualStyleBackColor = true;
            this.defaultDBOpen.Click += new System.EventHandler(this.defaultDBOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.defaultDBOpen);
            this.groupBox1.Controls.Add(this.defaultDBTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default database";
            // 
            // openDB
            // 
            this.openDB.DefaultExt = "db; db3";
            this.openDB.Filter = "Databases|*.db; *.db3|All files|*.*";
            this.openDB.Title = "Open database...";
            this.openDB.FileOk += new System.ComponentModel.CancelEventHandler(this.openDB_FileOk);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(152, 111);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(233, 111);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 145);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox defaultDBTextBox;
        private System.Windows.Forms.Button defaultDBOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openDB;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}