using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicad.Model.Utils
{
    public static class Functions
    {
        // tried generics, but this doesn't work properly
        public static float InRange(float val, float min, float max)
        {
            return val > max ? max : (val < min ? min : val);
        }

        public static double InRange(double val, double min, double max)
        {
            return val > max ? max : (val < min ? min : val);
        }

        public static int InRange(int val, int min, int max)
        {
            return val > max ? max : (val < min ? min : val);
        }
    }
}
