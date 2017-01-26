using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GQLib.Pattern_Characteristics
{
    class BulletMovement
    {
        protected float startSpeed;
        protected float acceleration;

        public float getStartSpeed()
        {
            return startSpeed;
        }

        public float getAcceleration()
        {
            return acceleration;
        }
    }

    class PolarBulletMovement : BulletMovement
    {
        float angleChange;

        public PolarBulletMovement(float startSpeed, float acceleration, Vector2 spawnPosition, float angleChange)
        {
            this.startSpeed = startSpeed;
            this.acceleration = acceleration;
            this.angleChange = angleChange;
        }

        public float getAngleChange()
        {
            return angleChange;
        }
    }

    class LinearBulletMovement : BulletMovement
    {
        public LinearBulletMovement(float startSpeed, float acceleration, Vector2 spawnPosition)
        {
            this.startSpeed = startSpeed;
            this.acceleration = acceleration;
        }
    }
}
