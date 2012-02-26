using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Parameter
    {

        private string parametername;
        private int parameterorder;
        private int? parametermin;
        private int? parametermax;
        private int? parameterdefault;
        //protected string paramcomment;
        private int? parametervalue;
        private string parametertype;
        

        public string parameterName { get { return this.parametername; } set { this.parametername = value; } }
        public int parameterOrder { get { return this.parameterorder; } set { this.parameterorder = value; } }
        public int? parameterMin { get { return this.parametermin; } set { this.parametermin = value; } }
        public int? parameterMax { get { return this.parametermax; } set { this.parametermax = value; } }
        public int? parameterDefault { get { return this.parameterdefault; } set { this.parameterdefault = value; } }
        //public string paramComment { get { return this.paramcomment; } set { this.paramcomment = value; } }
        public int? parameterValue { get { return this.parametervalue; } set { this.parametervalue = value; } }
        public string parameterType { get { return this.parametertype; } set { this.parametertype = value; } }
    }
}
