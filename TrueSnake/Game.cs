using System;
using System.Threading;

namespace TrueSnake
{
    public class Game
    {
        public static bool GameRun { get; set; } = false;
        public static Mode GameMode;
        public static int Score { get; set; }
        static ConsoleKeyInfo keyInfo;

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
                snake.SnakeLogic(food);
                snakeField.Controls(snake);
                snakeField.Draw(snake, food);
                
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
                        GameMode = Mode.CLASSIC;
                        GameRun = true;         //Starts CLASSIC
                        run = false;
                        break;
                    case ConsoleKey.D2:
                        GameMode = Mode.NoWalls;//Starts NoWalls
                        run = false;
                        GameRun = true;
                        break;
                    case ConsoleKey.D3:         //Exit
                        run = false;
                        break;
                }
            }
        }

        public void GameOverScreen()
        {
           
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Your score is: " + Score);

            
            Console.ReadKey();
        }

        public enum Mode
        {
            CLASSIC = 0,
            NoWalls
        }
    }
    

}
