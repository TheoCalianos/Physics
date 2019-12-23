using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float maxLaunchSpeed;
    public AudioClip windUpSound, LuanchSound;
    public float luanchSpeed;
    private AudioSource audioSource;

    private float addedSpeedperFrame;
    public PhysicsEngine ballToLuanch;
    // Start is called before the first frame update
    void Start()
    {
          audioSource =  GetComponent<AudioSource>();
          audioSource.clip = windUpSound;
          addedSpeedperFrame = (maxLaunchSpeed * Time.deltaTime)/audioSource.clip.length;
    }

    void OnMouseDown()
    {
      luanchSpeed = 0f;
      InvokeRepeating("IncreaseLaunchSpeed", .5f,Time.deltaTime);
      audioSource.clip = windUpSound;
      audioSource.Play();
    }
    void OnMouseUp()
    {
      CancelInvoke();
      audioSource.Stop();
      audioSource.clip = LuanchSound;
      audioSource.Play();
      PhysicsEngine newBall = Instantiate(ballToLuanch) as PhysicsEngine;
      newBall.transform.parent = GameObject.Find("Launched Balls").transform;
      Vector3 launchVelocity = new Vector3 (1,1,0).normalized * luanchSpeed;
      Debug.Log(launchVelocity);
      newBall.velocityVector = launchVelocity;
    }
    void IncreaseLaunchSpeed()
    {
      if(luanchSpeed <= maxLaunchSpeed)
      {
        luanchSpeed += addedSpeedperFrame;
      }
    }
}
