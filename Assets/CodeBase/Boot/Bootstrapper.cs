using AxGrid.Base;
using CodeBase.Constants;
using UnityEngine;
public class Bootstrapper : MonoBehaviourExt
{
    [SerializeField]
    private GameStateService gameStateService;
    
    [OnStart]
    private void Init()
    {
        Model.Set(ModelConstants.PLAYER_LOOTING_STATE, false);
        gameStateService.CreateFSM();
        DontDestroyOnLoad(this);
    }

}