using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip transitionSound;

    public float delayBeforeSound = 0.5f;
    public float delayBeforeScene = 1.5f;

    public void LoadSceneWithDelay(string sceneName)
    {
        StartCoroutine(LoadRoutine(sceneName));
    }

    IEnumerator LoadRoutine(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeSound);

        audioSource.PlayOneShot(transitionSound);

        yield return new WaitForSeconds(delayBeforeScene);

        SceneManager.LoadScene(sceneName);
    }
}