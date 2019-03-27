using System;

namespace TrueSnake
{
    class Food
    {
        public Point FoodCoordinates { get; set; }
        

        public Food()
        {
            FoodCoordinates = new Point(4, 7); //Coordinates of the first spawn of the food
        }

        public void SpawnFood()
        {
            Random randomNum = new Random();

            int tempX = FoodCoordinates.X;
            int tempY = FoodCoordinates.Y;
            

            while (tempX == FoodCoordinates.X && tempY == FoodCoordinates.Y)
            {
                tempX = randomNum.Next(3, 17);
                tempY = randomNum.Next(2, 8);
            }
            FoodCoordinates.X = tempY;
            FoodCoordinates.Y = tempY;
        }
    }
}
