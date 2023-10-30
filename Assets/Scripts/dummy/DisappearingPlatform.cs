using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private bool steppedOn = false;
    public float fadeDuration = 0.5f;
    private float currentFadeTime = 0f;
    private Color initialColor;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        initialColor = renderer.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !steppedOn)
        {
            steppedOn = true;
            InvokeRepeating("FadeOut", 0f, 0.05f);
        }
    }

    private void FadeOut()
    {
        currentFadeTime += 0.05f;
        float alphaValue = 1.0f - (currentFadeTime / fadeDuration);
        Color currentColor = initialColor;
        currentColor.a = Mathf.Max(0, alphaValue);
        renderer.material.color = currentColor;

        if (currentFadeTime >= fadeDuration)
        {
            CancelInvoke("FadeOut");
            gameObject.SetActive(false);
        }
    }
}



