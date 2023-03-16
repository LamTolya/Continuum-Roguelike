using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private float length, startPos;
    [SerializeField] private Transform Cam;
    [SerializeField] private float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = (Cam.position.x * (1 - parallaxEffect));
        float dist = (Cam.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
