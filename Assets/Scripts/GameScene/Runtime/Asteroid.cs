using System;
using System.Collections;
using AsteroidsTest.GameScene.Data;
using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class Asteroid : MonoBehaviour
    {
        private Transform self;
        private Action<Asteroid> onDisable;

        private void Awake()
        {
            self = transform;
        }

        public void FlyTo(Vector3 target, float speedLerp, Action<Asteroid> onDisable)
        {
            this.onDisable = onDisable;
            gameObject.SetActive(true);
            
            StopAllCoroutines();
            StartCoroutine(FlyRoutine(target, speedLerp));
        }
        
        private IEnumerator FlyRoutine(Vector3 target, float speedLerp)
        {
            var direction = (target - self.position).normalized;
            var speed = Mathf.Lerp(
                GameConfig.Current.AsteroidMinSpeed,
                GameConfig.Current.AsteroidMaxSpeed,
                speedLerp
            );

            while (!Utils.IsOffScreen(self.position, 2))
            {
                yield return null;

                self.transform.position += direction * (speed * Time.deltaTime);
            }

            Disable();
        }

        public void Disable()
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
            onDisable?.Invoke(this);
        }
    }
}