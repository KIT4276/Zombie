using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseImageBehaviour : MonoBehaviour
{
    //[SerializeField]
    protected Image _image;

    [SerializeField]
    protected Vector3 _blinkScaleV3;
    

    [SerializeField]
    protected float _blinkTime = 0.5f;
    //[SerializeField]
    //protected float _blinkScale = 1.5f;
    [SerializeField]
    protected Color _blinkColor;
    [SerializeField]
    protected Color _startColor;
    [SerializeField] 
    protected bool IsActive;

    //protected void Awake()
    //{
    //    _image = GetComponent<Image>();
    //    _startColor = _image.color;
    //}

    //protected virtual void Start()
    //{
    //    _image = GetComponent<Image>();

    //    _blinkScaleV3 = new Vector3(_blinkScale, _blinkScale, _blinkScale);
        
    //}


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
        Debug.Log("!IsActive" + this.name);
    }
}
