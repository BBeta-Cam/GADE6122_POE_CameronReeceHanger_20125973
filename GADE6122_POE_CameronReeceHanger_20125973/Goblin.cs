using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    public class Goblin : Enemy
    {
        public Goblin(int _X,int _Y, int _STARTINGHP = 10, int _DAMAGE = 1)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum CharacterMove = MovementEnum.NoMovement)
        {
            int RandomTile = RandomNum.Next(0, VISION.Count);

            while (VISION[RandomTile].TYPEOFTILE.Equals(typeof(EmptyTile)))
            {
                RandomTile = RandomNum.Next(0, VISION.Count);
            }

            if (VISION[RandomTile].X > X)
            {
                return MovementEnum.Right;
            }
            else if(VISION[RandomTile].X < X)
            {
                return MovementEnum.Left;
            }
            else if (VISION[RandomTile].Y > Y)
            {
                return MovementEnum.Down;
            }
            else if (VISION[RandomTile].Y < Y)
            {
                return MovementEnum.Up;
            }

            return MovementEnum.NoMovement;
        }
    }
}
