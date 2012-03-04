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
        public List<CmdGroup> cmdGroupFetcher()
        {
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
            int i = 0; while (dr_gbn.Read())            
            {
                cmdGroupList.Add(new CmdGroup());
                cmdGroupList[i].groupboxName = dr_gbn["groupboxName"].ToString();
                cmdGroupList[i].cmdList = new List<Cmd>();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection=db;
                cmd.CommandText= "SELECT manifestType, manifestID, cmdName, cmdByte FROM manifest, cmds where manifest.[manifestID] IN (SELECT manifestID FROM groupboxes_manifest WHERE groupboxes_manifest.[groupboxID]=(SELECT groupboxID FROM groupboxes WHERE groupboxes.[groupboxName]=\""+cmdGroupList[i].groupboxName+"\")) AND cmds.[cmdID]=manifest.[cmdID]";
                SQLiteDataReader dr_cmd=cmd.ExecuteReader();
                int j = 0;
                while(dr_cmd.Read())
                {
                cmdGroupList[i].cmdList.Add(new Cmd());
                cmdGroupList[i].cmdList[j].cmdName = dr_cmd["cmdName"].ToString();
                cmdGroupList[i].cmdList[j].cmdType = dr_cmd["manifestType"].ToString();
                cmdGroupList[i].cmdList[j].cmdByte = Convert.ToInt32(dr_cmd["cmdByte"]);
                
                cmdGroupList[i].cmdList[j].parameterList = new List<Parameter>();
                SQLiteCommand p = new SQLiteCommand();
                p.Connection = db;
                p.CommandText = "SELECT parameterName, parameterMin, parameterMax, parameterDefault, parameters_cmdsOrder, manifest_parametersValue, manifest_parametersType FROM parameters_cmds, parameters, manifest_parameters WHERE parameters.[parameterID]=parameters_cmds.[parameterID] AND parameters_cmds.[cmdID]=(select cmdID FROM manifest WHERE manifest.[manifestID]=" + dr_cmd["manifestID"].ToString() + ") AND manifest_parameters.[parameter_cmdsID]=parameters_cmds.[parameters_cmdsID] AND manifest_parameters.[manifestID]=" + dr_cmd["manifestID"].ToString();
                SQLiteDataReader dr_p = p.ExecuteReader();
                int k = 0; while (dr_p.Read())
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
        public List<Controlbox> controlBoxFetcher()
        {
            List<Controlbox> controlBoxList = new List<Controlbox>();
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
            SQLiteCommand cbn = new SQLiteCommand();
            cbn.Connection = db;
            cbn.CommandText = "SELECT groupboxName, groupboxID FROM groupboxes WHERE groupboxes.[groupboxID] IN (SELECT groupboxID FROM controlmode)";
            SQLiteDataReader dr_cbn = cbn.ExecuteReader();
            int i = 0; while (dr_cbn.Read())
            {
                controlBoxList.Add(new Controlbox());
                controlBoxList[i].controlboxName = dr_cbn["groupboxName"].ToString();
                controlBoxList[i].Modes = new List<ControlboxMode>();
                SQLiteCommand mds = new SQLiteCommand();
                mds.Connection = db;
                mds.CommandText = "select * from controlmode where controlmode.[groupboxID]="+dr_cbn["groupboxID"].ToString();
                SQLiteDataReader dr_mds = mds.ExecuteReader();
                int j = 0; while (dr_mds.Read())
                {
                    controlBoxList[i].Modes.Add(new ControlboxMode());
                    controlBoxList[i].Modes[j].controlboxModeName = dr_mds["controlmodeName"].ToString();
                    controlBoxList[i].Modes[j].controlboxModeOrder = Convert.ToInt32(dr_mds["controlmodeOrder"]);
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = db;
                    cmd.CommandText = "SELECT cmdName, cmdByte, manifestType FROM manifest, cmds WHERE manifest.[manifestID]="+dr_mds["controlmodeUp"].ToString()+" AND cmds.[cmdID]=manifest.[cmdID]";
                    SQLiteDataReader dr_cmd = cmd.ExecuteReader();
                    while (dr_cmd.Read())
                    {
                        controlBoxList[i].Modes[j].Up.cmdName = dr_cmd["cmdName"].ToString();
                        controlBoxList[i].Modes[j].Up.cmdByte = Convert.ToInt32(dr_cmd["cmdByte"]);
                        controlBoxList[i].Modes[j].Up.cmdType = dr_cmd["manifestType"].ToString();
                        controlBoxList[i].Modes[j].Up.parameterList = new List<Parameter>();
                        //TODO: meg kellene csinálni h az up, down, left, right gombokra kötött parancsok és azok paraméterlistája beolvasásra kerüljön, lehetőleg a fenti kód ciklikus használatával
                        //valamint átnézni az eddigi sql-parancsokat, mert szerintem bőven lehet egyszerűsíteni, egységesíteni a változóelnevezést, plussz, ha lehet átvezetni az adatbázisba is.
                        //Csak már vasárnap késő délután van és nincs hozzá kedvem...
                    }
                    j++;
                }
                i++;
            }

            return controlBoxList;
        }
    }
}