using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSample.ClassRefactoring
{
    public class SwallowEuropean : SwallowBase
    {
        public SwallowEuropean()
        {
            AirspeedLoadMap.TryAdd(SwallowLoad.None, 20);
            AirspeedLoadMap.TryAdd(SwallowLoad.Coconut, 16);
        }

        private Dictionary<SwallowLoad, double> AirspeedLoadMap = new Dictionary<SwallowLoad, double>();

        public override double GetAirspeedVelocity()
        {
            if (this.Load == SwallowLoad.None)
            {
                return AirspeedLoadMap[SwallowLoad.None];
            }
            else
            {
                if (!AirspeedLoadMap.TryGetValue(this.Load, out double outAirspeed))
                {
                    //should not happen since load is enum
                    throw new ArgumentOutOfRangeException($"Cannot find airspeed for load {this.Load}.");
                }
                return outAirspeed;
            }            
        }
    }
}
