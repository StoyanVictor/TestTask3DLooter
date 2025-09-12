using AxGrid.Base;
using UnityEngine;
using UnityEngine.UI;
namespace CodeBase.Sevices
{
    public class ButtonAnimationService : MonoBehaviourExt
    {
        [SerializeField] private Button button;
        [SerializeField] private SoundPlayService soundService;
        [SerializeField] private float duration = 0.3f;
        [SerializeField] private float strength = 0.2f;
        [SerializeField] private int vibrato = 10;
        [SerializeField] private float randomness = 90f;
        private TweenAnimationService animationService;

        [OnAwake]
        private void Init()
        {
            animationService = new TweenAnimationService();
            button.onClick.AddListener(() => animationService.ShakeButton(button.gameObject,duration,vibrato,strength,randomness));
            button.onClick.AddListener(() => soundService.PlaySound());
        }
    }
}