using System.Collections.Generic;
using UnityEngine;

public class Agent: MonoBehaviour
{
    [SerializeField]
    public List<BaseAction> actions;

    private void Awake()
    {
        actions = new List<BaseAction>();
    }

    private void Update()
    {
        foreach(BaseAction action in actions)
        {
            action.Act();
        }
    }

}
