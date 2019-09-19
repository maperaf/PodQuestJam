using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTreadmill : MonoBehaviour
{
    public float mySpeed;
    public GameObject piece;
    private Transform treadmillPiece;
    private float treadMillPieceSize;
    private float displacement;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        treadmillPiece = this.transform;
        treadMillPieceSize = this.GetComponent<MeshRenderer>().bounds.size.x;
        initialPosition = treadmillPiece.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTreadmill();
    }

    private void MoveTreadmill()
    {
        treadmillPiece.transform.Translate(Vector3.left * mySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestroyTreadmillPiece")
            Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CreateTreadMillPiece")
        {
            Instantiate(piece, initialPosition, Quaternion.identity);
        }
    }
}
