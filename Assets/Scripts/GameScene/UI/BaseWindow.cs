using UnityEngine;

namespace AsteroidsTest.GameScene.UI
{
    public abstract class BaseWindow<T1, T2> : BaseWindow
    {
        public void Show(T1 t1, T2 t2)
        {
            Show();
            OnShow(t1, t2);
        }

        protected virtual void OnShow(T1 t1, T2 t2)
        {
        }
    }
    
    public abstract class BaseWindow<T> : BaseWindow
    {
        public void Show(T t)
        {
            Show();
            OnShow(t);
        }

        protected virtual void OnShow(T t)
        {
        }
    }
    
    public abstract class BaseWindow : MonoBehaviour
    {
        private void Awake()
        {
            // in case I forget disabling it :)
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}