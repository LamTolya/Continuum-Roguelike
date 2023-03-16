using UnityEngine;

public class TalkAction: BaseAction
{
    private string message;
    public TalkAction(string _message)
    {
        message = _message;
    }
    public override void Act()
    {
        Debug.Log(message);
    }
}

public class MoveAction : BaseAction
{
    private Vector3 Target;
    public MoveAction(Vector3 target)
    {
        Target = target;
    }

    private void Update()
    {
        
    }
}