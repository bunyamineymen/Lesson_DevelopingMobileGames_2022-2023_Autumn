
using DG.Tweening;

using UnityEngine;

public class Demo7_Object1 : MonoBehaviour
{

    private void Start()
    {

        Tween tween =
         transform.DOMoveX(2f, 2f)
        .SetRelative(false) // move to relative position
        .SetEase(Ease.OutQuad)
        .SetDelay(5f)
        .SetSpeedBased(false) // zaman yerine hiz
        .SetId("PlayerMove")
        .SetLoops(5, LoopType.Yoyo);

        tween.onComplete = delegate { Debug.Log("onComplete"); };
        tween.onStepComplete = delegate { Debug.Log("onStepComplete"); };
        tween.onKill = delegate { Debug.Log("onKill"); };

        tween.Play();


        transform.DORotate(Vector3.up * 360, 2, RotateMode.FastBeyond360)
            .SetLoops(5, LoopType.Yoyo)
            .SetEase(Ease.Linear);

    }
}
