using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Parameter
    {
        protected string paramname;
        protected int? parammin;
        protected int? parammax;
        protected int? paramdefault;
        protected string paramcomment;

        public string paramName { get { return this.paramname; } set { this.paramname = value; } }
        public int? paramMin { get { return this.parammin; } set { this.parammin = value; } }
        public int? paramMax { get { return this.parammax; } set { this.parammax = value; } }
        public int? paramDefault { get { return this.paramdefault; } set { this.paramdefault = value; } }
        public string paramComment { get { return this.paramcomment; } set { this.paramcomment = value; } }
    }
}
