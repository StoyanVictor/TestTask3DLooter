using AxGrid.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;
public class ParticlePlayerService : MonoBehaviourExt
{
    [SerializeField] private ParticleSystem particles;

    public async UniTask PlayParticle()
    {
        particles.Play();
        float totalTime = particles.main.duration + particles.main.startLifetime.constantMax;
        await UniTask.Delay(System.TimeSpan.FromSeconds(totalTime), cancellationToken: this.GetCancellationTokenOnDestroy());  
    }
}