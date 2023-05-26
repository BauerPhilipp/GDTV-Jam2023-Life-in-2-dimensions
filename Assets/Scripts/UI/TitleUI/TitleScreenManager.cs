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

    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("Start");
        settingsButton = root.Q<Button>("Settings");
        creditsButton = root.Q<Button>("Credits");

        startButton.RegisterCallback<ClickEvent>(StartButtonClicked);
        settingsButton.RegisterCallback<ClickEvent>(SettingsButtonClicked);
        creditsButton.RegisterCallback<ClickEvent>(CreditsButtonClicked);

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

}
