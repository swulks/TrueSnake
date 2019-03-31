using System;
using System.Threading;
using System.Threading.Tasks;

namespace TrueSnake
{
    public class Game
    {
        public static bool GameRun { get; set; } = false;
        public static Mode GameMode;
        public static int Score { get; set; }
        static ConsoleKeyInfo keyInfo;
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

        private void StartGame()
        {
            StartMenu();

            while (GameRun)
            {   
                //task1
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

        public void GameOverScreen()
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
