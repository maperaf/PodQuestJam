using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPlayer : MonoBehaviour
{
    private Rigidbody myRigidBody;
    private float positionX;
    private float positionY;
    private Vector3 position;
    public float mySpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        positionX = Input.GetAxis("Horizontal");
        positionY = Input.GetAxis("Vertical");
        position = new Vector3(positionX, 0, positionY);
        myRigidBody.MovePosition(myRigidBody.position + position * Time.deltaTime * mySpeed);

        if (position != Vector3.zero)
            myRigidBody.rotation = Quaternion.LookRotation(position, Vector3.zero);
    }

}
