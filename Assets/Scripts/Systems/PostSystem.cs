using System;
using UnityEngine;

public class PostSystem 
{
    private bool _isSpawned;
    
    public event Action PostAppearanceE;
    public event Action PostReceivedE;
    public event Action PostGivenE;

    public void SpawnPost()
    {
        //Debug.Log("SpatnPost");
        
        if (!_isSpawned)
        {
            //Debug.Log("!_isSpawned SpatnPost");
            PostAppearanceE?.Invoke();
            _isSpawned = true;
        }
    }

    public void PostGiven()
    {
        PostGivenE?.Invoke();
        _isSpawned = false;
    }

    public void PostReceived()
    {
        PostReceivedE?.Invoke();
        //_isSpawned = false;
    }
}
