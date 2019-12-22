using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour
{
    public float fuelMass;  //kg
    public float maxThrust; //kN (kg m/s^2)

    [Range (0,1f)]
    public float thrustPercent; //%
    public Vector3 thrustUnitVector; //none
    private float currentThrust; //N

    private PhysicsEngine physicsEngine;
    // Start is called before the first frame update
    void Start()
    {
      physicsEngine = GetComponent<PhysicsEngine>();
      physicsEngine.mass += fuelMass;
    }
    void FixedUpdate()
    {
      if(fuelMass > FuelThisUpdate())
      {
        fuelMass -= FuelThisUpdate();
        physicsEngine.mass -= FuelThisUpdate();
        ExtertForce ();
      }
      else
      {
        Debug.Log("out of fuel");
      }
    }
    float FuelThisUpdate()
    {
      float exhaustMassFlow; //kg
      float effectiveExhaustVelocity; //m/s
      effectiveExhaustVelocity = 4462f;
      exhaustMassFlow = currentThrust/effectiveExhaustVelocity;
      return exhaustMassFlow * Time.deltaTime; //kg
    }
    void ExtertForce ()
    {
      currentThrust = thrustPercent * maxThrust *1000f;
      Vector3 thrustVector = thrustUnitVector.normalized * currentThrust; //n
      physicsEngine.AddForce(thrustVector);
    }
}
