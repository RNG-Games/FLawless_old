using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Content;
using FLLib;

namespace FLawless
{
    internal class G
    {
        //Add stuff here
        static G instance;
        public EState current;
        public SpriteFont font;
        public MainMenu mainMenu;
        public PlayState playState;

        public G()
        {
        }

        public static G Instance
        {
            get
            {
                if (instance == null) instance = new G();
                return instance;
            }
            set
            {
            }
        }
    }
}