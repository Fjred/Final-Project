using UnityEngine;

public class PickAndDropController : MonoBehaviour
{
    public GameObject item;
    public Transform itemParent;
    public bool isPickedUp = false;
    public float raycastRange = 3f; // Maximum distance for raycast

    private static GameObject currentItem; // Track the currently picked up item

    void Start()
    {
        item.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && isPickedUp)
        {
            Drop();
        }
    }

    void Drop()
    {
        isPickedUp = false;

        currentItem.transform.parent = null;
        currentItem.transform.localScale = Vector3.one; // Reset local scale to (1, 1, 1)
        currentItem.transform.eulerAngles = new Vector3(currentItem.transform.position.x, currentItem.transform.position.z, currentItem.transform.position.y);
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<MeshCollider>().enabled = true;

        currentItem = null; // Reset the currently picked up item reference
    }

    void Equip()
    {
        if (!isPickedUp && currentItem == null)
        {
            isPickedUp = true;

            item.GetComponent<Rigidbody>().isKinematic = true;

            item.transform.position = itemParent.transform.position;
            item.transform.rotation = itemParent.transform.rotation;

            item.GetComponent<MeshCollider>().enabled = false;

            item.transform.parent = itemParent;

            currentItem = item; // Set the currently picked up item reference
        }
    }

    void TryPickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastRange))
        {
            PickAndDropController otherPickUpController = hit.collider.GetComponent<PickAndDropController>();

            if (otherPickUpController != null && otherPickUpController != this && otherPickUpController.isPickedUp)
            {
                // If another item is already picked up, return without picking up this item
                return;
            }

            if (hit.collider.gameObject == item)
            {
                Equip();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isPickedUp && Input.GetKey(KeyCode.E))
        {
            TryPickUp();
        }
    }
}
