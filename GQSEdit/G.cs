using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GQSEdit
{
    class G
    {
        static G instance;
        public Edit edits;
        //Add stuff here

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
