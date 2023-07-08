using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_light : MonoBehaviour
{
    public GameObject light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            light.SetActive(true);
    }
}
