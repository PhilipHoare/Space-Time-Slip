using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float thrustPower;
    public float immediateThrustPower;
    public float gravityPull;
    public GameObject thrusterFire;
    public Vector3 thrusterOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            if (rigidbody.velocity.y < 0.0f) {
                rigidbody.velocity += Vector2.up * immediateThrustPower;
            }
            rigidbody.AddForce(transform.up * thrustPower * Time.fixedDeltaTime, ForceMode2D.Force);
            
            thrusterFire.transform.localScale = thrusterOn;
        } else {
            if (rigidbody.velocity.y > 0.0f)
            {
                rigidbody.velocity += Vector2.down * gravityPull;
            }
            thrusterFire.transform.localScale = new Vector3(0,0,0);
        }
    }
}
