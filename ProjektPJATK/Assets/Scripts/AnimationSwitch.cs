using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Animations;
using System.IO;
using TMPro;



public class AnimationSwitch : CharacterSelection {


    //inicjalizacja instancji animator controllera
    public RuntimeAnimatorController anim;
    //inicjalizacja buttonow
    public GameObject counter;
    public GameObject prev;
    public GameObject next;
    public TMP_Text textValue;
    
    //zmienne sterujace
    private string _currentNameBool;
    private string _currentNameTrig;
    private string _previousNameBool;
    private int _animationCount;
    internal int _currentAnimIndex;
    internal int _currentAnim;

    //inicjalizacja struktur przechowujacych
    List<Animator> animator = new List<Animator>();
    List<string> boolName = new List<string>();
    List<string> textData = new List<string>();

    // inicjalizacja instancji
    void Start()
    {
        _currentAnim = 0;
        _currentAnimIndex = 0;
        //pobranie ilosci animacji
        _animationCount = anim.animationClips.Length;

       //wylaczenie pierwszego przycisku na start
        prev.SetActive(false);

        //uzupelnienie listy animatorow z postaci
        foreach(GameObject ch in characterList)
        {
            animator.Add(ch.GetComponent<Animator>());
        }
              
        //dostep do parametrow triggerujacych animacje
        AnimatorControllerParameter[] parameters = animator[0].parameters;
   
        //wypelnienie listy parametrami
        for (int i = 0; i < _animationCount-1; i++)
        {
            boolName.Add(parameters[i].name);

        }
        //inicjalizacja poczatkowego parametru 
        animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);

        //inicjalizacja licznika
        counter.GetComponent<Text>().text  = (_currentAnim+1).ToString() + " / " + (_animationCount -1).ToString();
        readFromFile();
        textValue.text = textData[_currentAnim];
        
    }
	// funkcje dzialajace do klatke
	void Update ()
    {
        //jezeli wykryto zmiane postaci zmienia aktywny animator
       if(change)
        {
            for(int i=0; i<characterList.Length; i++)
            {
                if(characterList[i].activeSelf == true)
                {
                    _currentAnimIndex = i;
                    animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
                }
            }

        }
    }

    //odtwarzanie aktualnej animacji dla aktywnego animatora
    public void PlayAnim()
    {

        if(animator[_currentAnimIndex].enabled == false)
        {
            animator[_currentAnimIndex].enabled = true;
        }
        else
        {
            if (animator[_currentAnimIndex].GetBool(boolName[_currentAnim]) == true)
            {
                animator[_currentAnimIndex].SetTrigger("AnimTrig");

            }
        }
    }
    //pauzowanie animacji
    public void PauseAnim()
    {
        animator[_currentAnimIndex].enabled = false;
    }
    //resetowanie animacji
    public void StopAnim()
    {
        if (animator[_currentAnimIndex].enabled == false)
        {
            animator[_currentAnimIndex].enabled = true;
            animator[_currentAnimIndex].SetTrigger("IdleOn");
            animator[_currentAnimIndex].ResetTrigger("AnimTrig");
        }
        else
        {
            animator[_currentAnimIndex].SetTrigger("IdleOn");
            animator[_currentAnimIndex].ResetTrigger("AnimTrig");
        }
    }
    //przelaczenie animacji na kolejna zmieniajac opis howto oraz licznik
    public void NextAnim()
    {    
        if(_currentAnim < _animationCount - 2)
        {
            
            if (animator[_currentAnimIndex].enabled == false)
            {
                animator[_currentAnimIndex].enabled = true;
                animator[_currentAnimIndex].SetBool(boolName[_currentAnim], false);
                animator[_currentAnimIndex].SetTrigger("IdleOn");
                animator[_currentAnimIndex].ResetTrigger("AnimTrig");
            }
            else
            {
                animator[_currentAnimIndex].SetBool(boolName[_currentAnim], false);
                animator[_currentAnimIndex].SetTrigger("IdleOn");
                animator[_currentAnimIndex].ResetTrigger("AnimTrig");
            }
            if (_currentAnim == 0)
            {
                prev.SetActive(true);
            }
                    _currentAnim++;
            textValue.text = textData[_currentAnim];
            counter.GetComponent<Text>().text = (_currentAnim+1).ToString() + " / " + (_animationCount - 1).ToString();
            if (_currentAnim == _animationCount - 2)
            {
                next.SetActive(false);
             
            }
            animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
        }
        
    }
    //przelaczenie animacji na poprzednia zmieniajac opis howto oraz licznik
    public void PrevAnim()
    {      
        if (_currentAnim > 0)
        {
            if (animator[_currentAnimIndex].enabled == false)
            {
                animator[_currentAnimIndex].enabled = true;
                animator[_currentAnimIndex].SetBool(boolName[_currentAnim], false);
                animator[_currentAnimIndex].SetTrigger("IdleOn");
                animator[_currentAnimIndex].ResetTrigger("AnimTrig");
            }
            else
            {
                animator[_currentAnimIndex].SetBool(boolName[_currentAnim], false);
                animator[_currentAnimIndex].SetTrigger("IdleOn");
                animator[_currentAnimIndex].ResetTrigger("AnimTrig");
            }
            if (_currentAnim == _animationCount - 2)
            {
                next.SetActive(true);

            }
            _currentAnim--;
            textValue.text = textData[_currentAnim];
            counter.GetComponent<Text>().text = (_currentAnim+1).ToString() + " / " + (_animationCount - 1).ToString();
            if (_currentAnim == 0)
            {
                prev.SetActive(false);
            }
            animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
        }
        
    }
    //wczytanie opisow howto z pliku. Po zbudowaniu aplikacji plik z opisami nalezy umiescic w folderze data
    private List<string> readFromFile()
    {
        string dataFilePath = Path.Combine(Application.dataPath, "HowToText.txt");
        
        try
        {
            
            string line = null;
        
            using (StreamReader myFile = new StreamReader(dataFilePath))
            {
                while (line != "\n") 
                {                
                                      
                    if (line != null)
                    {                    
                            textData.Add(line);                     
                    }
                    line = myFile.ReadLine() + "\n" + myFile.ReadLine();
                }
                
            
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log(e.Message);
        }
         
        return textData;
    }

    
}
