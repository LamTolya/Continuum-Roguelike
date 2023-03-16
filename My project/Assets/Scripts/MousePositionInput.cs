using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionInput : MonoBehaviour
{
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }

    private void GatherInput()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
    }

    private void Update()
    {
        GatherInput();
    }

}
