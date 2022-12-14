using UnityEngine;

namespace AsteroidsTest.GameScene.Data
{
    public struct GameModel
    {
        public static GameModel Current;

        public int Score { get; private set; }

        public static GameModel New()
        {
            var model = new GameModel();
            model.Reset();

            return model;
        }

        public void Reset()
        {
            Score = 0;
        }

        public void AddScore(int delta)
        {
            Score += delta;
        }
    }
}