using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent (typeof(Params))]
public class EntryPoint : MonoBehaviour
{
    private Params _params;

    [SerializeField]
    private List<AddressComponent> _adresComponents;


    [Inject]
    private PostSystem _postSystem;
    [Inject]
    private AddressSystem _adresSystem;
    
    private void Start()
    {
        _params = GetComponent<Params>();

        for (int i = 0; i < _adresComponents.Count; i++)
        {
            _adresComponents[i].SetID(i);
            _adresComponents[i].gameObject.SetActive(false);
        }

        _adresSystem.Init(_adresComponents, _postSystem);
        StartCoroutine(DelayRoutine());
    }

    private IEnumerator DelayRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(RandomTime());
            _postSystem.SpawnPost();
        }
    }

    private float RandomTime()
    {
        var deviation = _params.GetPostSpawnTime() * _params.GetPostDeviation()/100;
        var r = Random.Range(_params.GetPostSpawnTime() - deviation, _params.GetPostSpawnTime() + deviation);
        return r;
    }
}
