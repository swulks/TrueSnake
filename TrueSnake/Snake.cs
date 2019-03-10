using System.Collections.Generic;

namespace TrueSnake
{
    class Snake
    {
        public List<Point> SnakeBody { get; set; }

        public Snake()
        {
            SnakeBody = new List<Point>();
            SnakeBody.Add(new Point(10, 5));

        }

        public void SnakeLogic(Food food)
        {
           

            if (CollisionsCheck(food)) // That method returns true if head is colliding whith itself
            {
                Game.GameRun = false;
                return;
            }
            SnakeBodyMovement();   
        }

        private bool CollisionWhithFood(Point food)
        {
            if (SnakeBody[0].X == food.X && SnakeBody[0].Y == food.Y)
            {
                return true;
            }
            return false;
        }

        private bool CollisionsCheck(Food food)
        {
            bool collisionWhithItself = false;

            //*Game mods
            if (Game.GameMode == Game.Mode.CLASSIC)
            {
                if (SnakeBody[0].X == Field.Length - 1 || SnakeBody[0].X == 1 || //In classic mode when snake has colliding whith border, game is over
                    SnakeBody[0].Y == Field.Heigth - 1 || SnakeBody[0].Y == 1)
                {
                    Game.GameRun = false;
                    return collisionWhithItself;
                }
            }
            else
            {
                if (SnakeBody[0].X == Field.Length - 1)
                {
                    SnakeBody[0].X = 0;
                }
                else if (SnakeBody[0].X == 0)
                {
                    SnakeBody[0].X = Field.Length - 1;
                }
                else if (SnakeBody[0].Y == Field.Heigth - 1)
                {
                    SnakeBody[0].Y = 0;
                }
                else if (SnakeBody[0].Y == 0)
                {
                    SnakeBody[0].Y = Field.Heigth;
                }

            }

            //*Collision whith food;
            if (CollisionWhithFood(food.FoodCoordinates))
            {
                SnakeBody.Add( new Point(SnakeBody[0].X, SnakeBody[0].Y)); //If collide, add new point to the Snake's tail
                Game.Score += 10;
                food.SpawnFood();
                
                return collisionWhithItself;
            }

            //*Collision whith itself;
            //We need to check collisions whith itself only if snake's body length 
            //is higher than 3
            if (SnakeBody.Count > 3)
            {
                int snakeHeadX = SnakeBody[0].X;
                int snakeHeadY = SnakeBody[0].Y;
                for (int i = 1; i < SnakeBody.Count; i++)
                {
                    if (snakeHeadX == SnakeBody[i].X && snakeHeadY == SnakeBody[i].Y)
                    {
                        //If snake's head collide whith body,
                        //set the colllision flag on true
                        collisionWhithItself = true;
                        break;
                    }
                }
            }
            //If collision has not been performed, set flag to false
            return collisionWhithItself;
        }

        private void SnakeBodyMovement()
        {
            //First set snake's head in a temp variable.
            int tempHeadX = SnakeBody[0].X;
            int tempHeadY = SnakeBody[0].Y;


            for (int i = 0; i < SnakeBody.Count - 1; i++)
            {
                //Set snake's tail(current position) in temp variable.
                int tempTailX = SnakeBody[i + 1].X;
                int tempTailY = SnakeBody[i + 1].Y;

                //"Move" snake's tail coordinates to the snake's head coordinates.
                SnakeBody[i + 1].X = tempHeadX;
                SnakeBody[i + 1].Y = tempHeadY;

                //Save current snake's tail possition in "head" for further work whit it (in the next loop itteration 
                //"tail" will be "head". 
                tempHeadX = tempTailX;
                tempHeadY = tempTailY;

            }
        }
    }
}

