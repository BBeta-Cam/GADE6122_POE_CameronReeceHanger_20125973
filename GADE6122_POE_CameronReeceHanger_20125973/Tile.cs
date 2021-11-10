using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    public abstract class Tile
    {

        protected int x; //sets int variables
        protected int y;
        public int X 
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private TileType typeoftile; //sets type of tile

        public TileType TYPEOFTILE 
        { 
            get { return typeoftile; }
            set { typeoftile = value; }
        }

       public Tile(int _X, int _Y, TileType _TYPEOFTILE) //constructor
        {
            X = _X;
            Y = _Y;
            TYPEOFTILE = _TYPEOFTILE;
        }

    }
}
