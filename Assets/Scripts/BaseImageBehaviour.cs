using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BaseImageBehaviour : MonoBehaviour
{
    protected Image _image;

    [SerializeField]
    protected Vector3 _blinkScaleV3;

    [SerializeField]
    protected float _blinkTime = 0.5f;
    [SerializeField]
    protected Color _blinkColor;
    [SerializeField]
    protected Color _startColor;
    [SerializeField] 
    protected bool IsActive;

    protected IEnumerator BlinkRoutine()
    {
        while (IsActive)
        {
            _image.DOColor(_blinkColor, _blinkTime);
            Tween tween = _image.rectTransform.DOScale(_blinkScaleV3, _blinkTime);

            yield return tween.WaitForCompletion();

            _image.DOColor(_startColor, _blinkTime);
            tween = _image.rectTransform.DOScale(new Vector3(1, 1, 1), _blinkTime);

            yield return tween.WaitForCompletion();
        }
    }
}
