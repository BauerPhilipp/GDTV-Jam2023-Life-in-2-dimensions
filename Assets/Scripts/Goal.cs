using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] int nextLevel;

    private GoalUI goalUI;

    private void Awake()
    {
        goalUI = FindObjectOfType<GoalUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        goalUI.ActivateGoalUI(nextLevel);
    }


}
