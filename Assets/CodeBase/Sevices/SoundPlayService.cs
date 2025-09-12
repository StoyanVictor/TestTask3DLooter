using AxGrid.Base;
using UnityEngine;
namespace CodeBase.Sevices
{
    public class SoundPlayService : MonoBehaviourExt
    {
        [SerializeField] private AudioClip sound;
        
        public void PlaySound()
        {
            AudioManager.Instance.PlaySFX(sound);
        }
    }
}