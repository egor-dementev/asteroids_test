using AsteroidsTest.GameScene.Data;
using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField]
        private BgScroller bgScroller;
        [SerializeField]
        private PlayerShip ship;

        private bool isInputAvailable;

        public void Init()
        {
            bgScroller.ResetOffset();
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

            // imitate ship movement by offsetting background
            ship.OnUpdate(Input.GetKey(KeyCode.Space));
            bgScroller.SetOffset(GameModel.Current.PlayerCoords);
        }
    }
}