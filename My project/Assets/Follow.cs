using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] private Transform targetRotate;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
        transform.rotation = targetRotate.rotation;
    }
}
