using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RobotControlPanel
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            if (Properties.Settings.Default.dbPath.Length != 0) defaultDBTextBox.Text = Properties.Settings.Default.dbPath;
        }

        private void defaultDBOpen_Click(object sender, EventArgs e)
        {
            openDB.ShowDialog();
        }

        private void openDB_FileOk(object sender, CancelEventArgs e)
        {
            defaultDBTextBox.Text = openDB.FileName;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbPath = defaultDBTextBox.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
