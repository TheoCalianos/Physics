﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public Vector3 velocityVector;    //m per sec
    public Vector3 accelerationVector; //f/m
    public Vector3 netForceVector;  //N (kg m/s^2)
    public bool showTrails = true;
    public float mass;    //kg

    private List<Vector3> forceVectorList = new List<Vector3>();
    private int numberOfForces;
  	private LineRenderer lineRenderer;

    void Start()
    {
      GenerateLine();
    }
    void FixedUpdate()
    {
      ThrustTrials();
      UpdatePosition();
    }
    public void UpdatePosition()
    {
      netForceVector = Vector3.zero;
      foreach (Vector3 forceVector in forceVectorList)
      {
        netForceVector = netForceVector + forceVector;
      }
      forceVectorList = new List<Vector3>();

      accelerationVector = netForceVector/mass;
      velocityVector +=  accelerationVector *Time.deltaTime;
      transform.position += velocityVector * Time.deltaTime;
    }

    public void AddForce(Vector3 forceVector)
    {
       forceVectorList.Add(forceVector);
    }
    private void ThrustTrials()
    {
      if (showTrails) {
        lineRenderer.enabled = true;
        numberOfForces = forceVectorList.Count;
        lineRenderer.SetVertexCount(numberOfForces * 2 + 4);
        int i = 0;
        foreach (Vector3 forceVector in forceVectorList) {
          lineRenderer.SetPosition(i, Vector3.zero);
          lineRenderer.SetPosition(i+1, -forceVector);
          i = i + 2;
        }
        if(accelerationVector != Vector3.zero)
        {
          lineRenderer.SetPosition(i+1, Vector3.zero);
          lineRenderer.SetPosition(i+2, accelerationVector);
        }
      } else {
        lineRenderer.enabled = false;
      }
    }
    private void GenerateLine()
    {
      lineRenderer = gameObject.AddComponent<LineRenderer>();
      lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
      lineRenderer.SetColors(Color.yellow, Color.yellow);
      lineRenderer.SetWidth(0.2F, 0.2F);
      lineRenderer.useWorldSpace = false;
    }

}
