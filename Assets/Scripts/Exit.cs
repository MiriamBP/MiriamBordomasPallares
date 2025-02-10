using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameManager GameManagerScript;
   
    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("JohnLemon"))
        {
            GameManagerScript.IsPlayerAtExit = true;
        }
    }
}
