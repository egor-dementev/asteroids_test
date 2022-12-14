using UnityEngine;

namespace AsteroidsTest.GameScene
{
    public static class Utils
    {
        public static Vector2 CameraSize;
        public static Vector2 CameraSizeDoubled;
        public static Vector3 ScreenResolution = new Vector2(Screen.width, Screen.height);
        public static Vector3 ScreenHalf = new Vector2(Screen.width / 2, Screen.height / 2);

        public static void SetCameraSize(float ySize)
        {
            if (CameraSize != default)
                return;
            
            var xSize = ScreenResolution.x * ySize / ScreenResolution.y;
            CameraSize = new Vector2(xSize, ySize);
            CameraSizeDoubled = CameraSize * 2;
        }

        public static bool IsOffScreen(Vector3 position, out Vector3 inScreenPosition)
        {
            inScreenPosition = position;
            var isOffScreen = false;

            if (Mathf.Abs(position.x) > CameraSize.x)
            {
                isOffScreen = true;
                
                if (position.x > 0)
                    inScreenPosition.x -= CameraSizeDoubled.x;
                else
                    inScreenPosition.x += CameraSizeDoubled.x;
            }

            if (Mathf.Abs(position.y) > CameraSize.y)
            {
                isOffScreen = true;

                if (position.y > 0)
                    inScreenPosition.y -= CameraSizeDoubled.y;
                else
                    inScreenPosition.y += CameraSizeDoubled.y;
            }

            return isOffScreen;
        }

        public static Vector3 MakeOffScreenGhostPosition(Vector3 targetPos)
        {
            var position = targetPos;
            
            if (targetPos.x > 0)
                position.x -= CameraSizeDoubled.x;
            else
                position.x += CameraSizeDoubled.x;

            if (targetPos.y > 0)
                position.y -= CameraSizeDoubled.y;
            else
                position.y += CameraSizeDoubled.y;

            return position;
        }
    }
}