using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class interactionbroadcaster : MonoBehaviour
{

    public Action interacttrying;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
     public void InputPressed(InputAction.CallbackContext  context)
    {
        interacttrying?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
