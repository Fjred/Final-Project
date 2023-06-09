using UnityEngine;

public class PickAndDropController : MonoBehaviour
{
    public GameObject item;
    public Transform itemParent;
    public bool isPickedUp = false;
    public float raycastRange = 3f; 

    private static GameObject currentItem; 

    public float rotationX;
    public float rotationY;
    public float rotationZ;

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
        if (item.CompareTag("Gun") == true)
        {
            item.GetComponent<Gun>().enabled = false;
        }

        isPickedUp = false;

        currentItem.transform.parent = null;
        currentItem.transform.localScale = Vector3.one;
        currentItem.transform.eulerAngles = new Vector3(currentItem.transform.position.x, currentItem.transform.position.z, currentItem.transform.position.y);
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<MeshCollider>().enabled = true;

        currentItem = null; 
    }

    void Equip()
    {
        if (!isPickedUp && currentItem == null)
        {
            if(item.CompareTag("Gun") == true)
            {
                item.GetComponent<Gun>().enabled = true;
            }

            isPickedUp = true;
             
            item.GetComponent<Rigidbody>().isKinematic = true;

            item.transform.position = itemParent.transform.position;

            item.GetComponent<MeshCollider>().enabled = false;

            item.transform.parent = itemParent;
            item.transform.localEulerAngles = new Vector3(rotationX, rotationY, rotationZ);

            currentItem = item;
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
