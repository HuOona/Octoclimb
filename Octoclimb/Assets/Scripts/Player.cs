using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //when spinning
    private bool spinning;
    [SerializeField] Rigidbody2D RGB;
    [SerializeField] float maxSpeed;


    private void Update()
    {
        if (Input.anyKey)
        {
            if (!spinning)
            {
                spinning = true;
                //start ´the spin´
            }
        }
        else
        {
            spinning = false;
        }

        if (spinning)
        {
            if (RGB.velocity.magnitude > maxSpeed)
            {
                RGB.velocity = Vector2.ClampMagnitude(RGB.velocity, maxSpeed);
            }
            else
            {
                RGB.AddRelativeForce(Vector2.left);
            }
        }
    }
}
