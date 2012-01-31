using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace RobotControlPanel
{
    class dbHandler
    {
        private string dbPath;

        public void SetdbPath(string dbPath)
        {
            this.dbPath = dbPath;
        }

        public int countCmd()
        {
            int count = 0;
            SQLiteConnection db = new SQLiteConnection();
            try
            {
                db.ConnectionString = "Data Source=" + dbPath;
                db.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("There was an ERROR! The error message: \n\n" + ex.ToString(), "Error");
            }
            SQLiteCommand open = new SQLiteCommand();
            open.Connection = db;
            open.CommandText = "SELECT COUNT(cmdName) FROM cmds";
            SQLiteDataReader dr = open.ExecuteReader();
            while (dr.Read())
            {
                count = Convert.ToInt32(dr["COUNT(cmdName)"]);
            }
            db.Close();
            return count;
        }

        public string[] readCmd(int lenght)
        {
            int i = 0;
            string[] cmd = new string[lenght];
            SQLiteConnection db = new SQLiteConnection();
            try
            {
                db.ConnectionString = "Data Source=" + dbPath;
                db.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("There was an ERROR! The error message: \n\n" + ex.ToString(), "Error");
            }
                SQLiteCommand open = new SQLiteCommand();
                open.Connection = db;
                open.CommandText = "SELECT cmdName FROM cmds";  
                SQLiteDataReader dr = open.ExecuteReader();
                while (dr.Read())
                {
                    cmd[i] = dr["cmdName"].ToString();
                    i++;
                }
            db.Close();
            return cmd;
        }

        public int readByte(string cmdName)
        {
            int Byte = 0;
            string Name = cmdName;
            SQLiteConnection db = new SQLiteConnection();
            try
            {
                db.ConnectionString = "Data Source=" + dbPath;
                db.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("There was an ERROR! The error message: \n\n" + ex.ToString(), "Error");
            }
            SQLiteCommand open = new SQLiteCommand();
            open.Connection = db;
            open.CommandText = "SELECT cmdByte FROM cmds WHERE cmdName=\""+Name+"\"";
            SQLiteDataReader dr = open.ExecuteReader();
            while (dr.Read())
            {
                Byte = Convert.ToInt32(dr["cmdByte"]);
            }
            db.Close();
            return Byte;
        }
    }
}
