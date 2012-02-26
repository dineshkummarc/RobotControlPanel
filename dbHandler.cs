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
        //cmdFetcher: Return the list of groupboxes
        public List<CmdGroup> cmdFetcher()
        {
            int i = 0;
            List<CmdGroup> cmdGroupList = new List<CmdGroup>();
            SQLiteConnection db = new SQLiteConnection();
            try
            {
                db.ConnectionString = @"Data Source=" + dbPath;
                db.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("There was an ERROR! The error message: \n\n" + ex.ToString(), "Error");
            }
            SQLiteCommand gbn = new SQLiteCommand();
            gbn.Connection = db;
            gbn.CommandText = "SELECT DISTINCT groupboxName FROM groupboxes,groupboxes_manifest WHERE groupboxes.[groupboxID]=groupboxes_manifest.[groupboxID];";
            SQLiteDataReader dr_gbn = gbn.ExecuteReader();
            while (dr_gbn.Read())
            {
                cmdGroupList.Add(new CmdGroup());
                cmdGroupList[i].cmdGroupName = dr_gbn["groupboxName"].ToString();
                cmdGroupList[i].cmdList = new List<Cmd>();
                int j = 0;
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection=db;
                cmd.CommandText= "SELECT manifestType, manifestID, cmdName, cmdByte FROM manifest, cmds where manifest.[manifestID] IN (SELECT manifestID FROM groupboxes_manifest WHERE groupboxes_manifest.[groupboxID]=(SELECT groupboxID FROM groupboxes WHERE groupboxes.[groupboxName]=\""+cmdGroupList[i].cmdGroupName+"\")) AND cmds.[cmdID]=manifest.[cmdID]";
                SQLiteDataReader dr_cmd=cmd.ExecuteReader();
                while(dr_cmd.Read())
                {
                cmdGroupList[i].cmdList.Add(new Cmd());
                cmdGroupList[i].cmdList[j].cmdName = dr_cmd["cmdName"].ToString();
                cmdGroupList[i].cmdList[j].cmdType = dr_cmd["manifestType"].ToString();
                cmdGroupList[i].cmdList[j].cmdByte = Convert.ToInt32(dr_cmd["cmdByte"]);
                
                cmdGroupList[i].cmdList[j].parameterList = new List<Parameter>();
                int k = 0;
                SQLiteCommand p = new SQLiteCommand();
                p.Connection = db;
                p.CommandText = "SELECT parameterName, parameterMin, parameterMax, parameterDefault, parameters_cmdsOrder, manifest_parametersValue, manifest_parametersType FROM parameters_cmds, parameters, manifest_parameters WHERE parameters.[parameterID]=parameters_cmds.[parameterID] AND parameters_cmds.[cmdID]=(select cmdID FROM manifest WHERE manifest.[manifestID]=" + dr_cmd["manifestID"].ToString() + ") AND manifest_parameters.[parameter_cmdsID]=parameters_cmds.[parameters_cmdsID] AND manifest_parameters.[manifestID]=" + dr_cmd["manifestID"].ToString();
                SQLiteDataReader dr_p = p.ExecuteReader();
                while (dr_p.Read())
                    {
                        cmdGroupList[i].cmdList[j].parameterList.Add(new Parameter());
                        cmdGroupList[i].cmdList[j].parameterList[k].parameterName = dr_p["parameterName"].ToString();
                        cmdGroupList[i].cmdList[j].parameterList[k].parameterType= dr_p["manifest_parametersType"].ToString();
                        try {cmdGroupList[i].cmdList[j].parameterList[k].parameterValue = Convert.ToInt32(dr_p["manifest_parametersValue"]);} 
                        catch(System.InvalidCastException) {cmdGroupList[i].cmdList[j].parameterList[k].parameterValue=null;}
                        try {cmdGroupList[i].cmdList[j].parameterList[k].parameterMin = Convert.ToInt32(dr_p["parameterMin"]);} 
                        catch(System.InvalidCastException) {cmdGroupList[i].cmdList[j].parameterList[k].parameterMin=null;}
                        try {cmdGroupList[i].cmdList[j].parameterList[k].parameterMax = Convert.ToInt32(dr_p["parameterMax"]);} 
                        catch(System.InvalidCastException) {cmdGroupList[i].cmdList[j].parameterList[k].parameterMax=null;}
                        try { cmdGroupList[i].cmdList[j].parameterList[k].parameterDefault = Convert.ToInt32(dr_p["parameterDefault"]); }
                        catch (System.InvalidCastException) { cmdGroupList[i].cmdList[j].parameterList[k].parameterDefault = null; }
                        cmdGroupList[i].cmdList[j].parameterList[k].parameterOrder = Convert.ToInt32(dr_p["parameters_cmdsOrder"]);
                        k++;
                    }
                j++;
                }
                i++;
            }
            db.Close();
            return cmdGroupList;
        }
    }
}