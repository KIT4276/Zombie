using DG.Tweening;
using System.Collections;
using UnityEngine;

public class HighlightBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Color _startColor;
    [SerializeField]
    protected Color _blinkColor;
    [SerializeField]
    protected float _blinkTime = 0.6f;
    [SerializeField]
    private Material _material;

    private void OnEnable()
    {
        StartCoroutine(BlinkRoutine());
    }

    protected IEnumerator BlinkRoutine()
    {
        while (true)
        {
            Tween tween = _material.DOColor(_blinkColor, _blinkTime);
            yield return tween.WaitForCompletion();
            tween = _material.DOColor(_startColor, _blinkTime);
            yield return tween.WaitForCompletion();
        }
    }
}
