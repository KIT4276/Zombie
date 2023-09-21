using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;


public class PostImageBehaviour : BaseImageBehaviour
{
    [Inject]
    private PostSystem _postSystem;

    private  void Start()
    {
        //base.Start();
        _image = GetComponent<Image>();
        _postSystem.PostAppearanceE += OnBlink;
        _postSystem.PostGivenE += OffBlink;
    }


    private void OnBlink()
    {
        IsActive = true;
        StartCoroutine(BlinkRoutine());
    }

    private void OffBlink()
    {
        IsActive = false;
    }

    private void OnDestroy()
    {
        _postSystem.PostAppearanceE -= OnBlink;
        _postSystem.PostGivenE -= OffBlink;
    }
}
