using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLookAtDimension : MonoBehaviour
{

    private void Update()
    {
        LookDirectionWithMousePosition(transform.position);
    }

    private void LookDirectionWithMousePosition(Vector3 playerPosition)
    {

        playerPosition = Camera.main.WorldToScreenPoint(playerPosition);

        if (Input.mousePosition.x < playerPosition.x)
        {
            Debug.Log("Links");
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (Input.mousePosition.x > playerPosition.x)
        {
            Debug.Log("Rechts");
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else
        {
            Debug.Log("Fehler");
        }
    }

}
