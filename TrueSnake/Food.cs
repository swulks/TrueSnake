using System;


namespace TrueSnake
{
    class Food
    {
        public Point FoodCoordinates { get; set; }
        
        /// <summary>
        /// Default spawn "X" cooordinate of the food
        /// </summary>
        int DEFAULT_SPAWN_X = Field.Length/2;
        /// <summary>
        /// Default spawn "Y" coordinate of the food
        /// </summary>
        int DEFAULT_SPAWN_Y = Field.Heigth/2;


        /// <summary>
        /// Start random number "X" range
        /// </summary>
        int START_RANDOM_POINT_X = 2;

        /// <summary>
        /// End random number "X" range
        /// </summary>
        int END_RANDOM_POINT_X = Field.Length - 2;
        
        /// <summary>
        /// Start random number "Y" range
        /// </summary>
        int START_RANDOM_POINT_Y = 2;

        /// <summary>
        /// End random number "Y" range
        /// </summary>
        int END_RANDOM_POINT_Y = Field.Heigth - 2;

        public Food()
        {
            FoodCoordinates = new Point(DEFAULT_SPAWN_X, DEFAULT_SPAWN_Y); //Coordinates of the first spawn of the food
        }

        /// <summary>
        /// Method that spawn food at random possition
        /// </summary>
        public void SpawnFood()
        {
            Random getRandom = new Random(DateTime.Now.Millisecond);

            FoodCoordinates.X = getRandom.Next(START_RANDOM_POINT_X, END_RANDOM_POINT_X);
            FoodCoordinates.Y = getRandom.Next(START_RANDOM_POINT_Y, END_RANDOM_POINT_Y);
        }
    }
}
