using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AsteroidsTest.GameScene.Data;
using UnityEngine;
using Random = System.Random;

namespace AsteroidsTest.GameScene.Runtime
{
    public class AsteroidSpawner
    {
        private Transform ship;
        private Transform[] spawnPoints;
        private Asteroid prefab;
        private int curSpawnPointIndex;
        private Random rnd = new Random();
        private List<Asteroid> inactiveAsteroids = new List<Asteroid>();
        private List<Asteroid> activeAsteroids = new List<Asteroid>();
        
        public AsteroidSpawner(Transform ship, Transform[] spawnPoints, Asteroid prefab)
        {
            this.ship = ship;
            this.spawnPoints = spawnPoints;
            this.prefab = prefab;
        }

        public void DisableAllAsteroids()
        {
            while (activeAsteroids.Count > 0)
                activeAsteroids[0].Disable();
        }

        public async void SpawnAsteroids(CancellationTokenSource cts)
        {
            curSpawnPointIndex = 0;
            
            while (!cts.IsCancellationRequested)
            {
                SpawnAsteroid();
                await Task.Delay(1000 * GameConfig.Current.AsteroidSpawnDelay);
            }
        }

        private void SpawnAsteroid()
        {
            // todo add some randomness to spawn point selection
            if (++curSpawnPointIndex >= spawnPoints.Length)
                curSpawnPointIndex = 0;

            var asteroid = GetAsteroid();
            asteroid.transform.position = spawnPoints[curSpawnPointIndex].position;
            asteroid.FlyTo(ship.position, (float) rnd.NextDouble(), DisableAsteroid);
        }

        private Asteroid GetAsteroid()
        {
            Asteroid asteroid;
            
            if (inactiveAsteroids.Count > 0)
            {
                asteroid = inactiveAsteroids[0];
                inactiveAsteroids.RemoveAt(0);
            }
            else
            {
                asteroid = Object.Instantiate(prefab);
            }

            activeAsteroids.Add(asteroid);

            return asteroid;
        }

        private void DisableAsteroid(Asteroid asteroid)
        {
            activeAsteroids.Remove(asteroid);
            inactiveAsteroids.Add(asteroid);
        }
    }
}