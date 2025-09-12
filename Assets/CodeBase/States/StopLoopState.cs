using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using CodeBase.Constants;
[State("StopLoopState")]
public class StopLoopState : FSMState
{
    [One(0)]
    public void Enter()
    {
        Model.Set(ModelConstants.PLAYER_LOOTING_STATE,false);
    }
    [Bind("Exit")]
    public void Exit()
    {
        Settings.Invoke("EnableButton");
        Model.Set(ModelConstants.PLAYER_LOOTING_STATE,true);
        Parent.Change("GameLoopState");
    }
}