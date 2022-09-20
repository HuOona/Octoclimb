using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //when spinning
    private bool spinning;
    private bool spinnable;
    [SerializeField] Rigidbody2D RGB;
    private HingeJoint2D HJ;
    [SerializeField] float maxSpeed;
    [SerializeField] Vector2 spinRadius;

    private Vector2 Pole;
    private Vector2 Dir;

    private void Start()
    {
        RGB = GetComponent<Rigidbody2D>();
        HJ = GetComponent<HingeJoint2D>();
    }

    private void SpinMe()
    {
        if (spinning)
        {
            if (RGB.velocity.magnitude > maxSpeed)
            {
                RGB.velocity = Vector2.ClampMagnitude(RGB.velocity, maxSpeed);
            }
            else
            {
                RGB.AddRelativeForce(Dir);
            }
        }
    }

    void startSpin()
    {
        transform.position = Pole + spinRadius ;
        transform.rotation = Quaternion.identity;
        HJ.anchor = (new Vector3(Pole.x, Pole.y, 0) - transform.position) / transform.localScale.x;
        spinning = true;
        HJ.enabled = true;
        spinnable = false;
        RGB.simulated = true;

    }

    private void Update()
    {
        //mobile
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (!spinning && spinnable)
            {
                //start ´the spin´
                startSpin();
            }

            //Which side clicked
            if (touch.position.x < Screen.width / 2)
            {
                Dir = Vector2.left;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                Dir = Vector2.right;
            }
        }
        //pc
        else if (Input.GetMouseButton(0))
        {
            if (!spinning && spinnable)
            {
                //start ´the spin´
                startSpin();
            }

            //Which side clicked
            if (Input.mousePosition.x < Screen.width/2)
            {
                Dir = Vector2.left;
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                Dir = Vector2.right;
            }
        }
        else
        {
            spinning = false;
            HJ.enabled = false;
        }

        //Spin
        SpinMe();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pole"))
        {
            spinnable = true;
            RGB.simulated = false;
            Pole = collision.transform.position;
            HJ.connectedBody = collision.transform.GetChild(0).GetComponent<Rigidbody2D>();
        }
    }
}
