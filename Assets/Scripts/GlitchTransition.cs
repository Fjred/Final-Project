using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlitchTransition : MonoBehaviour
{
    public Image[] images;
    public float transitionDuration = 5f;
    public Shader glitchShader;

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(TransitionImages());
    }

    private IEnumerator TransitionImages()
    {
        while (true)
        {
            // Display current image
            images[currentIndex].gameObject.SetActive(true);

            // Wait for image display duration
            yield return new WaitForSeconds(transitionDuration);

            // Apply glitch effect
            Material glitchMaterial = new Material(glitchShader);
            images[currentIndex].material = glitchMaterial;

            // Wait for glitch effect duration
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            // Remove glitch effect
            images[currentIndex].material = null;

            // Hide current image
            images[currentIndex].gameObject.SetActive(false);

            // Move to the next image
            currentIndex = (currentIndex + 1) % images.Length;
        }
    }
}
