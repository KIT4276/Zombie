using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerImageBehaviour : BaseImageBehaviour
{
    private void OnEnable()
    {
        IsActive = true;
        _image = GetComponent<Image>();
        StartCoroutine(BlinkRoutine());
    }



}
