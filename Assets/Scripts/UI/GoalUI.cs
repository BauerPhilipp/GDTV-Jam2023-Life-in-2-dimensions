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
    Button nextLevelButton;

    private int nextLevel;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        
        resetButton = root.Q<Button>("RestartButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");
        nextLevelButton = root.Q<Button>("NextLevelButton");

        resetButton.RegisterCallback<ClickEvent>(RestartButtonClicked);
        mainMenuButton.RegisterCallback<ClickEvent>(MainMenuButtonClicked);
        nextLevelButton.RegisterCallback<ClickEvent>(NextLevelButtonClicked);
        root.visible = false;

    }
    private void Start()
    {
        goalUI = GetComponent<GameObject>();
    }

    public void ActivateGoalUI(int nextLevel)
    {
        this.nextLevel = nextLevel;
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

    void NextLevelButtonClicked(ClickEvent e)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);
    }

}
