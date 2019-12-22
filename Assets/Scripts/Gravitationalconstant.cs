using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitationalconstant : MonoBehaviour
{
  private const float GravitationalConstant = 6.674e-11f; //m^3 kg^-1 s^-2 = N*(mkg)2
  private PhysicsEngine[] physicsEngineArray;
  private PhysicsEngine physicsEngine;
  // Start is called before the first frame update
  void Start()
  {
    physicsEngine = GetComponent<PhysicsEngine>();
    physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
  }
  void FixedUpdate()
  {
    CalculateGravity();
  }

  void CalculateGravity()
  {
    foreach (PhysicsEngine PhysicsEngineA in physicsEngineArray)
    {
        foreach (PhysicsEngine PhysicsEngineB in physicsEngineArray)
        {
            if(PhysicsEngineA != PhysicsEngineB && PhysicsEngineA != this)
            {
              Vector3 offset = PhysicsEngineA.transform.position - PhysicsEngineB.transform.position;
              float rSquared = Mathf.Pow(offset.magnitude, 2f);
              float gravityMagnitude =  GravitationalConstant * PhysicsEngineA.mass * PhysicsEngineB.mass/ rSquared;
              Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

              PhysicsEngineA.AddForce (-gravityFeltVector);
            }
        }
    }
  }
}
