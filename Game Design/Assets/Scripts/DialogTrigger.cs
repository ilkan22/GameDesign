using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public Sprite img;
    public bool destroy;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog, img);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Klappptt");
        TriggerDialog();
        if (destroy)
        {
            Destroy(this.gameObject);
        }
        

    }
}
