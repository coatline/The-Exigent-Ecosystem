using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    AudioSource a;

    private void Awake()
    {
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        a = GetComponent<AudioSource>();
    }


    IEnumerator PlayBeforeSceneLoaded(int index)
    {
        a.Play();
        yield return new WaitWhile(() => a.isPlaying);
        SceneManager.LoadScene(index);
    }

    public void ChangeScene(int index)
    {
        StartCoroutine(PlayBeforeSceneLoaded(index));
    }

    [SerializeField] TMP_Text giveStats;

    public void ToggleStats(TMP_Text popStats)
    {
        a.Play();

        if (popStats.gameObject.activeSelf == false && giveStats.gameObject.activeSelf == false)
        {
            popStats.gameObject.SetActive(true);
        }
        else if (popStats.gameObject.activeSelf == true && giveStats.gameObject.activeSelf == false)
        {
            giveStats.gameObject.SetActive(true);
        }
        else if (popStats.gameObject.activeSelf == true && giveStats.gameObject.activeSelf == true)
        {
            popStats.gameObject.SetActive(false);
        }
        else if (popStats.gameObject.activeSelf == false && giveStats.gameObject.activeSelf == true)
        {
            giveStats.gameObject.SetActive(false);
        }
    }

    public void ToggleGeneration(GameObject window)
    {
        a.Play();

        if (window.gameObject.activeSelf == false)
        {
            window.gameObject.SetActive(true);
        }
        else
        {
            window.gameObject.SetActive(false);
        }
    }

    public void ToggleMusic(AudioSource a)
    {
        if (a.enabled == false)
        {
            a.enabled = true;
        }
        else
        {
            a.enabled = false;
        }
    }
}
