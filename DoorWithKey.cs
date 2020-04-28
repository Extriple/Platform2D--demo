using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    [SerializeField] private Key.KeysTypes keystypes;
    
    public Key.KeysTypes GetTypes()
    {
        return keystypes;
    }
    //Open door
    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
