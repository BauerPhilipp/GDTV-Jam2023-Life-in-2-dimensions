using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleScreenManager : MonoBehaviour
{

    private VisualElement root;
    private Button startButton;
    private Button settingsButton;
    private Button creditsButton;
    private Button tutorialButton;

    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("Start");
        settingsButton = root.Q<Button>("Settings");
        creditsButton = root.Q<Button>("Credits");
        tutorialButton = root.Q<Button>("TutorialButton");

        startButton.RegisterCallback<ClickEvent>(StartButtonClicked);
        settingsButton.RegisterCallback<ClickEvent>(SettingsButtonClicked);
        creditsButton.RegisterCallback<ClickEvent>(CreditsButtonClicked);
        tutorialButton.RegisterCallback<ClickEvent>(TutorialButtonClicked);

    }

    private void StartButtonClicked(ClickEvent e)
    {
        SceneManager.LoadScene(1);
    }
    private void SettingsButtonClicked(ClickEvent e)
    {
       
    }
    private void CreditsButtonClicked(ClickEvent e)
    {
        
    }

    private void TutorialButtonClicked(ClickEvent e)
    {
        SceneManager.LoadScene("Tutorial");
    }

}
