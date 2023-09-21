using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params : MonoBehaviour
{
    [SerializeField, Tooltip("Post Spawn Timer")]
    private int _postSpawnTime = 15;
    [SerializeField]
    private float _deviationPercent = 10;

    #region GetMethods

    public int GetPostSpawnTime() => _postSpawnTime;

    public float GetPostDeviation() => _deviationPercent;

    #endregion GetMethods
}
