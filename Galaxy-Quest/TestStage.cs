using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GQLib;


namespace Galaxy_Quest
{
    class TestStage : IState
    {
        private Player player; 
        public TestStage(ContentManager content)
        {
            LoadContent(content);
            //Load stuff thats static
        }

        public void LoadContent(ContentManager Content)
        {
            //Load gfX
            player = new Player(new Vector2(100, 100), "testplayer", new Vector4(0,0,0,0), Content); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw stuff
            player.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            //update Stuff
            player.Update(gameTime);
        }
    }
}
