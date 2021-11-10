using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{//Question 2.1
    public abstract class Item : Tile    
    {

        public Item(int _X, int _Y) : base(_X, _Y)
        {

        }

        public override string ToString()
        {
            String type = "Gold";

            return type;
        }
    }
}
