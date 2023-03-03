using UnityEngine;

public class HealthFlash: MonoBehaviour
{
    [SerializeField] protected Material FlashMaterial;
    [SerializeField] protected Material NormalMaterial;

    protected SpriteRenderer Renderer;

    private void OnEnable()
    {
        Player.PlayerDamaged += Flash;
        Renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnDisable()
    {
        Player.PlayerDamaged -= Flash;
    }

    public virtual void Flash() { }
    public virtual void Back() { }

}
