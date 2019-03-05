using System;

namespace TrueSnake
{
     class Field
    {
        public static int Length { get; } = 20;
        public static int Heigth { get; } = 10;        
        ConsoleKeyInfo keyInfo;
        bool upDown = true;
        bool leftRight = false;
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

                    if (Y == 0 || Y == Heigth - 1)
                    {
                        Console.Write("#");
                    }
                    else if (food.FoodCoordinates.X == X && food.FoodCoordinates.Y== Y)
                    {
                        Console.Write("&");
                    }
                    else if (X == 0 || X == Length - 1)
                    {
                        Console.Write("#");
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
                        {
                            Console.Write(" ");
                            
                        }
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
                    if (upDown)                    
                        key = Key.UP;
                    leftRight = true;
                    upDown = false;
                    break;
                case ConsoleKey.DownArrow:
                    if (upDown)
                        key = Key.DOWN;
                    leftRight = true;
                    upDown = false;
                    break;
                case ConsoleKey.LeftArrow:
                    if (leftRight)
                        key = Key.LEFT;
                    leftRight = false;
                    upDown = true;           
                    break;
                case ConsoleKey.RightArrow:
                    if (leftRight)
                        key = Key.RIGHT;
                    upDown = true;
                    leftRight = false;  
                    break;
                default:
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
