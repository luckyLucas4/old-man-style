using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Den här filen tar hand om fiendens förflyttning samt vad som händer när dem dödar spelaren.

public class EnemyMove : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;

	void Update () {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.7f)
        {
            Flip ();
            if (hit.collider.name == "Player")
            {
                SceneManager.LoadScene("LevelOne");
            }
            else if (hit.collider.name == "Player_Prot")
            {
                SceneManager.LoadScene("LevelTwo");
            }
        }

	}

    void Flip ()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}