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
        public TestStage(ContentManager content)
        {
            LoadContent(content);
            //Load stuff thats static
        }

        public void LoadContent(ContentManager Content)
        {
            //Load gfX
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw stuff
        }

        public void Update(GameTime gameTime)
        {
            //update Stuff
        }
    }
}
