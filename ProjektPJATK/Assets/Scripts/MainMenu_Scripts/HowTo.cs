using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class HowTo : MonoBehaviour {

    public GameObject howToMenu;
    //uaktywnienie menu howto

    public void howToActivate()
    {
        if (howToMenu.activeSelf == false)
        {
            howToMenu.SetActive(true);
        }
        else
        {
            howToMenu.SetActive(false);
        }
    }
    

}
