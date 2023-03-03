public class ScreenFlash: HealthFlash
{

    void Start()
    {
        Renderer.enabled = false;
    }
    public override void Flash()
    {
        base.Flash();
        Renderer.enabled = true;
        Invoke(nameof(Back), 0.17f);
    }

    public override void Back()
    {
        base.Back();
        Renderer.enabled = false;
    }
}
