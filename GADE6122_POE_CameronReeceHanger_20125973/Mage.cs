using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    public class Mage  //Question 2.3
    {
       

        protected Mage(int _X, int _Y, int MHP = 5, int MDAMAGE = 5) //constructor
        {
            
        }

        public override int returnMove() //mage cannot move so variable is set to 0
        {
            int neverMove = 0;
            return neverMove;
        }

        
        public override bool CheckRange(Character Target) //checks if the target is within 1 block range
        {
            int MoveableDistance = 1;

            if (DistanceTo(Target) == MoveableDistance)
            {
                return true;
            }
            else return false;
        }

        private int DistanceTo(Character Target, int _Y, int _X) //calculates the distance to the target
        {
            return Math.Abs(_X - Target.X) + Math.Abs(_Y - Target.Y);
        }
    }
}
