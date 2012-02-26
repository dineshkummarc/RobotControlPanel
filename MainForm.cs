using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO.Ports;


namespace RobotControlPanel
{
    public partial class MainForm : Form
    {
        //Instantiation of classes and important lists
        dbHandler dataBase = new dbHandler();
        List<CmdGroup> cmdGroupList = new List<CmdGroup>();
        const List<int> baudList = new List<int>() { 921600, 460800, 230400, 115200, 57600, 38400, 19200, 9600, 4800, 2400, 1200, 300, 150, 110 };      
        //MainForm Initialization
        public MainForm()
        {
            InitializeComponent();
            if(Properties.Settings.Default.dbPath.Length != 0) dataBase.SetdbPath(Properties.Settings.Default.dbPath);
            comboBoxBaudRate.DataSource = baudList;
            buttonRefresh_Click(null,null);
        }

        //Close Window, close port
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }
        //----
        private void cmdReadFromDB()
        {
            cmdGroupList = dataBase.cmdFetcher();
        }
        //Menu
        //File
        //Open
        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            openDB.ShowDialog();
            cmdReadFromDB();
            comboBoxCmdListFill();

        }
        //Open, FileOK
        private void openDB_FileOk(object sender, CancelEventArgs e)
        {
            dataBase.SetdbPath(openDB.FileName);
        }
        //Close database
        private void closeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.SetdbPath("");
        }
        //Close
        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Edit
        //Settings
        private void toolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }
        //About
        //About Robot Control Panel
        private void toolStripMenuItemAboutRobotControlPanelT_Click(object sender, EventArgs e)
        {
            AboutRobotControlPanel About = new AboutRobotControlPanel();
            About.ShowDialog();
        }
        //---
        //Console
        delegate void OutputUpdateDelegate(byte[] data);
        private void OutputUpdateCallback(byte[] data)
        {
            if (radioButtonNumbers.Checked)
                for (int i = 0; i < data.Length; i++) textBoxConsole.Text += ' ' + data[i].ToString() + ' ';
            else textBoxConsole.Text += Encoding.ASCII.GetString(data);
        }
        private void DataRec(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = serialPort1.BytesToRead;
                byte[] data = new byte[bytesToRead];
                serialPort1.Read(data, 0, bytesToRead);
                textBoxConsole.Invoke(new OutputUpdateDelegate(OutputUpdateCallback), data);
            }   
            catch (System.Exception ex)
            {
                MessageBox.Show("There was an ERROR! The error message: \n\n" + ex.ToString(), "Error");
            }
        }
        //Clear
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxConsole.Text = "";
        }
        //---
        //Control
        //comboBoxCmdList
        private void comboBoxCmdListFill()
        {
            //for (int i = 0; i < (cmdGroupList.Count); i++)
            //{
            //    comboBoxCmdList.Items.Add(cmdGroupList[i].cmdName);
            //}
        }
        //Send button
        private void button1_Click(object sender, EventArgs e)
        {
            //int i = comboBoxCmdList.SelectedIndex;
            //string param = String.Empty;
            //for (int j = 0; j < cmdGroupList[i].parameterList.Count; j++)
            //{
            //    param +=" "+cmdGroupList[i].parameterList[j].parameterMin.ToString() + " " 
            //        + cmdGroupList[i].parameterList[j].parameterMax.ToString() + " " 
            //        + cmdGroupList[i].parameterList[j].parameterDefault.ToString();
            //}
            //MessageBox.Show(cmdGroupList[i].cmdByte.ToString()+" "/*+cmdList[i].cmdComment*/+" "+param);
        }
        //---
        //Connection
        //Refresh Port List (and Load Port List)
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string[] ports = { String.Empty };
            comboBoxPortList.DataSource = ports;
            ports = SerialPort.GetPortNames();
            if (ports.Length == 0) { buttonConnect.Enabled = false; }
            else { comboBoxPortList.DataSource = ports; buttonConnect.Enabled = true; }
        }
        //groupBoxConnectionStatus
        private void groupBoxConnectionStatus(bool status)
        {
            if(status)
            {
                buttonConnect.Text="Disconnect";
                comboBoxPortList.Enabled=false;
                comboBoxBaudRate.Enabled=false;
                buttonRefresh.Enabled=false;
            }
            else {
                buttonConnect.Text="Connect";
                comboBoxPortList.Enabled=true;
                comboBoxBaudRate.Enabled=true;
                buttonRefresh.Enabled=true;
            }
        }
        //Connect/Disconnect
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try {
                    serialPort1.Close();
                    groupBoxConnectionStatus(false);
                }
                catch (System.Exception ex) { MessageBox.Show("There was an ERROR! The error message: \n\n" + ex.ToString(), "Error"); }
            }
            else
            {
                serialPort1.PortName = Convert.ToString(comboBoxPortList.SelectedItem);
                serialPort1.BaudRate = Convert.ToInt32(comboBoxBaudRate.SelectedItem);
                try
                {
                    serialPort1.Open();
                    groupBoxConnectionStatus(true);
                }
                catch
                {
                    try
                    {
                        serialPort1.PortName = serialPort1.PortName.Remove(serialPort1.PortName.Length - 1);
                        serialPort1.Open();
                        groupBoxConnectionStatus(true);
                    }
                    catch (System.Exception ex) { MessageBox.Show("There was an ERROR! The error message: \n\n" + ex.ToString(), "Error"); }
                }
            }                            
        }
    }
}
