using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using CodeBase.Constants;

[State("GameLoopState")]
public class GameLoopState : FSMState
{
    [One(0)]
    public void Enter()
    {
        Model.Set(ModelConstants.PLAYER_LOOTING_STATE, true);
    }
    
    [Bind("Exit")]
    public void Exit()
    {
        Settings.Invoke("EnableButton");
        Model.Set(ModelConstants.PLAYER_LOOTING_STATE, false);
        Parent.Change("StopLoopState");
    }
}