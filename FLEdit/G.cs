using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna;

namespace FLEdit
{
    class G
    {
        static G instance;
        public Edit edits;
        //Add stuff here
        public SpriteFont font;

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
