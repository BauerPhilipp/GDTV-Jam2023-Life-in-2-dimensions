using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GoalUI : MonoBehaviour
{

    GameObject goalUI;

    VisualElement root;
    Button resetButton;
    Button mainMenuButton;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        
        resetButton = root.Q<Button>("RestartButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");

        resetButton.RegisterCallback<ClickEvent>(RestartButtonClicked);
        mainMenuButton.RegisterCallback<ClickEvent>(MainMenuButtonClicked);
        root.visible = false;

    }
    private void Start()
    {
        goalUI = GetComponent<GameObject>();
    }

    public void ActivateGoalUI()
    {
        Time.timeScale = 0f;
        root.visible = true;
    }

    void RestartButtonClicked(ClickEvent e)
    {
        Time.timeScale = 1f;
        Debug.Log("ResetClicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void MainMenuButtonClicked(ClickEvent e)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
