using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Detector : MonoBehaviour
{
    //Zona de varibles globales
    public GameManager GameManagerScript;

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("JohnLemon"))
        {
            GameManagerScript.IsPlayerCaught = true;
        }
    }
}
