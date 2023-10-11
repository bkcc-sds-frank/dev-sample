using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSample.ClassRefactoring
{
    public static class SwallowFactory
    {
        public static SwallowBase CreateSwallow(SwallowType swallowType)
        {
            switch(swallowType) 
            {
                case SwallowType.African: return new SwallowAfrican();
                case SwallowType.European: return new SwallowEuropean();
                default: throw new ArgumentException($"Could not create swallow of type {swallowType}");
            } 
        }
    }
}
