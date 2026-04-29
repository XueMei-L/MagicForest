using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public float fadeDuration = 2f;

    public void FadeIn()
    {
        StartCoroutine(Fade(-80f, 0f));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0f, -80f));
    }

    IEnumerator Fade(float start, float end)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float volume = Mathf.Lerp(start, end, time / fadeDuration);

            mixer.SetFloat("MusicVolume", volume);

            yield return null;
        }

        mixer.SetFloat("MusicVolume", end);
    }
}