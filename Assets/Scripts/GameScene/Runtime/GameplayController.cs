using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField]
        private BgScroller bgScroller;
        [SerializeField]
        private Ship ship;
        [SerializeField]
        private Transform[] spawners;

        private bool isInputAvailable;

        public void Init()
        {
        }
        
        public void StartGame()
        {
            isInputAvailable = true;
        }

        public void GameOver()
        {
            isInputAvailable = false;
        }

        private void Update()
        {
            if (!isInputAvailable)
                return;

            // move ship
            ship.OnUpdate(Input.GetKey(KeyCode.Space));

            if (Utils.IsOffScreen(ship.Position, out var inScreenPosition))
                ship.Position = inScreenPosition;
        }
    }
}