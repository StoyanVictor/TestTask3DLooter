using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
namespace CodeBase.Sevices
{
    public  class TweenAnimationService
    {
        public void ShakeButton(GameObject button,float duration,int vibrato,float strength,float randomness)
        {
            DOTween.Kill(button.transform);
            button.transform.DOShakeScale(duration, strength, vibrato, randomness)
                .SetId(button.transform);
        }

            public async UniTask DestroyWithScaleAnimation(GameObject obj, float animDuration,Vector3 initalScale, CancellationToken token = default)
            {
                Vector3 startScale = obj.transform.localScale;
                Vector3 targetScale = Vector3.zero;

                float elapsed = 0f;

                while (elapsed < animDuration && obj != null)
                {
                    elapsed += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsed / animDuration);

                    obj.transform.localScale = Vector3.Lerp(startScale, targetScale, t);

                    await UniTask.Yield(PlayerLoopTiming.Update, token);
                }

                if (obj != null)
                    obj.transform.localScale = initalScale;
            }

    }
}