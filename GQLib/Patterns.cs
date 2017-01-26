using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using GQLib.Pattern_Characteristics;

namespace GQLib
{
    abstract class Patterns
    {
        //attributes
        protected int bulletType;
        
        //help attributes
        protected List<Bullets> Pattern = new List<Bullets>();

        //monogame
        protected String path;
        protected ContentManager Content;

        public virtual void Update()
        {
            for (int i = Pattern.Count - 1; i >= 0; i--)
            {
                if (Pattern[i].getPosition().X > 1000 || Pattern[i].getPosition().X < -100 || Pattern[i].getPosition().Y > 700 || Pattern[i].getPosition().Y < -100)
                {
                    //if (Pattern[i].getPosition().Y >= 370) GameStuff.Instance.score += 10;
                    Pattern.RemoveAt(i);
                }
                else if (Pattern[i].getAlive() == false) { Pattern.RemoveAt(i); }
                else { Pattern[i].Update(); }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullets i in Pattern)
            {
                i.Draw(spriteBatch);
            }
        }
    }

    abstract class PolarPatterns : Patterns
    {
        protected Vector2 spawnPosition;
        protected int numberOfBullets;
        protected PolarBulletMovement bulletMovement;
    }

    class SpiralPatterns : PolarPatterns
    {
        SpawnBehaviour spawnBehaviour;
        int counter;
        int timer;
        float angle;

        public SpiralPatterns (int bulletType, PolarBulletMovement bulletMovement, Vector2 spawnPosition, int numberOfBullets, SpawnBehaviour spawnBehaviour)
        {
            this.bulletType = bulletType;
            this.bulletMovement = bulletMovement;
            this.spawnPosition = spawnPosition;
            this.numberOfBullets = numberOfBullets;
            this.spawnBehaviour = spawnBehaviour;

            counter = numberOfBullets;
            timer = 0;
            angle = spawnBehaviour.getStartAngle();
        }

        public override void Update()
        {
            base.Update();

            if ((timer % spawnBehaviour.getInterval() == 0) && (counter > 0))
            {
                Pattern.Add(new PolarBullet(bulletType, bulletMovement, spawnPosition, angle, path, Content));
                counter++;
                angle = angle + spawnBehaviour.getRotation();
            }

            timer++;
        }
    }

    class CirclePatterns : PolarPatterns
    {
        public CirclePatterns (int bulletType, PolarBulletMovement bulletMovement, Vector2 spawnPosition, int numberOfBullets)
        {
            this.bulletType = bulletType;
            this.bulletMovement = bulletMovement;
            this.spawnPosition = spawnPosition;
            this.numberOfBullets = numberOfBullets;
            spawnPattern();
        }

        private void spawnPattern()
        {
            float angle = 360 / numberOfBullets;

            for (int i = 0; i < numberOfBullets; i++)
            {
                Pattern.Add(new PolarBullet(bulletType, bulletMovement, spawnPosition, angle * i, path, Content));
            }
        }
    }
}
