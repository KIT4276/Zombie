using System;

public class PostSystem 
{
    private bool _isSpawned;

    public event Action PostAppearanceE;
    public event Action PostReceivedE;
    public event Action PostGivenE;

    public float DeliveredCount { get; private set; }

    public void SpawnPost()
    {
        if (!_isSpawned)
        {
            PostAppearanceE?.Invoke();
            _isSpawned = true;
        }
    }

    public void PostGiven()
    {
        DeliveredCount++;
        PostGivenE?.Invoke();
        _isSpawned = false;
    }

    public void PostReceived()
    {
        PostReceivedE?.Invoke();
    }
}
