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
    }

		// Collision Logic
		void OnCollisionEnter2D(Collision2D col){

		 // Only vertical collisions resets the jump counter
     if (col.gameObject.tag == "Floor") {
       jump = 0;
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
					 rb.velocity = new Vector2(0.0f, curr_y);
				}

				// MOVE LEFT
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
						facingRight = -1.0f;
						sr.flipX = true;
						float curr_y = rb.velocity.y;
						if (Input.GetKey(KeyCode.LeftShift)) {
							rb.velocity = new Vector2(-300.0f, curr_y);
						}
						else {
							rb.velocity = new Vector2(-200.0f, curr_y);
						}
        }

				// MOVE RIGHT
        else if (Input.GetKey(KeyCode.RightArrow))
        {
						facingRight = 1.0f;
						sr.flipX = false;
						float curr_y = rb.velocity.y;
						if (Input.GetKey(KeyCode.LeftShift)) {
							rb.velocity = new Vector2(300.0f, curr_y);
						}
						else {
							rb.velocity = new Vector2(200.0f, curr_y);
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
          clone = Instantiate(projectile, transform.position, transform.rotation);
          clone.AddComponent<ProjectileBehaviour>();
          clone.GetComponent<SpriteRenderer>().enabled = true;
          clone.GetComponent<Rigidbody2D>().velocity = new Vector2(500.0f*facingRight, 0.0f);
          mana -= 1.0f;
				}
    }
}
