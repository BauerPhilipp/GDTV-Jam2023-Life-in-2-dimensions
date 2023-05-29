using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] UIDocument titleScreenUI;

    VisualElement root;
    Slider volumeSlider;
    Button backButton;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        volumeSlider = root.Q<Slider>("VolumeSlider");
        backButton = root.Q<Button>("BackButton");

        volumeSlider.RegisterCallback<ChangeEvent<float>>(VolumeChange);
        volumeSlider.SetValueWithoutNotify(audioSource.volume);

        backButton.RegisterCallback<ClickEvent>(OnBackbuttonClicked);

    }

    private void VolumeChange(ChangeEvent<float> e)
    {
        audioSource.volume = e.newValue;
    }

    private void OnBackbuttonClicked(ClickEvent e)
    {
        root.visible = false;
        titleScreenUI.rootVisualElement.visible = true;
    }

}
