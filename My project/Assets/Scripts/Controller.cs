using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public PlayerInput Input;
    [SerializeField] private PlayerStats playerStats;
    public Vector3 RawMovement { get; private set; }
    [Header("Current Velocity")]
    [SerializeField] private float HorizontalSpeed;
    [SerializeField] private float VerticalSpeed;

    [Header("Movement Calculation")]
    [SerializeField] private float moveClamp = 3;
    [SerializeField] private float deAcceleration = 60f;
    [SerializeField] public float acceleration = 90;

    private void Movement()
    {
        if (Input.X != 0)
        {
            HorizontalSpeed += Input.X * acceleration * Time.deltaTime;
            HorizontalSpeed = Mathf.Clamp(HorizontalSpeed, -moveClamp, moveClamp);
        }
        else
        {
            HorizontalSpeed = Mathf.MoveTowards(HorizontalSpeed, 0, deAcceleration);
        }

        if (Input.Y != 0)
        {
            VerticalSpeed += Input.Y * acceleration * Time.deltaTime;
            VerticalSpeed = Mathf.Clamp(VerticalSpeed, -moveClamp, moveClamp);
        }
        else
        {
            VerticalSpeed = Mathf.MoveTowards(VerticalSpeed, 0, deAcceleration);
        }
    }

    private void RawMove()
    {
        RawMovement = new Vector3(HorizontalSpeed, 0,VerticalSpeed);
        Vector3 move = RawMovement * Time.deltaTime;
        transform.position += move;
    }

    private void Update()
    {
        Movement();
        RawMove();
    }

    private void OnEnable()
    {
        PlayerStats.StatsChanged += UpdateSpeed;
    }
    private void OnDisable()
    {
        PlayerStats.StatsChanged -= UpdateSpeed;
    }

    void UpdateSpeed()
    {
        moveClamp = playerStats.Speed;
    }

    private void Start()
    {
        moveClamp = playerStats.Speed;
    }

    

}
