using UnityEngine;
using UnityEngine.UI;

public class GlitchEffect : MonoBehaviour
{
    public Texture2D glitchTexture; // The glitched background texture
    public float glitchIntensity = 0.2f; // Intensity of the glitch effect
    public float glitchSpeed = 1f; // Speed of the glitch effect

    private Material glitchMaterial; // Reference to the glitch material

    void Start()
    {
        glitchMaterial = GetComponent<Image>().material;
        glitchMaterial.SetTexture("_GlitchTex", glitchTexture);
        glitchMaterial.SetFloat("_GlitchIntensity", glitchIntensity);
        glitchMaterial.SetFloat("_GlitchSpeed", glitchSpeed);
    }
}
