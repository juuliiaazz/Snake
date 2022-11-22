using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    // Klass för händelser under spelets gång.
    class GameWorld
    {

        public int width;
        public int height;
        public int points = 0;
        public List<GameObject> gameobjects = new List<GameObject>();


        public GameWorld(int width, int height)
        {
            // sätter storleken på gameworld
            this.width = width;
            this.height = height;



        }

        public void Update()
        {

            foreach (var gameObject in gameobjects.ToList()) 
            {
                gameObject.Update();
                if (gameObject is Player) // om objektet är en player/mask
                {
                    foreach (var gameObjects2 in gameobjects.ToList())
                    {
                        if (gameObjects2 is Food) // om objektet är mat
                        {

                            if ((gameObject.posse.X == gameObjects2.posse.X) && (gameObject.posse.Y == gameObjects2.posse.Y)) // Om kordinaterna för player matchar kordinaterna för food
                            {

                                // om objektet är en semla ge semmel-poäng och skapa ny semla
                                if (gameObjects2.Name == "Semla")
                                {
                                    points += 5; // Semla ger 5 poäng
                                    gameobjects.Remove(gameObjects2);

                                    Food semla = new Food("Semla", 'Θ', this);
                                    gameobjects.Add(semla);
                                }
                                // om objektet är en banan ge banan-poäng och skapa ny banan
                                else if (gameObjects2.Name == "Banana")
                                {
                                    points++; // banan ger 1 poäng
                                    gameobjects.Remove(gameObjects2);

                                    Food banana = new Food("Banana", '(', this);
                                    gameobjects.Add(banana);
                                }

                            }
                        }
                    }
                }





            }
        }
    }
}
