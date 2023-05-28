using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUnlocker : MonoBehaviour
{
    public GameObject obstacle;

    public PickAndDropController item;

    public bool unlocked = false;

    public GameObject hiddenObject;
    public GameObject visibleObject;

    [SerializeField] private Material buttonColor;

    private void Start()
    {
        buttonColor.color = Color.red;
    }
    void Unlock()
    {
        if (item.isPickedUp != true) return;

        obstacle.GetComponent<Rigidbody>().isKinematic = false;

        unlocked = true;
    }

    void CutOff()
    {
        if (item.isPickedUp != true) return;

        unlocked = true;

        buttonColor.color = Color.green;

        visibleObject.active = false;
        hiddenObject.active = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (item.gameObject.tag != "Pincers")
                {
                    Unlock();
                }
                else
                {
                    CutOff();
                }
            }
        }
    }
}
