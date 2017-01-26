using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GQLib.Pattern_Characteristics
{
    class SpawnBehaviour
    {
        float rotation;
        int interval;
        float startAngle;

        public SpawnBehaviour(float rotation, int interval, int startAngle)
        {
            this.rotation = rotation;
            this.interval = interval;
            this.startAngle = startAngle;
        }

        public float getRotation()
        {
            return rotation;
        }

        public int getInterval()
        {
            return interval;
        }

        public float getStartAngle()
        {
            return startAngle;
        }
    }
}
