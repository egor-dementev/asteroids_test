using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AsteroidsTest.GameScene.UI
{
    public class GameOverWindow : BaseWindow<int, UnityAction>
    {
        [SerializeField]
        private TMP_Text score;
        [SerializeField]
        private Button restartButton;
        
        protected override void OnShow(int scoreValue, UnityAction callback)
        {
            score.text = $"Your score is: {scoreValue}";
            
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(callback);
        }
    }
}