using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Qcparameter
    {
        private int qcparamid;
        private int qcparamvalue;

        public int qcParamID {get {return this.qcparamid;} set {this.qcparamid= value;}}
        public int qcParamValue { get { return this.qcparamvalue; } set { this.qcparamvalue = value; } }
    }
}
