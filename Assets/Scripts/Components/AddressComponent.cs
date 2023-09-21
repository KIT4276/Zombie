using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AddressTrigger))]
public class AddressComponent : MonoBehaviour
{
    [SerializeField]
    private int _id;
    private AddressTrigger _trigger;

    [SerializeField]
    private Canvas _marker;

    private void Awake()
    {
        _trigger = GetComponent<AddressTrigger>();
    }

    #region GetMethods

    public int GetId() => _id;

    public AddressTrigger GetAdresTrigger() => _trigger;

    public Canvas GetMarker() => _marker;

    #endregion GetMethods

    public void SetID(int value) => _id = value;
}
