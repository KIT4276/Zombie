using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PostTrigger : BaseTrigger
{
    [Inject]
    private AddressSystem _adresSystem;
    
    public void PostTriggerEnter()
    {
        //Debug.Log("PostTriggerEnter");
        _adresSystem.PostReceived();
    }
}
