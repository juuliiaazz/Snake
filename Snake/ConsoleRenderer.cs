using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class ConsoleRenderer
    {

        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            world = gameWorld;
            Console.SetWindowSize(world.width + 1, world.height + 1);
            Console.CursorVisible = false;

        }

        // Möjliggör för player att gå in i en kant och komma ut på andra sidan. 
        public void Render()
        {
            foreach (var plats in world.gameobjects)
            {
                if (plats.posse.X < 0)
                {
                    plats.posse.X = world.width - 1;
                }
                else if (plats.posse.Y < 0)
                {
                    plats.posse.Y = world.height - 1;
                }
                else if (plats.posse.X > world.width)
                {
                    plats.posse.X = 0;
                }
                else if (plats.posse.Y > world.height)
                {
                    plats.posse.Y = 0;
                }

                // sätter ut den nya platsen för objekten efter uppdatering. 
                Console.SetCursorPosition(plats.posse.X, plats.posse.Y);
                Console.Write(plats.Appearance);

                // Poängräkning i konsolen
                Console.SetCursorPosition(3, 3);
                Console.Write(world.points);

                // Poängräkning i titlen för spelet. 
                Console.Title = "Dina Poäng: " + world.points.ToString();


            }
        }

        // Funktion som rensar skärmen istället för ConsoleClear
        public void RenderBlank()
        {
            Console.SetCursorPosition(3, 3);
            Console.Write(" ");
            foreach (var g in world.gameobjects)
            {
                Console.SetCursorPosition(g.posse.X, g.posse.Y);
                Console.Write(" ");
            }
        }
    }
}
