using UnityEngine;

public class HealthFlash: MonoBehaviour
{
    [SerializeField] protected Material FlashMaterial;
    [SerializeField] protected Material WhiteFlash;
    [SerializeField] protected Material NormalMaterial;

    protected SpriteRenderer Renderer;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    public void Flash() 
    {
        if(Renderer != null)
        {
            Renderer.material = FlashMaterial;
            Invoke(nameof(FlashWhite), 0.2f);
        }
        else
        {
            Debug.LogError("No SpriteRenderer found to flash. (miss reference?)");
        }
       
    }
    private void FlashWhite()
    {
        Renderer.material = WhiteFlash;
        Invoke(nameof(Back), 0.07f);
    }
    private void Back() 
    {
        Renderer.material = NormalMaterial;
    }

}
