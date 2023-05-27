using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] TextMeshPro tutorialText;
    [SerializeField] float typeSpeed;
    [SerializeField] float delayBetweenText;



    private bool wirteText = false;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WriteText());  
    }

    private IEnumerator WriteText()
    {
        yield return new WaitForSeconds(2);
        foreach(string s in TutorialTextManager.textList)
        {
            tutorialText.text = "";
            foreach (char c in s)
            {
                tutorialText.text += c;
                yield return new WaitForSeconds(typeSpeed);
            }
            yield return new WaitForSeconds(delayBetweenText);
        }
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }

}
