using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    public abstract class Character : Tile
    { //cariables to be used later on
        public int GoldPurse;
        protected int hp;
        protected int maxhp;
        protected int damage;
        private List<Tile> vision;

        public int GOLDPURSE //used to store gold
        {
            get { return GoldPurse; }
            set { GoldPurse = value; }
        }
        public int HP 
        {
            get { return hp; }
            set { hp = value; }
        }

        public int MAXHP
        {
            get { return maxhp; }
            set { maxhp = value; }
        }

        public int DAMAGE
        {
            get { return damage; }
            set { damage = value; }
        }


        public List<Tile> VISION //Tile array
        {
            get { return vision; }
            set { vision = value; }
        }

        private MovementEnum movement; //Declaring Movement variable

        

        protected Character(int _X, int _Y, string _SYMBOL) : base(_X, _Y, _SYMBOL) //constructor
        {
            VISION = new List<Tile>();
        }

        public virtual void Attack(Character Target)
        {
            Target.HP -= DAMAGE;

        }

        public bool isDead()
        {
            if (HP <= 0)
            {
                return true;
            }
            else return false;
        }

        public virtual bool CheckRange(Character Target) //checks range
        {
            int MoveableDistance = 1;

            if (DistanceTo(Target) <= MoveableDistance)
            {
                return true;
            }
            else return false; 
        }

        private int DistanceTo(Character Target) //works out distance
        {
            return Math.Abs(X - Target.X) + Math.Abs(Y - Target.Y);//concatinates the results of both coordinates being subtracted from the actual coordinates into one int
        }

        public void Move(MovementEnum Move)
        {
            switch (Move) 
            {
                case MovementEnum.Up:
                    Y--;
                    break;
                case MovementEnum.Down:
                    Y++;
                    break;
                case MovementEnum.Left:
                    X--;
                    break;
                case MovementEnum.Right:
                    X++;
                    break;
                case MovementEnum.None:  //Q2.3
                    break;
            }

        }

        public abstract MovementEnum ReturnMove(MovementEnum move = 0);

        public abstract override string ToString();

        public void Pickup(Item i)  //Question 3.2
        {
            if(i = Gold)
            {
                GoldPurse = GoldPurse + Gold;
            }
        }
    }
}
