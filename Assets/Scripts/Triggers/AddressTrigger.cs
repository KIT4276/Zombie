using Zenject;

public class AddressTrigger : BaseTrigger
{
    private AddressComponent _addressComponent;

    [Inject]
    private PostSystem _postSystem;

    private void Awake()
    {
       _addressComponent = GetComponent<AddressComponent>();
    }

    public void AdresTriggerEnter()
    {
        _postSystem.PostGiven();
        this.gameObject.SetActive(false);
    }
}
