using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    public class UtilRotate
    {
        public static float newRotateNumber(float x)
        {
            if (x > 360) {
                return x - 360;
            } else if (x < 0) {
                return x + 360;
            }
            
            return x;
        }

        public static int compareRotationg(float x, float y)
        {
            if (x - 180 < y - 180)
            {
                return -1;
            } else if (x - 180 > y - 180)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
    }

    
}
