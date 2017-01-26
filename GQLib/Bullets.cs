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
    abstract class Bullets
    {
        //existence attributes
        protected bool alive;

        //type attributes
        protected int type;

        //graphic attributes
        protected Texture2D texture;
        protected Color color;
        protected float rotation;
        protected float grScale;

        //position attributes
        protected Vector2 position;

        //movement attributes
        protected float speed;

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);

        public Vector2 getPosition()
        {
            return position;
        }

        public bool getAlive()
        {
            return alive;
        }
    }

    class PolarBullet : Bullets
    {
        //position attributes
        private Vector2 spawnPosition;
        private float radius;
        private float angle;

        //movement attributes
        private PolarBulletMovement movement;

        //constructor
        public PolarBullet(int type, PolarBulletMovement movement, Vector2 spawnPosition, float angle, String texturePath, ContentManager Content)
        {
            this.type = type;
            this.movement = movement;
            this.spawnPosition = spawnPosition;
            this.angle = angle;
            radius = 0;
            position = spawnPosition;
            speed = movement.getStartSpeed();

            texture = Content.Load<Texture2D>(texturePath);
            grScale = 1.0f;
            alive = true;
        }

        //update
        public override void Update()
        {
            radius += speed / 100f;
            angle += movement.getAngleChange() / 100f;
            speed += movement.getAcceleration() / 100f;
            Maths.toCartesian(ref position, spawnPosition, angle, radius);
            //Rectangle hitbox = new Rectangle((int)position.X + 5, (int)position.Y + 5, (int)(texture.Width * grScale * GameStuff.Instance.grScale - 5), (int)(texture.Height * grScale * GameStuff.Instance.grScale - 5));
            //if (GameStuff.Instance.player.checkHit(hitbox) == true) { GameStuff.Instance.player.applyDamage(5); alive = false; }
        }

        //draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture: texture, position: position, origin: null, rotation: 0.0f, scale: new Vector2((grScale * GameStuff.Instance.grScale), (grScale * GameStuff.Instance.grScale)), color: color);
        }
    }
}
