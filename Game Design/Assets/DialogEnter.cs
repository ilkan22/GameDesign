using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEnter : MonoBehaviour
{
    public Dialog dialog;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Enemy")
        {
            Debug.Log("TriggerENter");
        }
        
    }
    
}
