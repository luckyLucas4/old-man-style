using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Det här scriptet tar hand om fienden "Spiker"

public class SpikerMove : MonoBehaviour {

    public int SpikerJumpPower = 1250;
    public bool SpikerIsGrounded = false;

    private void OnCollisionEnter2D(Collision2D collision)      //Den här koden ser till att rätt nivå laddas när en spelare blir dödad av "spiker"
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene("LevelOne");
        }
        else if (collision.gameObject.name == "Player_Prot")
        {
            SceneManager.LoadScene("LevelTwo");
        }

            if (collision.gameObject.layer == 8)
            {
                SpikerIsGrounded = true;
            }

    }

    private void OnGUI()            //Den här koden ser till att "Spiker" hoppar sammtidigt som sig själv
    {

        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())) && SpikerIsGrounded == true)
        {

            SpikerJump();
            SpikerIsGrounded = false;

        }

    }

    void SpikerJump()
    {

        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * SpikerJumpPower);

    }
}
