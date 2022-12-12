using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace AsteroidsTest.GameScene.UI
{
    public class CountDownWindow : BaseWindow<float, Action>
    {
        [SerializeField]
        private TMP_Text countDown;

        protected override void OnShow(float seconds, Action callback)
        {
            StartCoroutine(CountDownRoutine(seconds, callback));
        }

        private IEnumerator CountDownRoutine(float seconds, Action callback)
        {
            while (seconds > 0)
            {
                countDown.text = seconds.ToString("F0");
                
                yield return null;

                seconds -= Time.deltaTime;

                if (seconds < 0)
                {
                    countDown.text = "0";

                    break;
                }
            }
            
            callback?.Invoke();
        }
    }
}