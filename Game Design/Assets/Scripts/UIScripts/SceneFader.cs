using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public float FadeSpeed = 1f;
    public AnimationCurve curve;
    public AudioClip fadeSfx;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime * FadeSpeed;    // ZeitDifferenz zwischen letzen Frame und derzeitigen Frame
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0; // Wartet ein Frame
        }
    }

    public void FadeTo(string scene)
    {
        AudioSource.PlayClipAtPoint(fadeSfx, Camera.main.transform.position);
        StartCoroutine(FadeOut(scene));
    }


    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime * FadeSpeed;    // ZeitDifferenz zwischen letzen Frame und derzeitigen Frame
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0; // Wartet ein Frame
        }

        SceneManager.LoadScene(scene);
    }

    public void FadeTo(int buildIndex)
    {
        AudioSource.PlayClipAtPoint(fadeSfx, Camera.main.transform.position);
        StartCoroutine(FadeOut(buildIndex));
    }

    IEnumerator FadeOut(int buildIndex)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime * FadeSpeed;    // ZeitDifferenz zwischen letzen Frame und derzeitigen Frame
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0; // Wartet ein Frame
        }

        SceneManager.LoadScene(buildIndex);
    }

}
