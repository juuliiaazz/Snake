using System;
using System.Threading;

namespace Snake
{
    class Program
    {

        /// Tittar i Console för att se om en tangent har klickats på, i så fall returneras den, annars NoName

        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        static void Loop()
        {
            // Initialisera spelet
            const int frameRate = 5;
            GameWorld world = new GameWorld(50, 30); //skapar ny gameworld i storleken 50x30
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            // Skapar spelare och mat

            Player player1 = new Player();
            Food banana = new Food("Banana", '(', world);
            Food semla = new Food("Semla", 'Θ', world);

            world.gameobjects.Add(player1);
            world.gameobjects.Add(banana);
            world.gameobjects.Add(semla);

            // Huvudloopen
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren. Det går att använda både piltangenter och A-S-D-W
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    case ConsoleKey.Q:
                        running = false;
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        {
                            player1.riktning = "vänster";
                            break;
                        }
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        {
                            player1.riktning = "upp";
                            break;
                        }
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        {
                            player1.riktning = "höger";
                            break;
                        }
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        {
                            player1.riktning = "ner";
                            break;
                        }
                }

                // Uppdatera världen och rendera om

                renderer.RenderBlank();
                world.Update();
                renderer.Render();



                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {

            Loop();
        }
    }
}
