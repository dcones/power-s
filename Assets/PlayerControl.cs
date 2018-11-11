using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
		private SpriteRenderer sr;
    private GameObject projectile;
    private float mana;
		private int jump;
		private float facingRight;
    private bool isGrounded;

    public float getMana() {
      return mana;
    }

    void Awake()
    {
				rb = gameObject.GetComponent<Rigidbody2D>();
				sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
        mana = 5.0f;
        jump = 0;
        facingRight = 1.0f;
        projectile = GameObject.FindWithTag("Projectile");
        isGrounded = true;
    }

		// Collision Logic
		void OnCollisionEnter2D(Collision2D col){

		 // Only vertical collisions resets the jump counter
     if (col.gameObject.tag == "Floor") {
       jump = 0;
       isGrounded = true;
     }

     if (col.gameObject.tag == "Mob" && col.contacts[0].relativeVelocity[1] > 0) {
       float curr_x = rb.velocity.x;
       rb.velocity = new Vector2(curr_x, 400.0f);
       jump = 0;
     }
    }
    void OnCollisionExit2D(Collision2D col){

		 // Only vertical collisions resets the jump counter
     if (col.gameObject.tag == "Floor") {
       jump = 1;
       isGrounded = false;
     }
		}

    void OnGUI()
    {
       GUI.Label(new Rect(0, 0, 100, 100),  Mathf.Round(mana).ToString());
    }

    void Update()
    {
				// IDLE
				if ((!(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))) || (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)))
				{
					 float curr_y = rb.velocity.y;
           float curr_x = rb.velocity.x;
           if (isGrounded) {
             rb.velocity = new Vector2(0.80f*curr_x, curr_y);
           }
           else {
             rb.velocity = new Vector2(0.95f*curr_x, curr_y);
           }

				}

				// MOVE LEFT OR RIGHT
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow)) {
              facingRight = -1.0f;
              sr.flipX = true;
            }

            else if (Input.GetKey(KeyCode.RightArrow)) {
              facingRight = 1.0f;
              sr.flipX = false;
            }

						float curr_y = rb.velocity.y;
            float curr_x = rb.velocity.x;
            float new_speed = 400.0f;
						if (Input.GetKey(KeyCode.LeftShift)) {
							rb.velocity = new Vector2(curr_x + facingRight*new_speed*1.5f, curr_y);
              if (Mathf.Abs(rb.velocity.x) > new_speed*1.5f) {
                rb.velocity = new Vector2(facingRight*new_speed*1.5f, curr_y);
              }
						}
						else {
							rb.velocity = new Vector2(curr_x + facingRight*new_speed*1.0f, curr_y);
              if (Mathf.Abs(rb.velocity.x) > new_speed*1.0f) {
                rb.velocity = new Vector2(facingRight*new_speed*1.0f, curr_y);
              }
						}
        }

				// JUMP
				if (Input.GetKeyDown(KeyCode.UpArrow) && jump < 2) {
					float curr_x = rb.velocity.x;
					rb.velocity = new Vector2(curr_x, 400.0f);
					jump += 1;
				}

        if (mana < 5.0f) {
          mana += 1.0f/(mana*20.0f + 15.0f);
          if (mana > 5.0f) mana = 5.0f;
        }

        if (Input.GetKeyDown(KeyCode.X) && mana > 1) {
					GameObject clone;
          clone = Instantiate(projectile, transform.position + new Vector3(50.0f*facingRight, 0.0f, 0.0f), transform.rotation);
          clone.AddComponent<ProjectileBehaviour>();
          clone.GetComponent<SpriteRenderer>().enabled = true;
          clone.GetComponent<Rigidbody2D>().velocity = new Vector2(500.0f*facingRight, 0.0f);
          mana -= 1.0f;
          rb.velocity = new Vector2(rb.velocity[0] - 400.0f*facingRight , rb.velocity[1]);
				}
    }
}
