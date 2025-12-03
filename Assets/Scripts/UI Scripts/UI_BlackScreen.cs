using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UI_BlackScreen : MonoBehaviour
{
    public Image black_screen;
    public float fadeDuration = 0.2f;
    public float black_screen_duration = 0.5f;

    public IEnumerator BlackScreenBegin()
    {
        black_screen.gameObject.SetActive(true);

        Color color = black_screen.color;

        // start fully transparent
        color.a = 0f;
        black_screen.color = color;

        float transparency = 0f;

        // Fade IN
        while (transparency < fadeDuration)
        {
            transparency += Time.deltaTime;
            float normalized = Mathf.Clamp01(transparency / fadeDuration);
            color.a = normalized;
            black_screen.color = color;
            yield return null;
        }
    }

    public IEnumerator BlackScreenEnd()
    {
        Color color = black_screen.color;

        // make sure it is fully black
        color.a = 1f;
        black_screen.color = color;

        // Hold full black
        yield return new WaitForSeconds(black_screen_duration);

        float transparency = 0f;

        // Fade OUT (1 -> 0)
        while (transparency < fadeDuration)
        {
            transparency += Time.deltaTime;
            float normalized = Mathf.Clamp01(transparency / fadeDuration);
            color.a = 1f - normalized;
            black_screen.color = color;
            yield return null;
        }

        // Ensure fully transparent and optionally disable
        color.a = 0f;
        black_screen.color = color;
        black_screen.gameObject.SetActive(false);
    }

}
