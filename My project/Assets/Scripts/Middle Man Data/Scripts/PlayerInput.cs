using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


[CreateAssetMenu(fileName = "PlayerInput", menuName = "Player/Player Input", order = 3)]
public class PlayerInput : ScriptableObject
{

    [SerializeField] private KeyCode keyCode = KeyCode.E;
    [SerializeField] private KeyCode enviromentKeyCode = KeyCode.F;

    public static event Action ClickEvent;
    public static event Action KeyEvent;
    public static event Action EnviromentKeyEvent;

    public float X { get; set; }
    public float Y { get; set; }
    public bool KeyUp { get; set; }
    public bool MouseClick { get; set; }

    private bool EnviromentKeyUp;

    public void Update()
    {
        GatherInput();
        ClickInput();
        KeyInput();
        EnviromentKeyInput();
    }
    private void GatherInput()
    {
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");
        KeyUp = Input.GetKeyUp(keyCode);
        MouseClick = Input.GetMouseButtonDown(0);
        EnviromentKeyUp = Input.GetKey(enviromentKeyCode);
    }

    private void ClickInput()
    {
        if (MouseClick)
        {
            ClickEvent?.Invoke();
        }
    }

    private void KeyInput()
    {
        if (KeyUp)
        {
            KeyEvent?.Invoke();
        }
    }

    private void EnviromentKeyInput()
    {
        if (EnviromentKeyUp)
        {
            EnviromentKeyEvent?.Invoke();
        }
    }
}
