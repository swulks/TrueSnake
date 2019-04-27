using System;
using System.Threading;
using System.Threading.Tasks;

namespace TrueSnake
{
    public class Game
    {
        /// <summary>
        /// Game status
        /// </summary>
        public static bool GameRun { get; set; } = false;

        /// <summary>
        /// Game mode
        /// </summary>
        public static Mode GameMode;

        /// <summary>
        /// Game score
        /// </summary>
        public static int Score { get; set; }

        /// <summary>
        /// Stores key info of the pressed key
        /// </summary>
        static ConsoleKeyInfo keyInfo;

        /// <summary>
        /// Checks if snake collide whith itself
        /// </summary>
        public static bool CollisionWithItself { get; set; }

        static Field snakeField;
        static Snake snake;
        static Food food;
         
        public Game()
        {
            snakeField = new Field();
            snake = new Snake();
            food = new Food();

            StartGame();
        }

        /// <summary>
        /// Method that starts the game
        /// </summary>
        private void StartGame()
        {
            StartMenu();

            while (GameRun)
            {   
                
                Task logic = Task.Run(() => snake.SnakeLogic(food));
                snakeField.Controls(snake);
                //task2
                Task draw = Task.Run(() => snakeField.Draw(snake, food));

                //GUI added, for example
                //Added change
                //Some new changes
                Thread.Sleep(100);
            }
            GameOverScreen();
        }

        /// <summary>
        /// Shows the start menu of the game
        /// </summary>
        private void StartMenu()
        {
            bool run = true;
            Console.WriteLine("1. Start \"Classic Snake\"");
            Console.WriteLine("2. Start \"NoWalls Snake\"");
            Console.WriteLine("3. Exit");


            keyInfo = Console.ReadKey();


            while (run)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        // Starts CLASSIC
                         GameMode = Mode.CLASSIC;
                        GameRun = true;                                
                        run = false;
                        break;
                    case ConsoleKey.D2:
                        //Starts NoWalls
                        GameMode = Mode.NO_WALLS;                        
                        run = false;
                        GameRun = true;
                        break;
                    case ConsoleKey.D3:         
                        //Exit
                        run = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Shows the "Game over" screen
        /// </summary>
        private void GameOverScreen()
        {
           
            Console.WriteLine("GAME OVER");
            if (CollisionWithItself == true)
            {
                Console.WriteLine("You have been collided whith your body!");
            }
            Console.WriteLine("Your score is: " + Score);     
            Console.ReadKey();
        }

        public enum Mode
        {
            CLASSIC = 0,
            NO_WALLS
        }
    }   
}
