using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tp_to_checkpoint : MonoBehaviour
{
    [SerializeField] Transform checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
                other.transform.position = checkpoint.transform.position;
                cc.enabled = true;
            }
            else
            {
                other.transform.position = checkpoint.transform.position;
            }
        }
    }
}
