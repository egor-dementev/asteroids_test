using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class BgScroller : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Vector2 speed = new Vector2(.1f, .05f);

        private Material mat;
        
        private void OnValidate()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Awake()
        {
            mat = Instantiate(spriteRenderer.material);
            spriteRenderer.material = mat;
        }

        private void Update()
        {
            spriteRenderer.material.mainTextureOffset += speed * Time.deltaTime;
        }
    }
}