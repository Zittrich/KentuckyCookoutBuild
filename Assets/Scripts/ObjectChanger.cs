using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChanger : MonoBehaviour
{
    public float cookingRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public Pickup CookObject()
    //{
    //    foreach (Collider item in Physics.OverlapBox(transform.position + transform.forward * cookingRange))
    //    {
    //        if (item.gameObject.TryGetComponent<Pickup>(out Pickup pickup))
    //        {

    //            return pickup;
    //        }
    //    }
    //    return null;
    //}

    // Objekt wird in Ort geworfen
    // Objekt wird ge despawned
    // Neues Objekt wird gespawned
}
