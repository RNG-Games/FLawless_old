using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using GQLib;

namespace GQSEdit
{
    class Edit : IState
    {
        private string location;
        private Texture2D bg;

        public Edit(ContentManager Content, string location)
        {
            this.location = location;
            if (!Directory.Exists(location)) Directory.CreateDirectory(location);

            LoadContent(Content);
        }

        public void LoadContent(ContentManager Content)
        {
            bg = Content.Load<Texture2D>("editor_bg");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, new Vector2(0), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
