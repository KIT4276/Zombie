using TMPro;
using UnityEngine;
using Zenject;

public class DeliveredCount : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    [Inject]
    private PostSystem _postSystem;

    private void Start()
    {
        _postSystem.PostGivenE += UpdateDeliveredCount;
    }

    private void UpdateDeliveredCount()
    {
        _text.text = _postSystem.DeliveredCount.ToString();
    }
}
