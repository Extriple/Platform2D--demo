using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    //Lista typów kluczy
    //List with KeysType
    private List<Key.KeysTypes> keyslist;

    private void Awake()
    {
        keyslist = new List<Key.KeysTypes>();
    }
    //Dodawanie kluczy
    //Add keys
    public void Add(Key.KeysTypes keysTypes)
    {
        Debug.Log("ADD" + keysTypes);
        keyslist.Add(keysTypes);
    }

    //Usuwanie 
    //Remove
    public void Remove(Key.KeysTypes keysTypes)
    {
        keyslist.Remove(keysTypes);
    }
    //Sprawdzamy czy lista kluczy zawiera określony klucz
    //We chack that the list have true value with keys
    public bool Contains(Key.KeysTypes keysTypes)
    {
        return keyslist.Contains(keysTypes);
    }
    //Give the trigger 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Key key = collision.GetComponent<Key>();
        if(key != null)
        {
            Add(key.GetTypes());
            Destroy(key.gameObject);
        }

        DoorWithKey doorWithKey = collision.GetComponent<DoorWithKey>();
        if(doorWithKey != null)
        {
           if(Contains(doorWithKey.GetTypes()))
            {
                //Trzymamy klucz do otwarcia drzwi 
                //Holding key to open the door 
                Remove(doorWithKey.GetTypes());
                doorWithKey.OpenDoor();
            }

        }
    }

}
