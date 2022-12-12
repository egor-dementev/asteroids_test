using AsteroidsTest.GameScene.Data;
using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField]
        private ShipOrientation orientation;

        private Vector2 speed;
        
        public void OnUpdate(bool isAccelerating)
        {
            var delta = Vector2.zero;

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
           
            // write player coords to model
            GameModel.Current.PlayerCoords += speed * Time.deltaTime;
        }
    }
}