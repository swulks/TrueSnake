using System.Collections.Generic;

namespace TrueSnake
{
    class Snake
    {
        /// <summary>
        /// List that stores points of the snake's body
        /// </summary>
        public List<Point> SnakeBody { get; set; }

        public Snake()
        {
            SnakeBody = new List<Point>()
            {
                new Point(10,5)
            };     
        }

        /// <summary>
        /// Snake's logic method
        /// </summary>
        /// <param name="food"></param>
        public void SnakeLogic(Food food)
        {
            // Returns true if head is colliding whith itself
            if (CollisionsCheck(food)) 
            {
                Game.GameRun = false;
                return;
            }
            SnakeBodyMovement();   
        }

        /// <summary>
        /// Check collision with food
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        private bool CollisionWhithFood(Point food)
        {
            if (SnakeBody[0].X == food.X && SnakeBody[0].Y == food.Y)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check collisions
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        private bool CollisionsCheck(Food food)
        {
            bool collisionWhithItself = false;

            //*Game mods
            if (Game.GameMode == Game.Mode.CLASSIC)
            {   
                //In classic mode when snake has colliding whith border, game is over
                if (SnakeBody[0].X == Field.Length - 1 || SnakeBody[0].X == 1 || 
                    SnakeBody[0].Y == Field.Heigth - 1 || SnakeBody[0].Y == 1)
                {
                    Game.GameRun = false;
                    return collisionWhithItself;
                }
            }
            else
            {   //In "no walls" mode if snake head collide whith border, her head "jumps" to the opposite border
                if (SnakeBody[0].X > Field.Length - 2)
                {
                    SnakeBody[0].X = 1;
                }
                else if (SnakeBody[0].X < 1 )
                {
                    SnakeBody[0].X = Field.Length - 2;
                }
                else if (SnakeBody[0].Y > Field.Heigth - 2)
                {
                    SnakeBody[0].Y = 1;
                }
                else if (SnakeBody[0].Y < 1)
                {
                    SnakeBody[0].Y = Field.Heigth - 2;
                }

            }

            //Collision whith food;
            if (CollisionWhithFood(food.FoodCoordinates))
            {
                SnakeBody.Add( new Point(SnakeBody[SnakeBody.Count - 1].X, SnakeBody[SnakeBody.Count - 1].Y)); //If collide, add new point to the Snake's tail
                Game.Score += 10;
                food.SpawnFood();
                
                return collisionWhithItself;
            }

            //Collision whith itself;
            //Check collisions whith itself only if snake's body length is higher than 3     
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
                        Game.CollisionWithItself = true;
                        break;
                    }
                }
            }
            //If collision has not been performed, set flag to false
            return collisionWhithItself;
        }

        /// <summary>
        /// Snake's body movement
        /// </summary>
        private void SnakeBodyMovement()
        {
            //First set snake's head in a temporal variable.
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
                //"tail" will be "head"). 
                tempHeadX = tempTailX;
                tempHeadY = tempTailY;

            }
        }
    }
}

