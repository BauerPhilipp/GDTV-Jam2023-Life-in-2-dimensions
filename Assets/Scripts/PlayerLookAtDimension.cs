using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLookAtDimension : MonoBehaviour
{
    [SerializeField] GameObject head;

    private void Update()
    {
        LookDirectionWithMousePosition(transform.position);
    }

    private void LookDirectionWithMousePosition(Vector3 playerPosition)
    {

        playerPosition = Camera.main.WorldToScreenPoint(playerPosition);

        if (Input.mousePosition.x < playerPosition.x)
        {
            head.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.mousePosition.x > playerPosition.x)
        {
            head.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            Debug.LogWarning("Fehler in PlayerLookAtDimension.cs!");
        }
    }

}
