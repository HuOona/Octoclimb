using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool spinning;

    [SerializeField]private float spinSpeed;
    [SerializeField] private float swingSpeed;

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
            //transform.Translate(Vector2.MoveTowards(transform.position, new Vector2(blob.x + spinRadius, blob.y + spinRadius), spinRadius));
            transform.RotateAround(blob, Vector3.forward, spinSpeed * Time.deltaTime);
            Move.x = swingSpeed * Time.deltaTime;
            Move.y = swingSpeed * 0.4f * Time.deltaTime;
        }
        else
        {
            print(Vector2.Distance(Move, Vector2.zero));
            if (Vector2.Distance(Move, Vector2.zero) > 0.01f) 
            { 
                Move.x -= 0.1f;
                Move.y -= 0.1f; 
            }
            else Move = Vector2.zero;
            
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
