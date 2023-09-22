using System.Collections.Generic;
using UnityEngine;

public class AddressSystem 
{
    private List<AddressComponent> _addreses;
    private PostSystem _postSystem;

    public void Init(List<AddressComponent> addressComponents, PostSystem postSystem)
    {
        _addreses = addressComponents;
        _postSystem = postSystem;
    }

    public void PostReceived()
    {
        var r = Random.Range(0, _addreses.Count);

        _addreses[r].gameObject.SetActive(true);
        _postSystem.PostReceived();
    }
}
