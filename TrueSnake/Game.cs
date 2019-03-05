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
                
                Thread.Sleep(100);
            }
            GameOverScreen();
        }

        private void StartMenu()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("1. Start \"Classic Snake\"");
                Console.WriteLine("2. Start \"NoWalls Snake\"");
                Console.WriteLine("3. Exit");

                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey();
                }
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        run = false;
                        GameMode = Mode.CLASSIC;
                        GameRun = true;         //Starts CLASSIC
                        break;
                    case ConsoleKey.D2:
                        run = false;
                        GameMode = Mode.NoWalls;//Starts NoWalls
                        GameRun = true;
                        break;
                    case ConsoleKey.D3:
                        run = false;            //Exit
                        break;
                }
                Thread.Sleep(100);
            }
        }

        public void GameOverScreen()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Your score is: " + Score);

            //TODO
            Console.ReadKey();
        }

        public enum Mode
        {
            CLASSIC = 0,
            NoWalls
        }
    }


}
