using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStop : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private PlayerInput playerInput;
    private Controller controller;
    Vector3 direction;

    private void Start()
    {
        controller = GetComponent<Controller>();
    }
    private void Update()
    {
        if(playerInput != null)
        { 
            Check(playerInput.X, playerInput.Y);
        }
       
    }
    void Check(float X, float Y)
    {
        direction = new Vector3(X, 0, Y);
        if (Physics.Raycast(transform.position, direction, out hit, 0.5f))
        {
            if (hit.collider.gameObject.layer == 6)
            {
                controller.enabled = false;
                Debug.Log("wall tuh");
            }
            
        }
        else
        {
            controller.enabled = true;
        }
    }
}
