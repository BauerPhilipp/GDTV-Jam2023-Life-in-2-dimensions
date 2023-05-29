using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedScene : MonoBehaviour
{
    [SerializeField] AudioClip audio2;
    private void Start()
    {

        AudioSource audio = FindObjectOfType<AudioSource>();
        audio.clip = audio2;
        audio.Play();

        StartCoroutine(BackToMain());
    }

    IEnumerator BackToMain()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }

}
