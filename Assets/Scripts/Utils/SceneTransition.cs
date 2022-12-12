using UnityEngine.SceneManagement;

namespace AsteroidsTest.Utils
{
    public static class SceneTransition
    {
        public static void LoadScene(Scene scene)
        {
            SceneManager.LoadScene((int) scene, LoadSceneMode.Single);
        }

        public enum Scene
        {
            Main = 0,
            Game = 1,
        }
    }
}