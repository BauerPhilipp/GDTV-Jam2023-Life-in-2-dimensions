using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLookAtDimension : MonoBehaviour
{
    [SerializeField] GameObject headLook;

    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
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

        if (Input.mousePosition.x < playerPosition.x)
        {
            headLook.transform.localScale = new Vector3(1, 1, -lookScale);
        }
        else if (Input.mousePosition.x > playerPosition.x)
        {
            //head.transform.eulerAngles = new Vector3(0, -90, 0);
            headLook.transform.localScale = new Vector3(1, 1, lookScale);
        }
        else
        {
            Debug.LogWarning("Fehler in PlayerLookAtDimension.cs!");
        }
    }

}
