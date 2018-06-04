using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Den här filen tar hand om fienders liv.

public class Enemy_Health : MonoBehaviour
{

    void Update()
    {

        if (gameObject.transform.position.y < -17)
        {
            Destroy(gameObject);
        }
    }
}
