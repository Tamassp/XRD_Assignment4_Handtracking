using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class TriggerProjectile : MonoBehaviour
{
    public ActiveStateSelector pose;
    public GameObject projectile;
    public float launchVelocity = 700f;
    // Start is called before the first frame update
    void Start()
    {
        pose.WhenSelected += () => {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
