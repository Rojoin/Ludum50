using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{


    public string mensaje;
    
    public void BaseInteract()
    {
        Interact();
    }

    // Update is called once per frame
        void Interact()
        {
            Debug.Log("Me mataste");
        }
}
