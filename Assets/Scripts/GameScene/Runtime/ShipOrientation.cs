using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class ShipOrientation : MonoBehaviour
    {
        private Transform self;

        public Vector2 MoveDirection { get; private set; }

        private void Awake()
        {
            self = transform;
        }

        private void Update()
        {
            var mousePos = Input.mousePosition;
            mousePos.z = self.position.z;
            mousePos -= Utils.ScreenOffset;

            MoveDirection = (mousePos - self.position).normalized;

            self.LookAt(mousePos, self.up);
        }
    }
}