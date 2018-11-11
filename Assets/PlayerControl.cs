using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;

    private float t = 0.0f;
    private bool moving = false;
		private int jump = 0;

    void Awake()
    {
				rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
    }

		void OnCollisionEnter2D(Collision2D col){

		 Debug.Log("Jump Reset");
		 Debug.Log(transform.position - col.transform.position);
		 jump = 0;
		 if (col.gameObject.tag == ""){
			 jump = 0;
		 }
		}

    void Update()
    {
        //Press the Up arrow key to move the RigidBody upwards
        if (Input.GetKey(KeyCode.LeftArrow))
        {
						float curr_y = rb.velocity.y;
            moving = true;
            t = 0.0f;
						if (Input.GetKey(KeyCode.LeftShift)) {
							rb.velocity = new Vector2(-6.0f, curr_y);
						}
						else {
							rb.velocity = new Vector2(-2.0f, curr_y);
						}
        }

        //Press the Down arrow key to move the RigidBody downwards
        if (Input.GetKey(KeyCode.RightArrow))
        {
						float curr_y = rb.velocity.y;

            moving = true;
            t = 0.0f;
						if (Input.GetKey(KeyCode.LeftShift)) {
							rb.velocity = new Vector2(6.0f, curr_y);
						}
						else {
							rb.velocity = new Vector2(2.0f, curr_y);
						}
        }

				if (!(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
				{
					 float curr_y = rb.velocity.y;
					 rb.velocity = new Vector2(0.0f, curr_y);

				}

				if (Input.GetKeyDown(KeyCode.UpArrow) && jump < 2) {
					float curr_x = rb.velocity.x;
					rb.velocity = new Vector2(curr_x, 5.0f);
					jump += 1;
				}

        if (moving)
        {
            // Record the time spent moving up or down.
            // When this is 1sec then display info
            t = t + Time.deltaTime;
            if (t > 1.0f)
            {
                Debug.Log("x = " + gameObject.transform.position.x + "  y = " + gameObject.transform.position.y);
                t = 0.0f;
            }
        }
    }
}
