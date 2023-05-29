using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveForNextScene : MonoBehaviour
{ 
    private static GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this.gameObject;
        DontDestroyOnLoad(this);
    }
}
