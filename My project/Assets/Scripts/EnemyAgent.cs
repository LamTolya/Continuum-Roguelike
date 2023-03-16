public class EnemyAgent : Agent
{
    private void Start()
    {
        for(var i= 0; i < 1000; i++)
        {
            TalkAction talkAction = new TalkAction($"I am ENEMY! {i}");
            talkAction.Act();
        }
    }
}
