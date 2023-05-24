using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPadlock : MonoBehaviour
{
    public GameObject padlock;

    public PickAndDropController key;

    public bool unlocked = false;
    void Unlock()
    {
        if (key.isPickedUp != true) return;

        padlock.GetComponent<Rigidbody>().isKinematic = false;

        unlocked = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                Unlock();
            }
        }
    }
}
