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
    public class Player
    {
        public Vector2 position { get; private set; }
        private Vector4 screenBorders;
        private Texture2D texture;
        private int speed = 5;

        public Player(Vector2 position, string texturePath, Vector4 screenBorders, ContentManager Content)
        {
            this.position = position;
            this.screenBorders = screenBorders;
            texture = Content.Load<Texture2D>(texturePath);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Keyboard State auslesen
            KeyboardState key = Keyboard.GetState();
            //Vector der aktuell auszuführenden Bewegung --> Kann leichter durch Kollision geblockt werden
            Vector2 move = new Vector2(0, 0);
            //Keyboard State auswerten
            if (key.IsKeyDown(Keys.Left) || key.IsKeyDown(Keys.A)) move.X -= speed;
            if (key.IsKeyDown(Keys.Right) || key.IsKeyDown(Keys.D)) move.X += speed;
            if (key.IsKeyDown(Keys.Up) || key.IsKeyDown(Keys.W)) move.Y -= speed;
            if (key.IsKeyDown(Keys.Down) || key.IsKeyDown(Keys.S)) move.Y += speed;
            position += move;
        }
    }
}
