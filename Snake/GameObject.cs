using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{// Förälderklass som sätter en standard för de klasser som ärver. 
    abstract class GameObject
    {
        public Position posse = new Position();


        public char Appearance { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }




        public abstract void Update();



    }

}
