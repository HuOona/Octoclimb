using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public bool spinning;

    Rigidbody2D RGB;
    public Vector2 blob = new Vector2(0,0); // pole platform
    private float spinRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        RGB = GetComponent<Rigidbody2D>();
    }

    void userInput()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Mobile
        if (Input.touchCount > 0)
        {
            print(Input.touches);
            if (!spinning)
            {
                //Start spin
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
                RGB.velocity = Vector2.MoveTowards(blob,-transform.position, 1);
                //transform.Translate(new Vector2(blob.x - transform.position.x, blob.y - transform.position.y)*Time.deltaTime * 10);
            }
            if (!spinning)
            {
                //max distance = 2
                //add velocity

                

                spinning = true;
            }
        }
        else
        {
            spinning = false;
        }
    }
}
