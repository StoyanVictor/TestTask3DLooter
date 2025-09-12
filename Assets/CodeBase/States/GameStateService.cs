using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using UnityEngine;

public class GameStateService : MonoBehaviourExt
{
    public void CreateFSM()
    {
        Settings.Fsm = new FSM();
        Settings.Fsm.Add(new GameLoopState());
        Settings.Fsm.Add(new StopLoopState());
        Settings.Fsm.Add(new PreGameState());
        Settings.Fsm.Add(new LoadingGameState());
        StartState();
    }
    
    private void StartState()
    { 
        Settings.Fsm.Start("PreGameState");
    }

    [OnUpdate]
    public void UpdateFsm()
    {
        Settings.Fsm.Update(Time.deltaTime); // Необходимо для работы таймеров
    }
}