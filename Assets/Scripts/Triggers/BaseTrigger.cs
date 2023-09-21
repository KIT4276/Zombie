using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{
    protected void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }
}
