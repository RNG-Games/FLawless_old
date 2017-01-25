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
    class PlayState : IState
    {
        private TestStage testStage;
        private bool activateTest;

        public PlayState(ContentManager content, int state = 0)
        {
            if (state == -1)
            {
                testStage = new TestStage(content);
                activateTest = true;
            }
            else
            {
                activateTest = false;
                LoadContent(content);
            } 
        }

        public void LoadContent(ContentManager Content)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //TODO PlayerDraw
            if (activateTest)
            {
                testStage.Draw(spriteBatch);
            } else
            {

            }
        }

        public void Update(GameTime gameTime)
        {
            //TODO: PlayerControl
            if (activateTest)
            {
                testStage.Update(gameTime);
            } else
            {

            }
        }
    }
}
