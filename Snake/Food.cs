using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    // Klass för food. Slumpar ut position för ny food. 
    internal class Food : GameObject
    {

        public Food(string name, char appearance, GameWorld world)
        {
            Appearance = appearance;
            Name = name;
            Random vaff = new Random();
            posse.X = vaff.Next(1, world.width);
            posse.Y = vaff.Next(1, world.height);
        }


        public override void Update()
        {
        }



    }
}
