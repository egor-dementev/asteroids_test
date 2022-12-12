using AsteroidsTest.GameScene.Data;
using AsteroidsTest.GameScene.UI;
using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class Game : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        private CountDownWindow countDownWindow;
        [SerializeField]
        private GameOverWindow gameOverWindow;
        [Header("Gameplay")]
        [SerializeField]
        private GameplayController gameplayController; 

        private void Awake()
        {
            GameConfig.Current = GameConfig.DefaultConfig();
            GameModel.Current = GameModel.New();
        }

        private void Start()
        {
            InitNewGame();
        }

        private void InitNewGame()
        {
            countDownWindow.Hide();
            gameOverWindow.Hide();
            
            GameModel.Current.Reset();
            gameplayController.Init();

            countDownWindow.Show(3, StartGame);
        }

        private void StartGame()
        {
            countDownWindow.Hide();
            gameplayController.StartGame();
        }

        private void GameOver()
        {
            gameplayController.GameOver();
            gameOverWindow.Show(GameModel.Current.Score, InitNewGame);
        }
    }
}