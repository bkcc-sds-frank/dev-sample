﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSample.ClassRefactoring
{
    public class SwallowAfrican : SwallowBase
    {
        public SwallowAfrican()
        {
            AirspeedLoadMap.TryAdd(SwallowLoad.None, 22);
            AirspeedLoadMap.TryAdd(SwallowLoad.Coconut, 18);
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
