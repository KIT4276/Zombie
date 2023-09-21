using System;
using UnityEngine;

public class PostSystem 
{
    public event Action PostAppearanceE;
    public event Action PostGivenE;

    public void SpawnPost()
    {
        Debug.Log("SpatnPost");
        PostAppearanceE?.Invoke();
    }

    public void PostGiven()
    {
        PostGivenE?.Invoke();
    }
}
