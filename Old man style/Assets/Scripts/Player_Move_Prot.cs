using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Den här filen tar hand om förflyttningen av spelaren samt hur spelaren reagerar vid kollision med andra objekt

public class Player_Move_Prot : MonoBehaviour {

    public static int PlayerSpeed = 10;
    public int PlayerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;
    public bool hasFinished = false;

    private void Start()
    {
        PlayerSpeed = 10;       //Det här ser till att spelaren återgår till normal hastighet när banan startar om
    }
 
    void Update () {

        PlayerMove();
        PlayerRaycast();
		
	}

    void PlayerMove()
    {
            //CONTROLS
            moveX = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                Jump();
            }

            //ANIMATIONS
            if (moveX != 0)
            {
                GetComponent<Animator>().SetBool("IsRunning", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("IsRunning", false);
            }

            //PLAYER DIRECTION
            if (moveX < 0.0f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (moveX > 0.0f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            //PHYSICS
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * PlayerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    void Jump()
    {

        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * PlayerJumpPower);
        isGrounded = false;

    }

    void PlayerRaycast ()       //Raycast tar ser till att man kan döda fiender samt förståra trasiga stenar och "ultboxar"
    {
        //Ray UP
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.tag == "ultbox")
        {
            Debug.Log("Ult Charged");
            Destroy(rayUp.collider.gameObject);
            BoxDead();
        }

        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.tag == "breakbox")
        {
            Debug.Log("Broke Box");
            Destroy(rayUp.collider.gameObject);
        }

        //Ray DOWN
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }
    }

    private static void BoxDead ()      //Den här texten ser till att man kan använda sin ultimata förmåga efter man förstört en "ultbox"
    {

        AbilitiesOne.CanUltimate = true;

    }

}
