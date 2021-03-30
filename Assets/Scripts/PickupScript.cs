using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    private Rigidbody rbPickup;
    private Collider colPickup;
    private GameObject itemInHand;
    public Transform hand;
    public ReadListScript readListScript;

    public float PickupDistance;
    public float PickupRadius;
    public bool handFull;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pickup pickupedItem = FindPickup();

            if (pickupedItem != null)
            {
                readListScript.enabled = false;
                handFull = true;
                rbPickup = pickupedItem.gameObject.GetComponent<Rigidbody>();
                itemInHand = pickupedItem.gameObject;
                colPickup = pickupedItem.gameObject.GetComponent<Collider>();
                Pickup();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && handFull == true)
        {
            readListScript.enabled = true;
            handFull = false;
            Drop();
        }
    }
    void Pickup()
    {

        rbPickup.useGravity = false;
        colPickup.enabled = false;
        itemInHand.transform.position = hand.position;
        itemInHand.transform.parent = hand;
        rbPickup.velocity = Vector3.zero;

    }

    void Drop()
    {
        itemInHand.transform.parent = null;
        colPickup.enabled = true;
        rbPickup.useGravity = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward + transform.up * PickupDistance, PickupRadius);
    }

    public Pickup FindPickup()
    {
        foreach (Collider item in Physics.OverlapSphere(transform.position + transform.forward + transform.up * PickupDistance, PickupRadius))
        {
            if (item.gameObject.TryGetComponent<Pickup>(out Pickup pickup))
            {

                return pickup;
            }
        }
        return null;
    }
}
