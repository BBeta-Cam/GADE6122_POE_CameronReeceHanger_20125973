﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE_CameronReeceHanger_20125973
{ //Question 2.2
    public class Gold : Item
    {
        private int goldDrop;

        public int GOLDDROP
        {
            get { return goldDrop; }
            set { goldDrop = value; }
        }

        private Random RAND_GOLD_GEN = new Random();//initialises new random gold object
        
        protected Gold(int _X, int _Y) : base(int _X, int _Y)//constructor
        {
            
            goldDrop = RAND_GOLD_GEN.Next(1,5); //sets gold to a random amount between 1 and 5 inclusive
            
        }
    }
}
