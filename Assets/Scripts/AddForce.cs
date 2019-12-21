using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PhysicsEngine))]
public class AddForce : MonoBehaviour
{
    public Vector3 forceVector;
    private PhysicsEngine physicsEngine;
    // Start is called before the first frame update
    void Start()
    {
      physicsEngine = GetComponent<PhysicsEngine>();
    }
    void FixedUpdate()
    {
      physicsEngine.AddForce(forceVector);
    }
}
