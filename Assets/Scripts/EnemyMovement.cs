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
    bool TargetReached = false;

    [SerializeField] private float minDistance;
    [Range(0.03f, 18f)]
    [SerializeField] float movementDelay;
    float distance;
    bool Attacked;
  
    private void OnEnable()
    {
        StartCoroutine(RandomPos());
        LoadPosition.PlayerLoaded += SetPlayer;
    }

    private void OnDisable()
    {
        LoadPosition.PlayerLoaded -= SetPlayer;
    }

    void SetPlayer(Player player)
    {
        Player = player.gameObject.transform;
    }

    private void LateUpdate()
    {
        Move();
        Debug.DrawLine(transform.position, Target);

    }

    public virtual void Move()
    {
        if (transform.position == Target) return;
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
    }


    IEnumerator RandomPos()
    {
        while (true)
        {
            UpdateTarget();
            yield return new WaitForSeconds(movementDelay);
        }
      
    }
    
    public void SetTarget(Vector3 target)
    {
        Target = target;
    }

    public void BackTarget()
    {
        distance = (transform.position - Player.position).sqrMagnitude;
        if (minDistance > distance)
        {

            Target = Player.position;
        }
      
    }
    
    public void UpdateTarget()
    {
        Target = GetTarget();
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





