using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlObject : MonoBehaviour
{
    private bool isHolding = false;
    private GameObject objectToHoldDrop;
    private GameObject chestToDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isHolding)
            {
                Drop();
            }
            else
            {
                PickUp();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!objectToHoldDrop)
                objectToHoldDrop = other.gameObject;
        }

        if (other.tag == "Chest")
            chestToDrop = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isHolding)
            {
                objectToHoldDrop = null;
            }
        }
    }

    private void PickUp()
    {
        if (!objectToHoldDrop)
            return;

        this.transform.SetParent(objectToHoldDrop.transform);
        this.transform.position = objectToHoldDrop.transform.GetChild(0).position;
        isHolding = true;
    }

    private void Drop()
    {
        if (chestToDrop)
            Destroy(this.gameObject);

        this.transform.SetParent(null);
        isHolding = false;
    }
}
