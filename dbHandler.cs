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

        public void SetParams(string dbPath)
        {
            this.dbPath = dbPath;
        }
        public void readCmds()
        {
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
                open.CommandText = "SELECT * FROM cmds";  
                SQLiteDataReader dr = open.ExecuteReader();
                while (dr.Read())
                {
                }
            db.Close();
        }
    }

}
