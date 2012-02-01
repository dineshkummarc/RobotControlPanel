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
        //SetdbPath: Set path of actually used database
        public void SetdbPath(string dbPath)
        {
            this.dbPath = dbPath;
        }
        //countCmd: Return the number of commands
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
        //readCmd: Return the list of commands
        public List<Cmd> readCmds()
        {
            int i = 0;
            List<Cmd> cmdList = new List<Cmd>();
            
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
                open.CommandText = "SELECT cmdID, cmdName, cmdByte, cmdComment FROM cmds"; 


                SQLiteDataReader dr = open.ExecuteReader();
                while (dr.Read())
                {
                    cmdList.Add(new Cmd());
                    cmdList[i].cmdID = Convert.ToInt32(dr["cmdID"]);
                    cmdList[i].cmdName = dr["cmdName"].ToString();
                    cmdList[i].cmdByte = Convert.ToInt32(dr["cmdByte"]);
                    cmdList[i].cmdComment = dr["cmdComment"].ToString();
                    cmdList[i].parameterList = new List<Parameter>();
                    //Parameter-reader SQL command
                    SQLiteCommand parameters = new SQLiteCommand();
                    parameters.Connection = db;
                    parameters.CommandText = "SELECT paramName, paramMin, paramMax, paramDefault, paramComment FROM params WHERE cmdID=" + cmdList[i].cmdID;
                    SQLiteDataReader param = parameters.ExecuteReader();
                    int j = 0;
                    while (param.Read())
                    {
                        
                        //cmdList[i].AddParameter();
                        cmdList[i].parameterList.Add(new Parameter());
                        cmdList[i].parameterList[j].paramName = param["paramName"].ToString();

                        try { cmdList[i].parameterList[j].paramMin = Convert.ToInt32(param["paramMin"]); }
                        catch (System.InvalidCastException) { cmdList[i].parameterList[j].paramMin = null; }

                        try { cmdList[i].parameterList[j].paramMax = Convert.ToInt32(param["paramMax"]); }
                        catch (System.InvalidCastException) { cmdList[i].parameterList[j].paramMax = null; }

                        try { cmdList[i].parameterList[j].paramDefault = Convert.ToInt32(param["paramDefault"]); } 
                        catch (System.InvalidCastException) { cmdList[i].parameterList[j].paramDefault = null; } 
                       
                        cmdList[i].parameterList[j].paramComment = param["paramComment"].ToString();
                        j++;
                    }
                    i++;
                }
            db.Close();
            return cmdList;
        }
        //readByte: Return a byte belong to a command
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
        //readParameters: Return a list of parameters, which are belong to a command
        public List<Parameter> readParameters()
        {
            List<Parameter> paramList = new List<Parameter>();

            return paramList;
        }
    }
}
