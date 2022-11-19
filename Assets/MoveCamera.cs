using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey("left"))
            movement.x -= speed;
        if (Input.GetKey("right"))
            movement.x += speed;
        if (Input.GetKey("up"))
            movement.y += speed;
        if (Input.GetKey("down"))
            movement.y -= speed; 
        if (Input.GetKey("z"))
            movement.z += speed;
        if (Input.GetKey("x"))
            movement.z -= speed;

        transform.Translate(movement * Time.deltaTime);

    }
}
