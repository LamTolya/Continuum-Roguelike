using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private Transform Player;
    [Range(1,7)]
    [SerializeField] private float DeltaRandom;
    [SerializeField]
    public Vector3 Target;
    [SerializeField]
    bool TimerReached = true;

    [SerializeField] private float minDistance;
    [Range(0.03f, 18f)]
    [SerializeField] float MovementDelay;
    float distance;
    private void OnEnable()
    {
        SceneManager.PlayerLoaded += SetPlayer;
        StartCoroutine(RandomPos());
    }

    private void OnDisable()
    {
        SceneManager.PlayerLoaded -= SetPlayer;
    }
    void SetPlayer(Player player)
    {
        Player = player.gameObject.transform;
    }


    private void Start()
    {
        MovementDelay += UnityEngine.Random.Range(-0.01f, 0.05f);
    }

    private void LateUpdate()
    {
        if(transform.position == Target && TimerReached)
        {
            StartCoroutine(nameof(RandomPos));
        }
        Move();
    }
    // experimenting without While cycle in Move()
    public virtual void Move()
    {
        if (transform.position == Target) return;
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
    }

    IEnumerator RandomPos()
    {
        TimerReached = false;
        UpdateTarget();
        yield return new WaitForSeconds(MovementDelay);
        TimerReached = true;
    }
    
    public void SetTarget(Vector3 target)
    {
        Target = target;
    }

    public void BackTarget()
    {
        distance = (transform.position - Player.position).sqrMagnitude;
        if (minDistance > distance && Player != null)
        {
            Target = Player.position;
        }
      
    }
    
    public void UpdateTarget()
    {
        if(Player != null) Target = GetTarget();
    }

    Vector3 GetTarget()
    {
        distance = (transform.position - Player.position).sqrMagnitude;
        if (minDistance > distance)
        {
            return (Player.position) - new Vector3(UnityEngine.Random.Range(-DeltaRandom, DeltaRandom), 0f, UnityEngine.Random.Range(-DeltaRandom, DeltaRandom));
        }
        return Player.position + new Vector3(UnityEngine.Random.Range(-DeltaRandom, DeltaRandom), 0f, UnityEngine.Random.Range(-DeltaRandom, DeltaRandom));
    }

}





