
using UnityEngine;

public class ChickenEater : MonoBehaviour
{
    public float raycastRange = 3f; // Maximum distance for raycast
    public float chickenCounter = 2f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EatChicken();
        }
    }

    void EatChicken()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, raycastRange))
        {
            if (hit.collider.CompareTag("Chicken"))
            {
                Destroy(hit.collider.gameObject);

                chickenCounter -= 1;
            }

        }
    }
}
