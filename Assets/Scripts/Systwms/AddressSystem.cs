using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddressSystem 
{
    private List<AddressComponent> _addreses;

    private PostSystem _postSystem;

    public void Init(List<AddressComponent> addressComponents, PostSystem postSystem)
    {
        _addreses = addressComponents;
        //postSystem.PostGivenE += PostAppearance;
        _postSystem = postSystem;
    }

    public void PostGiven()
    {
        var r = Random.Range(0, _addreses.Count);

        _addreses[r].gameObject.SetActive(true);
        _postSystem.PostGiven();
    }
}
