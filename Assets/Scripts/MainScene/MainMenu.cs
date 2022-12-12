using AsteroidsTest.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button startButton;

        private void Awake()
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() => SceneTransition.LoadScene(SceneTransition.Scene.Game));
        }
    }
}