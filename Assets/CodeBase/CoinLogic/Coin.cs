using AxGrid;
using AxGrid.Base;
using CodeBase.Sevices;
using UnityEngine;

[RequireComponent(typeof(SoundPlayService))]
public class Coin : MonoBehaviourExt
{
    [Header("Coin Visuals")]
    [SerializeField] private ParticlePlayerService particleService;
    [SerializeField] private SoundPlayService sfxPlayer;
    private Vector3 localScale;
    
    private bool canPlaySound;
    private bool isTaken;
    
    private TweenAnimationService animService;
    
    [OnAwake]
    private void Init()
    {
         animService = new TweenAnimationService();
         localScale = transform.localScale;
    }

    [OnEnable]
    private void EnableCoin()
    {
        isTaken = false; 
    }

    [OnDisable]
    private void DisableCoin()
    {
        if (canPlaySound)
        {
            sfxPlayer.PlaySound();
            Settings.Invoke("ShowCoinsTaken");
        }
    }

    public async void TakeCoin()
    {
        if (isTaken) return; 
        isTaken = true;
        canPlaySound = true;
        
        await particleService.PlayParticle();
        await animService.DestroyWithScaleAnimation(this.gameObject,0.5f, localScale);
        Settings.Invoke("ReturnCoin",this);
    }
}