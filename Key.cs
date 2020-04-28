using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //
    //Types key 
    [SerializeField] private KeysTypes keysTypes;
   public enum KeysTypes
    {
        Diamond,
        Signature
    }
    //Get Type for key
    public KeysTypes GetTypes()
    {
        return keysTypes;
    }
}
