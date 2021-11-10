using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    class GameEngine
    {
        private Map gMap;

        public Map GMAP
        {
            get { return gMap; }
            set { gMap = value; }
        }

        public bool PlayerMove(MovementEnum Direction)
        {
            if(GMAP.PCHARACTER.ReturnMove(Direction) == Direction)
            {
                GMAP.Create(TileType.Empty, GMAP.PCHARACTER.X, GMAP.PCHARACTER.Y);

                GMAP.PCHARACTER.Move(Direction);

                GMAP.MAPBORDER[GMAP.PCHARACTER.X, GMAP.PCHARACTER.Y] = GMAP.PCHARACTER;

                return true;
            }
            return false;
        }        
        public string PAttack(int _Enemy)
        {
            bool EnemyWithinRange = false;
            
            foreach (Tile T in GMAP.PCHARACTER.VISION)
            {
                if(T.X == GMAP.ENEMIES[_Enemy].X && (T.Y == GMAP.ENEMIES[_Enemy].Y))
                {
                    EnemyWithinRange = true;
                    break;
                }
            }

            if (EnemyWithinRange)
            {
                GMAP.PCHARACTER.Attack(GMAP.ENEMIES[_Enemy]);
                return "The " + GMAP.ENEMIES[_Enemy].TYPEOFTILE.ToString() + " took " + GMAP.PCHARACTER.DAMAGE.ToString()
                    + " damage and is left on " + GMAP.ENEMIES[_Enemy].HP.ToString() + "HP.";
            }
            else
            {
                return "Enemy is too far.";
            }
        }

        public void EnemyAttacks()  //Question 3.3
        {
            for (int i = 0; i < length; i++)
            {

            }
        }
    }
}
