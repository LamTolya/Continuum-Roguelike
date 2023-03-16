using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Enemy enemy;
    float Originalhealth;
    float add_scale;
    float lerp;
    float size_x;
    float new_scale;
    private void Start()
    {
        Originalhealth = enemy.GetHealth();
    }
    public void UpdateBar()
    {
        lerp = 0;
        add_scale = enemy.GetHealth() / Originalhealth;
        spriteRenderer.size = new Vector2(spriteRenderer.size.x * add_scale, spriteRenderer.size.y);
    }

    IEnumerator Lerp()
    {
        while(lerp < 1)
        {
            size_x = Mathf.Lerp(spriteRenderer.size.x, new_scale, lerp);
            spriteRenderer.size = new Vector2(size_x, spriteRenderer.size.y);
            lerp += 0.005f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
