using System;
using System.Threading;
using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField]
        private Ship ship;
        [SerializeField]
        private Transform[] spawners;
        [SerializeField]
        private Asteroid asteroidPrefab;

        private bool isInputAvailable;
        private CancellationTokenSource cts;
        private AsteroidSpawner asteroidSpawner;

        public void Init()
        {
            cts?.Cancel();
            cts = new CancellationTokenSource();

            if (asteroidSpawner == null)
                asteroidSpawner = new AsteroidSpawner(ship.transform, spawners, asteroidPrefab);
        }
        
        public void StartGame()
        {
            isInputAvailable = true;
            asteroidSpawner.SpawnAsteroids(cts);
        }

        public void GameOver()
        {
            isInputAvailable = false;
            cts?.Cancel();
            asteroidSpawner.DisableAllAsteroids();
        }

        private void Update()
        {
            if (!isInputAvailable)
                return;

            // move ship
            ship.OnUpdate(Input.GetKey(KeyCode.Space));

            if (Utils.TryGetInScreenPosition(ship.Position, out var inScreenPosition))
                ship.Position = inScreenPosition;
        }
    }
}