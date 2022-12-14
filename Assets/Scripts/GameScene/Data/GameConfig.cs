namespace AsteroidsTest.GameScene.Data
{
    public struct GameConfig
    {
        public static GameConfig Current;
        
        // ### Ship settings ###
        public float ShipMaxSpeed { get; private set; }
        public float ShipAcceleration { get; private set; }
        public float ShipDeceleration { get; private set; }
        public int LaserMaxChargesCount { get; private set; }
        public float LaserChargeTime { get; private set; }
        
        // ### Objects settings ###
        public int AsteroidSpawnDelay { get; private set; }
        public int AsteroidPartsCountOnDestroy { get; private set; }
        public float AsteroidPartsSpeedMulti { get; private set; }
        public float AsteroidMinSpeed { get; private set; }
        public float AsteroidMaxSpeed { get; private set; }
        public float UfoMinSpeed { get; private set; }
        public float UfoMaxSpeed { get; private set; }
        public int ScorePointsForDestroy { get; private set; }

        public static GameConfig DefaultConfig()
        {
            return new GameConfig
            {
                ShipMaxSpeed = 3,
                ShipAcceleration = 1.5f,
                ShipDeceleration = .75f,
                LaserMaxChargesCount = 3,
                LaserChargeTime = 5f,
                
                AsteroidSpawnDelay = 2,
                AsteroidPartsCountOnDestroy = 3,
                AsteroidPartsSpeedMulti = 2f,
                AsteroidMinSpeed = 1,
                AsteroidMaxSpeed = 3,
                UfoMinSpeed = 1,
                UfoMaxSpeed = 3,
                ScorePointsForDestroy = 1,
            };
        }
    }
}