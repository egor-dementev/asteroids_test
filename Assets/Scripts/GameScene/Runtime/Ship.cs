using System;
using AsteroidsTest.GameScene.Data;
using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        private ShipOrientation orientation;

        private Transform self;
        private Vector3 speed;

        public Transform Transform => self;
        public Vector3 Position
        {
            get => self.position;
            set => self.position = value;
        }

        private void Awake()
        {
            self = transform;
        }

        public void OnUpdate(bool isAccelerating)
        {
            var delta = Vector3.zero;

            if (isAccelerating)
            {
                // add acceleration
                delta += orientation.MoveDirection * (GameConfig.Current.ShipAcceleration * Time.deltaTime);
            }
            
            // get deceleration
            delta -= speed * (GameConfig.Current.ShipDeceleration * Time.deltaTime);

            speed += delta;

            // clamp speed below Max speed
            var speedMagnitude = speed.magnitude;

            if (speedMagnitude > GameConfig.Current.ShipMaxSpeed)
                speed *= GameConfig.Current.ShipMaxSpeed / speedMagnitude;

            speedMagnitude = speed.magnitude;
            
            // check if speed is low
            if (speedMagnitude < .01f)
            {
                speed = Vector2.zero;
                return;
            }

            self.position += speed * Time.deltaTime;
        }
    }
}