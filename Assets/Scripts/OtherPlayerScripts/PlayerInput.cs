using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public event Action TryVending;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            UIManager.instance.ToggleInventory();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            TryVending?.Invoke();
        }
    }
}
