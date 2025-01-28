public class GameWinPanel : EndGamePanel
{
    public override string AnimationName => "Win";

    protected override void OnEnable()
    {
        Victory.LevelFinished += OpenPanel;
    }

    protected override void OnDisable()
    {
        Victory.LevelFinished -= OpenPanel;
    }
}