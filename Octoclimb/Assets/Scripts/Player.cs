using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool spinning;

    [SerializeField]private float spinSpeed;

    Vector2 Velocity = new Vector2(0,0);
    Vector2 Move = new Vector2(0,0);
    public float gravity;
    public Vector2 blob = new Vector2(0,0); // pole platform
    private float spinRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void userInput()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spinning)
        {
            transform.RotateAround(blob, Vector3.forward, spinSpeed * Time.deltaTime);
            Move.x = 1 * Time.deltaTime;
        }
        else
        {

            //move - 1 until 0
            if (Move.y <= 0) Move.y += 1 * Time.deltaTime * Time.deltaTime;
            if (Move.x <= 0) Move.y += 1 * Time.deltaTime * Time.deltaTime;
            if (Move.y >= 0) Move.y -= 1 * Time.deltaTime * Time.deltaTime;
            if (Move.x >= 0) Move.y -= 1 * Time.deltaTime * Time.deltaTime;

            //Gravitational acceleration
            Velocity -= new Vector2(0, 1) * gravity * Time.deltaTime * Time.deltaTime;

        }

        //Mobile
        if (Input.touchCount > 0)
        {
            print(Input.touches);
            if (!spinning)
            {
                //Start spin
                Velocity = new Vector2(0, 0);
            }
        }
        else
        {
            //Stop spinning
        }

        //Desk
        if (Input.anyKey)
        {
            if (Vector2.Distance(transform.position, blob) > spinRadius)
            {

            }
            if (!spinning)
            {
                //max distance = 2
                //add velocity


                Velocity = new Vector2(0, 0);
                spinning = true;
            }
        }
        else
        {
            spinning = false;
        }
        transform.Translate(Velocity, Space.World);
        
        if(!spinning)transform.Translate(Move);
    }
}
