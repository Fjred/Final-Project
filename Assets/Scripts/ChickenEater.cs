
using UnityEngine;
using TMPro;
public class ChickenEater : MonoBehaviour
{
    public float raycastRange = 3f;
    public float chickenCounter = 2f;

    public TMP_Text chicken;

    public Exit chickenEated;
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
                chickenEated.chickenEatenNumber += 1;
            }

        }
    }
}
