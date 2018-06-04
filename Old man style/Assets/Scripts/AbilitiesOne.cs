using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Den här filen tar hand om den första karaktärens ultimata förmåga

public class AbilitiesOne : MonoBehaviour {

    public static bool CanUltimate = false;
    KeyCode key = KeyCode.Q;        //Den här biten bestämmer att Q ska användas som en knapp

    private void Start()
    {
        CanUltimate = false;
    }

    private void OnGUI()
    {

        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Q.ToString())) && CanUltimate == true)     //Den här biten kallar på Q så att man kan använda den ultimata förmågan
        {

            Player_Move_Prot.PlayerSpeed = 20;
            CanUltimate = false;

        }
        else if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Q.ToString())) && CanUltimate == false)
        {

            Debug.Log("You need ultimate charge");

        }

    }

}
