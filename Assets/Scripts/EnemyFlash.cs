using UnityEngine;

public class EnemyFlash: HealthFlash
{
    [SerializeField] private SpriteRenderer SpriteRenderer;
    private void OnEnable()
    {
        Renderer = SpriteRenderer;
    }
}
