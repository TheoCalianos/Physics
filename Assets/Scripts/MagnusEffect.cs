﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusEffect : MonoBehaviour
{
    public float magnusConstant = 1f;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody> ();
    }
    void Update()
    {
      rigidBody.AddForce (magnusConstant * Vector3.Cross (rigidBody.angularVelocity, rigidBody.velocity) * Time.deltaTime);
    }
}
