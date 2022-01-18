using System;

namespace CamelGame
{
    class Program
    {

        // Initializing the variables to be used throughout the program.
        static Random random;
        static bool done;
        static int thirstLevel;
        static int distance;
        static int enemyDistance;
        static int camelTiredness;
        static int canteen;

        static void Main(string[] args)
        {
            // Introductory message

            Console.WriteLine("Welcome to Camel!");


            // Main game loop

            random = new Random();
            done = false;
            thirstLevel = 0;
            distance = 0;
            enemyDistance = -10;
            camelTiredness = 0;
            canteen = 3;

            while (!done)
            {
                // User check conditions

                if (distance > 100)
                {
                    Console.WriteLine("You have escaped the natives.");
                    done = true;
                }

                if (thirstLevel > 5 & !done)
                {
                    Console.WriteLine("You have died from thirst.");
                    done = true;
                }

                if (camelTiredness > 8 & !done)
                {
                    Console.WriteLine("Your camel has died from exhaustion.");
                    done = true;
                }

                if (enemyDistance >= distance & !done)
                {
                    Console.WriteLine("The natives have caught you.");
                    done = true;
                }

                if (thirstLevel >= 3 & !done)
                {
                    Console.WriteLine("You are thirsty.");
                }

                if (camelTiredness > 5 & !done)
                {
                    Console.WriteLine("Your camel is tired.");
                }

                if (!done)
                {
                    // Print commands

                    Console.WriteLine();
                    Console.WriteLine("A. Drink from your canteen.");
                    Console.WriteLine("B. Ahead moderate speed.");
                    Console.WriteLine("C. Ahead full speed.");
                    Console.WriteLine("D. Stop and rest.");
                    Console.WriteLine("E. Status check.");
                    Console.WriteLine("Q. Quit.");
                    Console.WriteLine();

                    // Get user command

                    Console.Write("What is your command? ");
                    string userCommand = Console.ReadLine();
                    Console.WriteLine();

                    // Process user command

                    if (userCommand == "a")
                    {
                        if (canteen > 0)
                        {
                            DrinkWater();
                        }
                        else
                        {
                            Console.WriteLine("Your canteen is empty!");
                        }
                    }

                    else if (userCommand == "b")
                    {
                        SlowSpeed();
                    }

                    else if (userCommand == "c")
                    {
                        FullSpeed();
                    }

                    else if (userCommand == "d")
                    {
                        Rest();
                    }

                    else if (userCommand == "e")
                    {
                        CheckStatus();
                    }

                    else if (userCommand == "q")
                    {
                        Console.WriteLine("You have quit the game.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Unkown command entered.");
                    }
                }
            }

            // Function for the player to drink water.
            static void DrinkWater()
            {
                Console.WriteLine("You drank from the canteen.");
                thirstLevel = 0;
                enemyDistance += random.Next(6, 14);
                canteen -= 1;
            }

            // Function that has the player move forward at a moderate speed.
            static void SlowSpeed()
            {
                Console.WriteLine("You go ahead at moderate speed.");
                distance += random.Next(6, 8);
                camelTiredness += 1;
                enemyDistance += random.Next(6, 14);
                thirstLevel += 1;
                CheckForOasis();
            }

            // A function that has the player move forward at a fast speed that is quicker than the enemy.
            static void FullSpeed()
            {
                Console.WriteLine("You go ahead at full speed.");
                distance += random.Next(12, 16);
                camelTiredness += 2;
                enemyDistance += random.Next(6, 14);
                thirstLevel += 1;
                CheckForOasis();
            }

            // A function that allows the player and the camel to rest.
            static void Rest()
            {
                Console.WriteLine("You stop and rest.");
                camelTiredness = 0;
                enemyDistance += random.Next(6, 14);
                thirstLevel += 1;
            }

            // A function that lets the user check how far they and their enemies have gone.
            static void CheckStatus()
            {
                Console.WriteLine("You have traveled " + distance + " miles.");
                Console.WriteLine("You have " + canteen + " drinks left in your canteen.");
                Console.WriteLine("The natives are " + (distance - enemyDistance) + " miles behind you.");
            }

            // A function that checks to see if the player has found an oasis.
            static void CheckForOasis()
            {
                if (random.Next(1, 20) == 10)
                {
                    thirstLevel = 0;
                    camelTiredness = 0;
                    canteen = 3;
                    Console.WriteLine("You have found an oasis! You and your camel feel rested and hydrated!");
                }
            }
        }
    }
}
