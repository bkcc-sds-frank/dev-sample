using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSample.ClassRefactoring
{
    public abstract class SwallowBase
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public SwallowBase()
        {

        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public abstract double GetAirspeedVelocity();
    }

}
