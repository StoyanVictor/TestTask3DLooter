using AxGrid.FSM;
using AxGrid.Model;
using CodeBase.Sevices;

[State("LoadingGameState")]
public class LoadingGameState : FSMState
{
    [One(1)]
    public void Enter()
    {
        SceneLoadingService.LoadScene();
        Parent.Change("StopLoopState");
    }
    [Bind("Exit")]
    public void Exit()
    {
    }
}