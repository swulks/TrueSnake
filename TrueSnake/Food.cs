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

            FoodCoordinates.X = randomNum.Next(3, 17);
            FoodCoordinates.Y = randomNum.Next(2, 8);
        }
    }
}
