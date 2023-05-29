using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Credits : MonoBehaviour
{
    [SerializeField] UIDocument titleScreenUI;

    VisualElement root;
    Button backButton;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        backButton = root.Q<Button>("BackButton");

        backButton.RegisterCallback<ClickEvent>(OnBackbuttonClicked);
        root.visible = false;
    }

    private void OnBackbuttonClicked(ClickEvent e)
    {
        root.visible = false;
        titleScreenUI.rootVisualElement.visible = true;
    }

}
