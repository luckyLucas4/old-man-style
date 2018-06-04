using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Den här filen tar hand om kameran


public class CameraSystem : MonoBehaviour {

    private GameObject player; // Det här ser till att kameran bara kan vara inom ett visst område
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Start () {

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player"); // Det här ser till att kameran följer efter spelaren (ifall det finns en spelare)
        }

	}

    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Det här ser till att kameran börjar följa efter spelaren efter man valt den och startat banan
    }

    void LateUpdate () {

            float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
            
	}
}
