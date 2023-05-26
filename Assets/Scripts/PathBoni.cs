using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PathBoni : MonoBehaviour
{

    [Header("Boni. Only select one! 0 means no effect.")]
    [SerializeField] int speedBoni; public int SpeedBoni { get { return speedBoni;} private set { }}
    [SerializeField] int jumpBoni; public int JumpBoni { get { return jumpBoni; } private set { } }
    [SerializeField] Material speedMaterial;
    [SerializeField] Material jumpingMaterial;
    [SerializeField] PhysicMaterial physicsMaterialJumping;


    [Header("Duration in Seconds")]
    [Range(1f, 5f)]
    [SerializeField] float boniDuration; public float BoniDuration { get { return boniDuration; } private set { } }


    [SerializeField] TextMeshPro text;
    
    public static bool isBoniActive = false;


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






}
