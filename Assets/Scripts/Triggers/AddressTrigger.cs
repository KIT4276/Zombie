using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddressTrigger : BaseTrigger
{
    //[SerializeField]
    //private GameObject _adres;
    private AddressComponent _addressComponent;
    //private int _id;
    [Inject]
    private PostSystem _postSystem;

    private void Awake()
    {
       _addressComponent = GetComponent<AddressComponent>();
    }

    public void AdresTriggerEnter()
    {
         Debug.Log("AdresTriggerEnter " + "id " + _addressComponent.GetId());
        this.gameObject.SetActive(false);
        _postSystem.PostGiven();


    }
}
