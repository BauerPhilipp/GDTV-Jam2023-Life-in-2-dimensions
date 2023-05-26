using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PathBoni : MonoBehaviour
{

    [Header("Boni. Only select one! 0 means no effect.")]
    [SerializeField] int speedBoni;
    [SerializeField] int jumpBoni;
    [SerializeField] Material speedMaterial;
    [SerializeField] Material jumpingMaterial;
    [SerializeField] PhysicMaterial physicsMaterialJumping;


    [Header("Duration in Seconds")]
    [Range(1f, 5f)]
    [SerializeField] float boniDuration;


    [SerializeField] TextMeshPro text;

    private PlayerController player;
    static bool isBoniActive = false;

    private void Start()
    {
        if (speedBoni != 0) 
        { 
            text.text = "Speed +" + speedBoni; 
            GetComponent<MeshRenderer>().material = speedMaterial;
        }

        if (jumpBoni != 0) 
        {
            text.text = "Jumps +" + jumpBoni;
            GetComponent<MeshRenderer>().material = jumpingMaterial;
        }
    }

    public void ActivateBoni(PlayerController player)
    {
        if (isBoniActive) { return; }
        this.player = player;
 
        if (speedBoni != 0) StartCoroutine(SpeedBuffDuration());
        if (jumpBoni != 0) StartCoroutine(JumpBuffDuration());
    }

    IEnumerator SpeedBuffDuration()
    {
        player.MoveSpeed += speedBoni;
        isBoniActive = true;
        for (int i = 0; i < boniDuration ; i++)
        {
            StatusbarManager.Instance.SetTimerLabel("Speedboni " + (boniDuration - i) + "seconds");
            yield return new WaitForSecondsRealtime(1f);           
        }
        StatusbarManager.Instance.SetTimerLabel("NO BONI ACTIVE!");
        player.MoveSpeed -= speedBoni;
        isBoniActive = false;      
    }

    //anpassen auf Jumping!
    IEnumerator JumpBuffDuration()
    {
        player.MaxDoubleJumps += jumpBoni;
        isBoniActive = true;
        for (int i = 0; i < boniDuration; i++)
        {
            StatusbarManager.Instance.SetTimerLabel("Jumpboni " + (boniDuration - i) + "seconds");
            yield return new WaitForSecondsRealtime(1f);
        }
        StatusbarManager.Instance.SetTimerLabel("NO BONI ACTIVE!");
        player.MaxDoubleJumps -= jumpBoni;
        isBoniActive = false;
    }




}
