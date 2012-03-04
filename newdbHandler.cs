using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace RobotControlPanel
{
    class newdbHandler
    {
        private string dbPath;
        //SetdbPath: Set path of actually used database
        public void SetdbPath(string dbPath)
        {
            this.dbPath = dbPath;
        }
        private List<string> dbReader(string cmdstring, string field)
        {
            List<string> r = new List<string>();            
            SQLiteConnection db = new SQLiteConnection();
            try
            {
                db.ConnectionString = @"Data Source=" + dbPath;
                db.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = db;
            cmd.CommandText = cmdstring;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                r.Add((dr[field]).ToString());
            }
            db.Close();
            return r;
        }
        private string dbReader(string cmdstring, string con, string field)
        {
            string r =string.Empty;
            SQLiteConnection db = new SQLiteConnection();
            try
            {
                db.ConnectionString = @"Data Source=" + dbPath;
                db.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = db;
            cmd.CommandText = cmdstring+con;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                r = (dr[field]).ToString();
            }
            db.Close();
            return r;
        }
        public List<CmdGroup> readGroupbox()
        {
            List<CmdGroup> groupboxList = new List<CmdGroup>();
            int i = 0;
            foreach (string groupboxID in dbReader(Cmdstring.normalgroupboxes, "groupboxID"))
            {
                groupboxList.Add(new CmdGroup());
                groupboxList[i].groupboxID = Convert.ToInt32(groupboxID);
                groupboxList[i].groupboxName = dbReader(Cmdstring.groupboxname, groupboxID, "groupboxName").ToString();
                groupboxList[i].cmdList = new List<Cmd>();
                int j = 0;
                foreach (string manifestID in dbReader(Cmdstring.manifestid+groupboxID, "manifestID"))
                {
                    groupboxList[i].cmdList.Add(new Cmd());
                    string cmdid = (groupboxList[i].cmdList[j].cmdID=Convert.ToInt32(dbReader(Cmdstring.cmdid, manifestID, "cmdID"))).ToString();
                    groupboxList[i].cmdList[j].cmdName = dbReader(Cmdstring.cmdname, cmdid, "cmdName");
                    groupboxList[i].cmdList[j].cmdByte = Convert.ToInt32(dbReader(Cmdstring.cmdbyte , cmdid, "cmdByte"));
                    groupboxList[i].cmdList[j].cmdType = dbReader(Cmdstring.manifesttype, manifestID, "manifestType");
                    groupboxList[i].cmdList[j].parameterList = new List<Parameter>();
                    int k = 0;
                    foreach (string parameters_cmdsID in dbReader(Cmdstring.parameters_cmdsid + cmdid, "parameters_cmdsID"))
                    {
                        groupboxList[i].cmdList[j].parameterList.Add(new Parameter());
                        string parameterid = (groupboxList[i].cmdList[j].parameterList[k].parameterID = Convert.ToInt32(dbReader(Cmdstring.parameterid,parameters_cmdsID, "parameterID"))).ToString();
                        groupboxList[i].cmdList[j].parameterList[k].parameterName=dbReader(Cmdstring.parametername,parameterid,"parameterName");
                        groupboxList[i].cmdList[j].parameterList[k].parameterOrder=Convert.ToInt32(dbReader(Cmdstring.parameters_cmdsorder,parameters_cmdsID,"parameters_cmdsOrder"));
                        string m = dbReader(Cmdstring.parametermin, parameterid, "parameterMin");
                        if (m.Length == 0) { groupboxList[i].cmdList[j].parameterList[k].parameterMin = null; } else { groupboxList[i].cmdList[j].parameterList[k].parameterMin = Convert.ToInt32(m); }
                        m = dbReader(Cmdstring.parametermax, parameterid, "parameterMax");
                        if (m.Length == 0) { groupboxList[i].cmdList[j].parameterList[k].parameterMax = null; } else { groupboxList[i].cmdList[j].parameterList[k].parameterMax = Convert.ToInt32(m); }
                        m = dbReader(Cmdstring.parameterdefault, parameterid, "parameterDefault");
                        if (m.Length == 0) { groupboxList[i].cmdList[j].parameterList[k].parameterDefault = null; } else { groupboxList[i].cmdList[j].parameterList[k].parameterDefault = Convert.ToInt32(m); }
                        m = dbReader(Cmdstring.manifest_parametersvalue + manifestID + " AND parameter_cmdsID=", parameters_cmdsID, "manifest_parametersValue");
                        if (m.Length == 0) { groupboxList[i].cmdList[j].parameterList[k].parameterValue = null; } else { groupboxList[i].cmdList[j].parameterList[k].parameterValue = Convert.ToInt32(m); }                        
                        groupboxList[i].cmdList[j].parameterList[k].parameterType = dbReader(Cmdstring.manifest_parameterstype + manifestID + " AND parameter_cmdsID=", parameters_cmdsID, "manifest_parametersType");
                        k++;
                    }                   
                    j++;
                }                                          
                i++;
            }
            return groupboxList;
        }
    }
}