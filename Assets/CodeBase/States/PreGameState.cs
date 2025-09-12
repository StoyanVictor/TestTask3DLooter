using AxGrid.FSM;
using AxGrid.Model;

[State("PreGameState")]
public class PreGameState : FSMState
{
    [One(1)]
    public void Enter()
    {
    }
    [Bind("Exit")]
    public void Exit()
    {
        Parent.Change("LoadingGameState");
    }
}