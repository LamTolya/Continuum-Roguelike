using UnityEngine;
public class PlayerFlash: HealthFlash
{
    private void OnEnable()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Player.PlayerDamaged += Flash;
    }

    private void OnDisable()
    {
        Player.PlayerDamaged -= Flash;
    }
}
