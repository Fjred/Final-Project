using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    public float interval = 5f; // Time interval for each background image
    public Image[] backgrounds; // Array of Image components representing the backgrounds
    private int currentBackgroundIndex = 0; // Index of the currently displayed background

    private float timer = 0f;

    void Start()
    {
        ShowBackground(currentBackgroundIndex); // Display the initial background
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            currentBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.Length;
            ShowBackground(currentBackgroundIndex);
        }
    }

    void ShowBackground(int index)
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (i == index)
                backgrounds[i].gameObject.SetActive(true);
            else
                backgrounds[i].gameObject.SetActive(false);
        }
    }
}
