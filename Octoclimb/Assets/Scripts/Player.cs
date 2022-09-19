using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //when spinning
    private bool spinning;
    [SerializeField] Rigidbody2D RGB;
    private HingeJoint2D HJ;
    [SerializeField] float maxSpeed;

    private Vector2 Pole;

    private void Start()
    {
        RGB = GetComponent<Rigidbody2D>();
        HJ = GetComponent<HingeJoint2D>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (!spinning)
            {
                transform.position = Pole + Vector2.up;
                transform.rotation = Quaternion.identity;
                HJ.anchor = new Vector3(Pole.x, Pole.y, 0) - transform.position;
                spinning = true;
                HJ.enabled = true;
                //start ´the spin´
            }
        }
        else
        {
            spinning = false;
            HJ.enabled = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pole"))
        {
            Pole = collision.transform.position;
            HJ.connectedBody = collision.transform.GetChild(0).GetComponent<Rigidbody2D>();
        }
    }
}
