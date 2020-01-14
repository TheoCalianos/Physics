using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitailVelocity : MonoBehaviour
{
    public Vector3 intialVelocity;
    public Vector3 intialw;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody> ();
        rigidBody.velocity = intialVelocity;
        rigidBody.angularVelocity = intialw;
    }
}
