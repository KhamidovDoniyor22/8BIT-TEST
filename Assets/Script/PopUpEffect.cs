using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopUpEffect : MonoBehaviour
{
    public Vector3 startScale = Vector3.zero;
    public Vector3 endScale = Vector3.one;
    public float duration = 0.5f;
    public Ease easeType = Ease.OutBack;
    public bool canOut;
    public float outDelay;
    public UnityEvent outterEvent;
    void OnEnable()
    {
        transform.localScale = startScale;

        if(canOut)
        {
            transform.DOScale(endScale, duration).SetEase(easeType).OnComplete(()=>Invoke(nameof(Outter),outDelay));
        }
        else
        {
            transform.DOScale(endScale, duration).SetEase(easeType);
        }
    }
    public void Outter()
    {
        transform.DOScale(startScale, duration).SetEase(easeType).OnComplete(()=>outterEvent.Invoke());
    }
}
