using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GQLib
{
    abstract class Bullets
    {
        //bullet type attributes
        protected int type;
        protected Texture2D texture;
        protected Color color;

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
    }

    class PolarBullet : Bullets
    {
        //behaviour

        //graphic attributes
        private float rotation;
        private float grScale;
        private Texture2D texture;

        //movement attributes
        private float speed;
        private float angleChange;
        private float acceleration;

        //position attributes
        private Vector2 centrePosition;
        private float radius;
        private float angle;
        Vector2 position = new Vector2();

        private bool alive = true;
        //constructor
        public PolarBullet(int bulletType, String texturePath, float bulletSpeed, float bulletAngleChange, float bulletAcceleration, Vector2 bulletCentrePosition, float bulletStartAngle, ContentManager Content)
        {
            type = bulletType;
            rotation = bulletStartAngle;
            grScale = 1.0f;
            speed = bulletSpeed;
            angleChange = bulletAngleChange;
            acceleration = bulletAcceleration;
            centrePosition = bulletCentrePosition;
            radius = 0;
            angle = bulletStartAngle;
            texture = Content.Load<Texture2D>(texturePath);
            //bullet type settings
            switch (type)
            {

            }
        }

        //update
        public override void Update()
        {
            radius += speed / 100f;
            angle += angleChange / 100f;
            speed += acceleration / 100f;
            Maths.toCartesian(ref position, centrePosition, angle, radius);
            //Rectangle hitbox = new Rectangle((int)position.X + 5, (int)position.Y + 5, (int)(texture.Width * grScale * GameStuff.Instance.grScale - 5), (int)(texture.Height * grScale * GameStuff.Instance.grScale - 5));
            //if (GameStuff.Instance.player.checkHit(hitbox) == true) { GameStuff.Instance.player.applyDamage(5); alive = false; }
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public bool getAlive()
        {
            return alive;
        }

        //draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture: texture, position: position, origin: null, rotation: 0.0f, scale: new Vector2((grScale * GameStuff.Instance.grScale), (grScale * GameStuff.Instance.grScale)), color: color);
        }
    }
}
