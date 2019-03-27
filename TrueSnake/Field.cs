using System;

namespace TrueSnake
{
     class Field
    {
        public static int Length { get; } = 20;
        public static int Heigth { get; } = 10;        
        ConsoleKeyInfo keyInfo;
        bool UpDown { get; set; } = true;
        bool LeftRight { get; set; } = false;
        Key key;

        public void Draw(Snake snake, Food food)
        {
            Console.Clear();

            bool needPrint = true;

            Console.WriteLine("Score is: " + Game.Score);//Shows game score
            for (int Y = 0; Y < Heigth; Y++)
            {
                for (int X = 0; X < Length; X++)
                {

                    if ((Y == 0 || Y == Heigth - 1) || (X == 0 || X == Length - 1))
                    {
                        Console.Write("#");
                    }
                    else if (food.FoodCoordinates.X == X && food.FoodCoordinates.Y== Y)
                    {
                        Console.Write("&");
                    } 
                    else
                    {
                        for (int i = 0; i < snake.SnakeBody.Count; i++)
                        {
                            if (snake.SnakeBody[i].X == X && snake.SnakeBody[i].Y == Y)
                            {
                                Console.Write('*');
                                needPrint = false;
                                //break;
                            }
                        }
                        if (needPrint)   
                            Console.Write(" ");    
                        
                        needPrint = true;
                    }   
                }
              
                Console.WriteLine();
            }
        }

        public void Controls(Snake snake)
        {
            
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey();
            }

            switch (keyInfo.Key)
            {

                case ConsoleKey.UpArrow:
                    if (UpDown)
                        key = Key.UP;
                    LeftRight = true;
                    UpDown = false;
                    break;
                case ConsoleKey.DownArrow:
                    if (UpDown)
                        key = Key.DOWN;
                    LeftRight = true;
                    UpDown = false;
                    break;
                case ConsoleKey.LeftArrow:
                    if (LeftRight)
                        key = Key.LEFT;
                    LeftRight = false;
                    UpDown = true;
                    break;
                case ConsoleKey.RightArrow:
                    if (LeftRight)
                        key = Key.RIGHT;
                    UpDown = true;
                    LeftRight = false;
                    break;
            }

            switch (key)
            {
                case Key.UP:
                    snake.SnakeBody[0].Y--;
                    break;
                case Key.DOWN:
                    snake.SnakeBody[0].Y++;
                    break;
                case Key.LEFT:
                    snake.SnakeBody[0].X--;
                    break;
                case Key.RIGHT:
                    snake.SnakeBody[0].X++;
                    break;
                case Key.STOP:
                    break;
            }
        }
        enum Key
        {
            STOP = 0,
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
    }
}
