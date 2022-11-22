using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    // Klass för spelaren
    internal class Player : GameObject
    {
        public string riktning { get; set; }

        public Player()
        {
            // startposition och utseende på spelaren
            posse.X = 5;
            posse.Y = 5;
            Appearance = '■';



        }
        public override void Update()
        {
            // vad som ska hända när masken går åt olika håll
            switch (riktning)
            {
                case "upp":
                    posse.Y--;
                    break;

                case "ner":
                    posse.Y++;
                    break;

                case "vänster":
                    posse.X--;
                    break;

                case "höger":
                    posse.X++;
                    break;

            }

        }

    }
}
