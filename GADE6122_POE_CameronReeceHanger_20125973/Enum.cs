using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    
        public enum TileType //declaring values that will hold parameters
        { 
        Hero, 
        Enemy,
        Gold,
        }

        public enum MovementEnum //these values dictate the types of movement the players and enemies can have
        {
            NoMovement,
            Up,
            Down,
            Left,
            Right,
            None,
        }

    
}
