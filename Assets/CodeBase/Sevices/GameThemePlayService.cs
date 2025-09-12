using AxGrid.Base;
using UnityEngine;

public class GameThemePlayService : MonoBehaviourExt
{
    [SerializeField] private AudioClip bgm;
    
    [OnStart]
    private void PlayBgm()
    {
        AudioManager.Instance.PlayMusic(bgm);
    }
}