using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadListScript : MonoBehaviour
{
    public Canvas listPopup;
    private bool readFull;
    public float PickupDistance;
    public float PickupRadius;
    public CookController cookController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IngredientList readingList = FindIngredientList();
            if (readingList != null)
            {
                cookController.enabled = false;
                readFull = true;
                ReadList();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && readFull == true)
        {
            cookController.enabled = true;
            readFull = false;
            StopRead();
        }
    }

    void ReadList()
    {
        listPopup.enabled = true;
    }

    void StopRead()
    {
        listPopup.enabled = false;
    }
    public IngredientList FindIngredientList()
    {
        foreach (Collider item in Physics.OverlapSphere(transform.position + transform.forward + transform.up * PickupDistance, PickupRadius))
        {
            if (item.gameObject.TryGetComponent<IngredientList>(out IngredientList list))
            {
                return list;
            }
        }
        return null;
    }
}
