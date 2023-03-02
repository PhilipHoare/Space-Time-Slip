using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{

    public float speed;
    public Vector3 moveVector;
    public float deadzone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + moveVector * Time.deltaTime;
        float currentPos = System.Math.Abs(transform.position.x);
        if (currentPos > deadzone)
        {
            Destroy(gameObject);
        }
    }

    public void setUp(string direction, int offset)
    {
        // If the direction is set to "left", then the asteroid will need to move left and start at the right
        if (direction == "left") 
        {
            // Change the position by adding the offset to the y position
            transform.position = new Vector3(transform.position.x, transform.position.y + offset);
            // Set the moveVector to a vector moving left, multiplied by the specified speed
            moveVector = Vector3.left * speed;
        }
        // If the direction is set to "right", then the asteroid will need to move right and start at the left
        else if (direction == "right")
        {
            // Invert the x position of this asteroid and add the offset to the y position
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y + offset);
            // Set the moveVector to a vector moving right, multiplied by the specified speed
            moveVector = Vector3.right * speed;
        }
    }

}
