using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CharacterSelection : MonoBehaviour
{
    internal static GameObject[] characterList;
    internal int index;
    internal static bool change;
 
    private void Start()
    {
        characterList = new GameObject[transform.childCount];
        //fill array with our modules
        for(int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;
        // We toogle off their renderer
        foreach (GameObject go in characterList)
            go.SetActive(false);
        //we toggle off the first index
        if (characterList[0])
        {
            characterList[0].SetActive(true);
        }
           
    }

    public void ToggleLeft()
    {
        //Toggle off the current model
        characterList[index].SetActive(false);
        index = 0;
        change = true;
        //Toggle on the new model
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        //Toggle off the current model
        characterList[index].SetActive(false);
        
        index = 1;
        change = true;
        //Toggle on the new model
        characterList[index].SetActive(true);
    }
}
