using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{
    [SerializeField] GameObject[] dimensions;

    static DimensionManager dimensionManager;
    public static DimensionManager Instance { get { return dimensionManager; } private set { } }

    private PlayerController player;

    private PathBoni pathBoni;

    private void Awake()
    {
        if (dimensionManager != null) 
        {
            Destroy(this);
            Debug.LogError("Delete duplicated DimensionManager!");
            return;
        }
        dimensionManager = this;
    }

    public void ActivateDimension(int dimension)
    {
        foreach (GameObject obj in dimensions)
        {
            obj.transform.position = new Vector3(1000,0,0);
        }
        dimensions[dimension].transform.position = new Vector3(0,0,0);
    }

    public void ActivateBoni(PlayerController player, PathBoni pathBoni)
    {       
        if (PathBoni.isBoniActive) { return; }

        PathBoni.isBoniActive = true;
        this.pathBoni = pathBoni;
        this.player = player;

        //Debug.Log("SpeedBoni: " + this.pathBoni.SpeedBoni);
        //Debug.Log("JumpBoni: " + this.pathBoni.JumpBoni);


        if (pathBoni.SpeedBoni != 0) StartCoroutine(SpeedBuffDuration());
        if (pathBoni.JumpBoni != 0) StartCoroutine(JumpBuffDuration());
    }

    IEnumerator SpeedBuffDuration()
    {
        player.MoveSpeed += pathBoni.SpeedBoni;

        for (int i = 0; i < pathBoni.BoniDuration; i++)
        {
            StatusbarManager.Instance.SetTimerLabel("Speedboni " + (pathBoni.BoniDuration - i) + "seconds");
            yield return new WaitForSeconds(1f);
        }
        StatusbarManager.Instance.SetTimerLabel("NO BONI ACTIVE!");
        player.MoveSpeed -= pathBoni.SpeedBoni;
        PathBoni.isBoniActive = false;
    }

    //anpassen auf Jumping!
    IEnumerator JumpBuffDuration()
    {
        player.MaxDoubleJumps += pathBoni.JumpBoni;
        for (int i = 0; i < pathBoni.BoniDuration; i++)
        {
            StatusbarManager.Instance.SetTimerLabel("Jumpboni " + (pathBoni.BoniDuration - i) + "seconds");
            yield return new WaitForSeconds(1f);
        }
        StatusbarManager.Instance.SetTimerLabel("NO BONI ACTIVE!");
        player.MaxDoubleJumps -= pathBoni.JumpBoni;
        PathBoni.isBoniActive = false;
    }
}
