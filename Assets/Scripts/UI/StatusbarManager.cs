using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatusbarManager : MonoBehaviour
{

    private static StatusbarManager instance;
    public static StatusbarManager Instance { get { return instance; } private set { } }

    VisualElement root;
    Label timerLabel;

    private void Awake()
    {
        if (instance != null) { Destroy(this); return; }

        instance = this;

    }

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        timerLabel = root.Q<Label>("TimerLabel");
        timerLabel.text = "Hallo Dimeju";
    }

    public void SetTimerLabel(string s)
    {
        timerLabel.text = s;
    }
}
