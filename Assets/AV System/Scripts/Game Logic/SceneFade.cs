using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour {
    [SerializeField] Image FadeImg;

    float fadeSpeed = 0.05f;

    public void FadeToBlack()
    {
        StartCoroutine(Fader());
    }

    IEnumerator Fader()
    {
        do
        {
            FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
            if (FadeImg.color.a >= 0.99f)
            {
                yield break;
            }
        } while (true);
    }
}
