using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRocket : MonoBehaviour
{

    public Transform rocket;
    public Vector3 offset;
    public float upperThreshold;
    public float lowerThreshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((rocket.position.y - transform.position.y) > upperThreshold) { // Calculate the amount between the y coordinates of the rocket and the camera, if it is greater than the upperThreshold value do the following
            offset.y = upperThreshold * -1f; // Change the offset for the camera's y axis so that it is not following from directly on the rocket, but slightly below
            transform.position = rocket.position + offset; // Move the camera (the offset is added so the camera will still move with the rocket but slightly below)
        } else if ((transform.position.y - rocket.position.y) > lowerThreshold) { // Calculate the amount between the y coordinates of the camera and the rocket, if it is greater than the lowerThreshold value do the following
            offset.y = lowerThreshold; // Change the offset for the camera's y axis so that it is not following from directly on the rocket, but slightly above
            transform.position = rocket.position + offset; // Move the camera (the offset is added so the camera will still move with the rocket but slightly above)
        }
        
    }
}
