using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    public class Hero : Character
    {
        public Hero(int _X, int _Y, int _HP, int _DAMAGE = 2) : base(_X, _Y, _HP, _DAMAGE) //hero constructor
        {

        }

        public override MovementEnum ReturnMove(MovementEnum CharacterMove = MovementEnum.NoMovement)
        {
            if (CheckIfMoveValid(CharacterMove))
            {
                return CharacterMove;
            }
            else return MovementEnum.NoMovement;
        }

        public override string ToString() //concatinates all hero stats into one string
        {
            string HeroInfo = "Player Stats: \n";
            HeroInfo += "HP: " + HP.ToString() + "/" + MAXHP.ToString() + "\n";
            HeroInfo += "Damage: " + DAMAGE.ToString() + "\n";
            HeroInfo += "[" + X.ToString() + "," + Y.ToString() + "]";
            return HeroInfo;
        }

        bool CheckIfMoveValid(MovementEnum CharacterMove) //checks if the player controlling the hero can move to where they want to go unobstructed
        {
            bool Valid = false;

            switch (CharacterMove) 
            {
                case MovementEnum.Left: //checks if hero can move left
                    foreach (Tile T in VISION)
                    {
                        if(T.X == X - 1)
                        {
                            if(T.TYPEOFTILE == TileType.Empty)
                            {
                                Valid = true;
                                break;
                            }
                        }
                    }

                    break;

                case MovementEnum.Right: //checks if hero can move right
                    foreach (Tile T in VISION)
                    {
                        if (T.X == X + 1)
                        {
                            if (T.TYPEOFTILE == TileType.Empty)
                            {
                                Valid = true;
                                break;
                            }
                        }
                    }

                    break;

                case MovementEnum.Up: //checks if hero can move up
                    foreach (Tile T in VISION)
                    {
                        if (T.Y == Y - 1)
                        {
                            if (T.TYPEOFTILE == TileType.Empty)
                            {
                                Valid = true;
                                break;
                            }
                        }
                    }

                    break;

                case MovementEnum.Down: //checks if hero can move down
                    foreach (Tile T in VISION)
                    {
                        if (T.Y == Y + 1)
                        {
                            if (T.TYPEOFTILE == TileType.Empty)
                            {
                                Valid = true;
                                break;
                            }
                        }
                    }

                    break;
            }
            return Valid;

        }
    }


}
