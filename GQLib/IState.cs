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
    enum EState
    {
        None,
        MainMenu,
        PlayState,
        Death,
        Pause,
        Edit
    }
    public interface IState
    {
        void LoadContent(ContentManager Content);

        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);
    }
}
