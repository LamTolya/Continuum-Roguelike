using UnityEngine;
public class PlayerFlash: HealthFlash
{
    [SerializeField] private Material WhiteFlash;
    public override void Flash()
    {
        base.Flash();
        Renderer.material = FlashMaterial;
        Invoke(nameof(FlashWhite), 0.2f);
    }

    void FlashWhite()
    {
        Renderer.material = WhiteFlash;
        Invoke(nameof(Back), 0.07f);
    }

    public override void Back()
    {
        base.Back();
        Renderer.material = NormalMaterial;
    }
}
