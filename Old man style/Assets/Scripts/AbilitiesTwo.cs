using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Den här filen tar hand om den andra karaktärens ultimata förmåga

public class AbilitiesTwo : MonoBehaviour {

    //public static bool CanUltimate = false;
    //KeyCode key = KeyCode.Q;

    private void OnGUI()
    {

        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Q.ToString())) && AbilitiesOne.CanUltimate == true)       //Den här biten kallar på Q så att man kan använda den ultimata förmågan
        {

            transform.localScale += new Vector3(1.5F, 1.5F, 0);
            AbilitiesOne.CanUltimate = false;

        }
        else if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Q.ToString())) && AbilitiesOne.CanUltimate == false)
        {

            Debug.Log("You need ultimate charge");

        }

    }

}
