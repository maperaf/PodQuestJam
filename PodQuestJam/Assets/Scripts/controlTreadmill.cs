using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTreadmill : MonoBehaviour
{
    public float mySpeed;
    private GameObject treadmillPiece;

    // Start is called before the first frame update
    void Start()
    {
        treadmillPiece = this.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTreadmill();
    }

    private void MoveTreadmill()
    {
        treadmillPiece.transform.Translate(Vector3.left * mySpeed * Time.deltaTime);
        //this.transform.Translate(Vector3.left * mySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestroyTreadmillPiece")
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entrou");
        //Collider myCollider = collision.contacts[0].thisCollider;
        //if (myCollider.tag == "TreadmillPiece")
        //    Destroy(myCollider);
    }
}
