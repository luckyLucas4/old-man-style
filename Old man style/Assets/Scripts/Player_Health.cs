using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Den här filen tar hand om spelarens hälsa och vad som händer när den dör.

public class Player_Health : MonoBehaviour {

    public GameObject PlayerOne;
    public GameObject PlayerTwo;

	void Update () {

        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
	}

    void Die ()
    {
            SceneManager.LoadScene("CharacterSelect");
    }

}
