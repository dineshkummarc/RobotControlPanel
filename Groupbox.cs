using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Groupbox
    {
        private int groupboxid, groupboxorder;
        private string groupboxname, groupboxcomment, groupboxtype;
        private List<Mode> mode;
        public int groupboxID { get { return this.groupboxid; } set { this.groupboxid = value; } }
        public string groupboxName { get { return this.groupboxname; } set { this.groupboxname = value; } }
        public int groupboxOrder { get { return this.groupboxorder; } set { this.groupboxorder = value; } }
        public string groupboxType { get { return this.groupboxtype; } set { this.groupboxtype = value; } }
        public string groupboxComment { get { return this.groupboxcomment; } set { this.groupboxcomment = value; } }
        public List<Mode> Mode { get { return this.mode; } set { this.mode = value; } }
    }
    class Mode
    {
        private int modeid, modeorder;
        private string modename, modecomment;
        private List<CmdItem> cmditem;
        private List<ParameterItem> parameteritem;
        public int modeID { get { return this.modeid; } set { this.modeid = value; } }
        public string modeName { get { return this.modename; } set { this.modename = value; } }
        public int modeOrder { get { return this.modeorder; } set { this.modeorder = value; } }
        public string modeComment { get { return this.modecomment; } set { this.modecomment = value; } }
        public List<CmdItem> CmdItem { get { return this.cmditem; } set { this.cmditem = value; } }
        public List<ParameterItem> ParameterItem { get { return this.parameteritem; } set { this.parameteritem = value; } }
    }
    class CmdItem
    {
        private int cmditemid, cmditemorder;
        private string cmditemname, cmditemtype, cmditemcomment;
        private Cmd cmd;
        public int cmditemID { get { return this.cmditemid; } set { this.cmditemid = value; } }
        public string cmditemName { get { return this.cmditemname; } set { this.cmditemname = value; } }
        public int cmditemOrder { get { return this.cmditemorder; } set { this.cmditemorder = value; } }
        public string cmditemType { get { return this.cmditemtype; } set { this.cmditemtype = value; } }
        public string cmditemComment { get { return this.cmditemcomment; } set { this.cmditemcomment = value; } }
        public Cmd Cmd { get { return this.cmd; } set { this.cmd = value; } }
    }
    class ParameterItem
    {
        private int parameteritemid, parameteritemorder;
        private string parameteritemname, parameteritemtype, parameteritemcomment;
        private Parameter parameter;
        public int parameteritemID { get { return this.parameteritemid; } set { this.parameteritemid = value; } }
        public string parameteritemName { get { return this.parameteritemname; } set { this.parameteritemname = value; } }
        public int parameteritemOrder { get { return this.parameteritemorder; } set { this.parameteritemorder = value; } }
        public string parameteritemType { get { return this.parameteritemtype; } set { this.parameteritemtype = value; } }
        public string parameteritemComment { get { return this.parameteritemcomment; } set { this.parameteritemcomment = value; } }
        public Parameter Parameter { get { return this.parameter; } set { this.parameter = value; } }
    }
    class Cmd
    {
        private int cmdid, cmdbyte;
        private string cmdname, cmdcomment;
        private List<Parameter> parameterlist;
        public int cmdID { get { return this.cmdid; } set { this.cmdid = value; } }
        public string cmdName { get { return this.cmdname; } set { this.cmdname = value; } }
        public int cmdByte { get { return this.cmdbyte; } set { this.cmdbyte = value; } }
        public string cmdComment { get { return this.cmdcomment; } set { this.cmdcomment = value; } }
        public List<Parameter> parameterList { get { return this.parameterlist; } set { this.parameterlist = value; } }
    }
    class Parameter
    {
        private int parameterid, parameterorder;
        private string parametername, parametercomment;
        private int? parametermin, parametermax, parameterdefault, parametervalue;
        public int parameterID { get { return this.parameterid; } set { this.parameterid = value; } }
        public string parameterName { get { return this.parametername; } set { this.parametername = value; } }
        public int parameterOrder { get { return this.parameterorder; } set { this.parameterorder = value;   } }
        public int? parameterMin { get { return this.parametermin; } set { this.parametermin = value; } }
        public int? parameterMax { get { return this.parametermax; } set { this.parametermax = value; } }
        public int? parameterDefault { get { return this.parameterdefault; } set { this.parameterdefault = value; } }
        public int? parameterValue { get { return this.parametervalue; } set { this.parametervalue = value; } }
        public string parameterComment { get { return this.parametercomment; } set { this.parametercomment = value; } }
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
    class Sign
    {
        private int signid, signbyte;
        private string signname, signcomment;
        public int signID { get { return this.signid; } set { this.signid = value; } }
        public string signName { get { return this.signname; } set { this.signname = value; } }
        public int singByte { get { return this.signbyte; } set { this.signbyte = value; } }
        public string signComment { get { return this.signcomment; } set { this.signcomment = value; } }
    }
    class Settings
    {
        private int settingsid;
        private int? baudrate = null, databits = null, handshake = null, parity = null, parityreplace = null, readbuffersize = null, readtimeout = null, receivedbytesthreshold = null, stopbits = null, writebuffersize = null, writetimeout = null;
        private bool? discardnull = null, dtrenable = null, rtsenable = null;
        private string portname = null;
        public int settingsID { get { return this.settingsid; } set { this.settingsid = value; } }
        public int? baudRate { get { return this.baudrate; } set { this.baudrate = value; } }
        public int? dataBits { get { return this.databits; } set { this.databits = value; } }
        public bool? discardNull { get { return this.discardnull; } set { this.discardnull = value; } }
        public bool? dtrEnable { get { return this.dtrenable; } set { this.dtrenable = value; } }
        public int? handShake { get { return this.handshake; } set { this.handshake = value; } }
        public int? Parity { get { return this.parity; } set { this.parity = value; } }
        public int? parityReplace { get { return this.parityreplace; } set { this.parityreplace = value; } }
        public string portName { get { return this.portname; } set { this.portname = value; } }
        public int? readBufferSize { get { return this.readbuffersize; } set { this.readbuffersize = value; } }
        public int? readTimeOut { get { return this.readtimeout; } set { this.readtimeout = value; } }
        public int? receivedBytesThreshold { get { return this.receivedbytesthreshold; } set { this.receivedbytesthreshold = value; } }
        public bool? rtsEnable { get { return this.rtsenable; } set { this.rtsenable = value; } }
        public int? stopBits { get { return this.stopbits; } set { this.stopbits = value; } }
        public int? writeBufferSize { get { return this.writebuffersize; } set { this.writebuffersize = value; } }
        public int? writeTimeout { get { return this.writetimeout; } set { this.writetimeout = value; } }
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