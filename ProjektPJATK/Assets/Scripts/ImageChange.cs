using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ImageChange : MonoBehaviour {
    public Button Agnieszka;
    public Sprite Agnieszka_pic;
    public Sprite Agnieszka_pic_disable;
    public Button Marek;
    public Sprite Marek_pic;
    public Sprite Marek_pic_disable;
    bool activeA = true, activeM = false;
    
	// Use this for initialization
	void Start () {
        Agnieszka = GetComponent<Button>();
        Marek = GetComponent<Button>();
        Agnieszka.image.overrideSprite = Agnieszka_pic;
        Marek.image.overrideSprite = Marek_pic_disable;
    }

    public void changeImageAgnieszkaLight()
    {
        if (activeA == false && activeM == true)
        {
            Agnieszka.image.overrideSprite = Agnieszka_pic;
            Marek.image.overrideSprite = Marek_pic_disable;
            activeA = true;
            activeM = false;
        }
    }
    public void changeImageMarekLight()
        {
        if (activeA == true && activeM == false) { 
            Marek.image.overrideSprite = Marek_pic;
            Agnieszka.image.overrideSprite = Agnieszka_pic_disable;
            activeA = false;
            activeM = true;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
