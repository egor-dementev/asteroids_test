using UnityEngine;

namespace AsteroidsTest.GameScene.Runtime
{
    public class BgScroller : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

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

        public void SetOffset(Vector2 offset)
        {
            spriteRenderer.material.mainTextureOffset = offset;
        }

        public void ResetOffset()
        {
            spriteRenderer.material.mainTextureOffset = Vector2.zero;
        }
    }
}