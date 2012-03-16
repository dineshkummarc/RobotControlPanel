using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Settings
    {
        private int? baudrate = null, 
            databits = null, 
            handshake = null, 
            parity = null, 
            parityreplace = null, 
            readbuffersize = null,
            readtimeout = null, 
            receivedbytesthreshold = null, 
            stopbits = null, 
            writebuffersize = null, 
            writetimeout = null;
        private bool? discardnull=null,
            dtrenable = null,
            rtsenable = null;
        private string portname=null;

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
}
