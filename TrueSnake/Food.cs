using System;


namespace TrueSnake
{
    class Food
    {
        public Point FoodCoordinates { get; set; }
        
        //Default spawn coordinates
        int DEFAULT_SPAWN_X = Field.Length/2;
        int DEFAULT_SPAWN_Y = Field.Heigth/2;

        //Random food spawn length coordinates
        int START_RANDOM_POINT_X = 2;
        int END_RANDOM_POINT_X = Field.Length - 2;
        
        //Random food spawn heigth coordinates
        int START_RANDOM_POINT_Y = 2;
        int END_RANDOM_POINT_Y = Field.Heigth - 2;

        public Food()
        {
            FoodCoordinates = new Point(DEFAULT_SPAWN_X, DEFAULT_SPAWN_Y); //Coordinates of the first spawn of the food
        }

        public void SpawnFood()
        {
            Random getRandom = new Random(DateTime.Now.Millisecond);

            FoodCoordinates.X = getRandom.Next(START_RANDOM_POINT_X, END_RANDOM_POINT_X);
            FoodCoordinates.Y = getRandom.Next(START_RANDOM_POINT_Y, END_RANDOM_POINT_Y);
        }
    }
}
