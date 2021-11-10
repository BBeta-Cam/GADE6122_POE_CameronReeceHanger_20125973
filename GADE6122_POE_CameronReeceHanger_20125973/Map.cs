using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{
    public class Map
    {
        private Tile[,] mapBorder;

        public Tile[,] MAPBORDER
        {
            get { return mapBorder; }
            set { mapBorder = value; }
        }

        private Hero pCharacter;

        public Hero PCHARACTER
        {
            get { return pCharacter; }
            set { pCharacter = value; }
        }

        private List<Item> GoldDrops;  // Question 3.1
        private List<Enemy> enemies,goblin,mage; //3.1
        public List<Enemy> ENEMIES
        {
            get { return enemies; }
            set { enemies = value; }
        }

        public List<Enemy> GOBLIN //3.1
        {
            get { return GOBLIN; }
            set { goblin = value; }
        }

        public List<Enemy> MAGE //3.1
        {
            get { return MAGE; }
            set { mage = value; }
        }

        private int mapWidth;

        public int MAPWIDTH
        {
            get { return mapWidth; }
            set { mapWidth = value; }
        }

        private int mapHeight;

        public int MAPHEIGHT
        {
            get { return mapHeight; }
            set { mapHeight = value; }
        }

        protected Random RAND_NUM_GEN = new Random();

        public Map(int _MINIMUMWIDTH, int _MAXIMUMWIDTH, int _MINIMUMHEIGHT, int _MAXIMUMHEIGHT, int _NUMENEMIES,int GOLDDROPS)
        {
            MAPWIDTH = RAND_NUM_GEN.Next(_MINIMUMWIDTH, _MAXIMUMWIDTH);
            MAPHEIGHT = RAND_NUM_GEN.Next(_MINIMUMHEIGHT, _MAXIMUMHEIGHT);

            MAPBORDER = new Tile[MAPWIDTH, MAPHEIGHT];

            ENEMIES = new List<Enemy>();

            Random rd = new Random();   //3.1

            int rand_num = rd.Next(1, 2);

            if(rand_num == 1)
            {
                GOBLIN = new List<Enemy>();
            }
            else if(rand_num == 2)
            {
                MAGE = new List<Enemy>();
            }

            GOLDDROPS = new List<Item>();
            Create();

        UpdateVision();
        }

        

        public void UpdateVision()
        {
            foreach (Enemy E in ENEMIES)
            {
                E.VISION.Clear();

                if (E.X > 0)
                {
                    E.VISION.Add(MAPBORDER[E.X - 1, E.Y]);
                }
                if (E.X > MAPWIDTH)
                {
                    E.VISION.Add(MAPBORDER[E.X + 1, E.Y]);
                }
                if (E.Y > 0)
                {
                    E.VISION.Add(MAPBORDER[E.X, E.Y - 1]);
                }
                if (E.Y > 0)
                {
                    E.VISION.Add(MAPBORDER[E.X, E.Y + 1]);
                }
            }

            PCHARACTER.VISION.Clear();

            if(PCHARACTER.X > 0)
            {
                PCHARACTER.VISION.Add(MAPBORDER[PCHARACTER.X - 1, PCHARACTER.Y]);
            }
            if (PCHARACTER.X < MAPWIDTH)
            {
                PCHARACTER.VISION.Add(MAPBORDER[PCHARACTER.X + 1, PCHARACTER.Y]);
            }
            if (PCHARACTER.Y > 0)
            {
                PCHARACTER.VISION.Add(MAPBORDER[PCHARACTER.X, PCHARACTER.Y - 1]);
            }
            if (PCHARACTER.Y < MAPHEIGHT)
            {
                PCHARACTER.VISION.Add(MAPBORDER[PCHARACTER.X, PCHARACTER.Y + 1]);
            }

            

            for (int i = 0; i < _NUMENEMIES; i++)
            {
                Create(TileType.Enemy);
            }
        }

        public void Create(TileType TypeOfTile, int X = 0, int Y = 0)
        {
            switch (TypeOfTile) 
            {
                case TileType.Barrier:
                    Obstacle NewBarrier = new Obstacle(X, Y, "X", TypeOfTile);
                    MAPBORDER[X, Y] = NewBarrier;
                    break;

                case TileType.Empty:
                    EmptyTile NewEmptyTile = new EmptyTile(X, Y, " ", TypeOfTile);
                    MAPBORDER[X, Y] = NewEmptyTile;
                    break;

                case TileType.Hero:
                    int HeroXPos = RAND_NUM_GEN.Next(0, MAPWIDTH);
                    int HeroYPos = RAND_NUM_GEN.Next(0, MAPHEIGHT);

                    while (MAPBORDER[HeroXPos,HeroYPos].TYPEOFTILE != TileType.Empty)
                    {
                        HeroXPos = RAND_NUM_GEN.Next(0, MAPWIDTH);
                        HeroYPos = RAND_NUM_GEN.Next(0, MAPHEIGHT);
                    }

                    Hero newHero = new Hero(HeroXPos, HeroYPos, TypeOfTile, "H", 50, 50, 10);
                    PCHARACTER = newHero;
                    MAPBORDER[HeroXPos, HeroYPos] = newHero;
                    break;

                case TileType.Enemy:
                    int EnemyXPos = RAND_NUM_GEN.Next(0, MAPWIDTH);
                    int EnemyYPos = RAND_NUM_GEN.Next(0, MAPHEIGHT);

                    while (MAPBORDER[EnemyXPos, EnemyYPos].TYPEOFTILE != TileType.Empty)
                    {
                        EnemyXPos = RAND_NUM_GEN.Next(0, MAPWIDTH);
                        EnemyYPos = RAND_NUM_GEN.Next(0, MAPHEIGHT);
                    }

                    Goblin newGoblin = new Goblin(EnemyXPos, EnemyYPos, TypeOfTile, "G", 50, 50, 10);
                    ENEMIES.Add(newGoblin);
                    MAPBORDER[EnemyXPos, EnemyYPos] = newGoblin;
                    break;

                case TileType.Gold:
                    break;

                    Random rdGold = new Random();   

                    int rand_Gold = rdGold.Next(1, 5);

                    GoldDrops = rand_Gold;
            }

        }

        void DrawMap(int ENEMIES)
        {
            for (int i = 0; i < MAPWIDTH; i++)
            {
                for (int i = 0; i < MAPHEIGHT; i++)
                {
                    if ()
                    {
                        Create(Tile.Barrier, x, y);
                    }
                    else
                    {
                        Create(Tile.Empty, x, y);
                    }
                }
            }
            Create(TileType.Hero);

            for (int i = 0; i < ENEMIES; i++)
            {
                Create(TileType.Enemy);
            }
        }

        public override string ToString()
        {
            String MapS = "";

            for (int i = 0; i < MAPWIDTH; i++)
            {
                for (int j = 0; j < MAPWIDTH; j++)
                {
                    MapS += MAPBORDER[i, j].SYMBOL;

                }
                MapS += "\n";

            }
            return MapS;
        }

        public Item GetItemAtPosition(int x, int y)  //Question 3.2
        { //loops through items until one is found matching the heroes x and y coordinates
            bool temp = false;

            if ( temp == false) 
            {
                if(Item.X = Hero.X && Item.Y == Hero.Y)
                {
                    
                    return Item();
                    Item() = null;
                }
                temp = true; //if one matches the loop ends
            }
            else //if one doesnt match the loop continues
            {
                temp = false;
                return null;             
            }
        }




    }
}
