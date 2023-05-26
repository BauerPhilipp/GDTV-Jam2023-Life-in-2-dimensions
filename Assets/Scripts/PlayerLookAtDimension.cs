using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLookAtDimension : MonoBehaviour
{
    [SerializeField] GameObject headLook;
    [SerializeField] int DimensionMouseThresholdPercentage;

    private int DimensionMouseThreshold;

    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        DimensionMouseThreshold = Camera.main.pixelWidth / 100 * DimensionMouseThresholdPercentage;
    }

    private void Update()
    {
        LookDirectionWithMousePosition(transform.position);
    }

    private void LookDirectionWithMousePosition(Vector3 playerPosition)
    {

        playerPosition = Camera.main.WorldToScreenPoint(playerPosition);
        float lookScale = 1;
        if (playerController.GetMoveDirection() != 0) { lookScale *= -1; }

        if (Input.mousePosition.x + DimensionMouseThreshold < playerPosition.x)
        {
            headLook.transform.localScale = new Vector3(1, 1, -lookScale);
            Camera.main.backgroundColor = new Color(.1f,.1f,.1f);
            DimensionManager.Instance.ActivateDimension(0);
        }
        else if (Input.mousePosition.x - DimensionMouseThreshold > playerPosition.x)
        {
            headLook.transform.localScale = new Vector3(1, 1, lookScale);
            Camera.main.backgroundColor = Color.blue;
            DimensionManager.Instance.ActivateDimension(1);
        }
    }

}
