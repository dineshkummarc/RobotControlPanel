using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Groupbox
    {
        protected int groupboxid, groupboxorder;
        protected string groupboxname;

        public int groupboxID { get { return this.groupboxid; } set { this.groupboxid = value; } }
        public string groupboxName { get { return this.groupboxname; } set { this.groupboxname = value; } }
        public int groupboxOrder { get { return this.groupboxorder; } set { this.groupboxorder = value; } }
    }
    class CmdGroup : Groupbox
    {
        private List<Cmd> cmdlist;
        public List<Cmd> cmdList { get { return this.cmdlist; } set { this.cmdlist = value; } }

    }
    class Controlbox : Groupbox
    {
        private List<ControlboxMode> modes;
        public List<ControlboxMode> Modes { get { return this.modes; } set { this.modes = value; } }
    }
    class ControlboxMode
    {
        private int controlboxmodeid;
        private string conttrolboxmodename, controlboxmodecomment;
        private int controlboxmodeorder;
        private Cmd up, down, left, right, stop;

        public int controlboxModeID { get { return this.controlboxmodeid; } set { this.controlboxmodeid = value; } }
        public string controlboxModeName { get { return this.conttrolboxmodename; } set { this.conttrolboxmodename = value; } }
        public int controlboxModeOrder { get { return this.controlboxmodeorder; } set { this.controlboxmodeorder = value; } }
        public Cmd Up { get { return this.up; } set { this.up = value; } }
        public Cmd Down { get { return this.down; } set { this.down = value; } }
        public Cmd Left { get { return this.left; } set { this.left = value; } }
        public Cmd Right { get { return this.right; } set { this.right = value; } }
        public Cmd Stop { get { return this.stop; } set { this.stop = value; } }
        public string controlBoxModeComment { get { return this.controlboxmodecomment; } set { this.controlboxmodecomment = value; } }
    }
    class CmdUnit
    {
        protected int id, value;
        protected string name, comment;
    }
    class Cmd : CmdUnit
    {
        private string cmdtype;
        private List<Parameter> parameterlist;

        public int cmdID { get { return this.id; } set { this.id = value; } }
        public string cmdName { get { return this.name; } set { this.name = value; } }
        public string cmdType { get { return this.cmdtype; } set { this.cmdtype = value; } }
        public int cmdByte { get { return this.value; } set { this.value = value; } }
        public string manifestComment { get { return this.comment; } set { this.comment = value; } }
        public List<Parameter> parameterList { get { return this.parameterlist; } set { this.parameterlist = value; } }
    }
    class Sign : CmdUnit
    {
        public int signID { get { return this.id; } set { this.id = value; } }
        public string signName { get { return this.name; } set { this.name = value; } }
        public int singByte { get { return this.value; } set { this.value = value; } }
        public string signComment { get { return this.comment; } set { this.comment = value; } }
    }
    class Syntax
    {
        private int syntaxid, syntaxorder;
        private string syntaxtype;
        private Sign sign;

        public int syntaxID { get { return this.syntaxid; } set { this.syntaxid = value; } }
        public int syntaxOrder { get { return this.syntaxorder; } set { this.syntaxorder = value; } }
        public string syntaxType { get { return this.syntaxtype; } set { this.syntaxtype = value; } }
        public Sign Sign { get { return this.sign; } set { this.sign = value; } }
    }
    class Parameter
    {
        private string parametername, parametertype, manifest_parametercomment;
        private int parameterid, parameterorder;
        private int? parametermin, parametermax, parameterdefault, parametervalue;

        public int parameterID { get { return this.parameterid; } set { this.parameterid = value; } }
        public string parameterName { get { return this.parametername; } set { this.parametername = value; } }
        public int parameterOrder { get { return this.parameterorder; } set { this.parameterorder = value; } }
        public int? parameterMin { get { return this.parametermin; } set { this.parametermin = value; } }
        public int? parameterMax { get { return this.parametermax; } set { this.parametermax = value; } }
        public int? parameterDefault { get { return this.parameterdefault; } set { this.parameterdefault = value; } }
        public string manifest_parameterComment { get { return this.manifest_parametercomment; } set { this.manifest_parametercomment = value; } }
        public int? parameterValue { get { return this.parametervalue; } set { this.parametervalue = value; } }
        public string parameterType { get { return this.parametertype; } set { this.parametertype = value; } }
    }
    class Metadata
    {
        private int metadataid;
        private string metadatafield, metadatavalue;

        public int metadataID { get { return this.metadataid; } set { this.metadataid = value; } }
        public string metadataField { get { return this.metadatafield; } set { this.metadatafield = value; } }
        public string metadataValue { get { return this.metadatavalue; } set { this.metadatavalue = value; } }
    }
}