
using UnityEngine;


public class PickAndDropController : MonoBehaviour
{
    public GameObject item;
    public Transform itemParent;

    public bool isPickedUp = false;

    void Start()
    {
        item.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && isPickedUp == true)
        {
            Drop();
        }
    }

    void Drop()
    {
        isPickedUp = false;

        itemParent.DetachChildren();
        item.transform.eulerAngles = new Vector3(item.transform.position.x, item.transform.position.z, item.transform.position.y);
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<MeshCollider>().enabled = true;

    }

    void Equip()
    {
        isPickedUp = true;

        item.GetComponent<Rigidbody>().isKinematic = true;

        item.transform.position = itemParent.transform.position;
        item.transform.rotation = itemParent.transform.rotation;

        item.GetComponent<MeshCollider>().enabled = false;

        item.transform.SetParent(itemParent);

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Equip();
            }
        }
    }
}
