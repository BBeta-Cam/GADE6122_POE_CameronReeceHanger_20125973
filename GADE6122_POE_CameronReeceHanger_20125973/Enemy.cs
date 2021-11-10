using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    public abstract class Enemy : Character //enemy inherits from character
    {
        protected Random RandomNum = new Random(); // variable that creates random number

        protected Enemy(int _X, int _Y, int _DAMAGE, int _STARTINGHP) : base(_X,_Y,_DAMAGE,_STARTINGHP) //constructor
        {
            DAMAGE = _DAMAGE;
            HP = _STARTINGHP;

        }
 
        public override string ToString()//ToString concatinates name, x and y coordinates and damage into one single string
        {
            string EnemyInfo = GetType().Name + " " + "at" + " ";
            EnemyInfo += "[" + X.ToString() + "," + Y.ToString() + "]" + " ";
            EnemyInfo += "(" + DAMAGE.ToString() + ")";

            return EnemyInfo; //returns final string
        }
    }
}
