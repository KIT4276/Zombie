using Zenject;

public class PostTrigger : BaseTrigger
{
    [Inject]
    private AddressSystem _adresSystem;
    
    public void PostTriggerEnter()
    {
        _adresSystem.PostReceived();
    }
}
