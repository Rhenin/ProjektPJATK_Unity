using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class AnimationSwitch : CharacterSelection {


    List<Animator> animator = new List<Animator>();
    public RuntimeAnimatorController anim;
    public GameObject agnieszka;
    public GameObject marek;
    GameObject prev;
    GameObject next;

    private string _currentNameBool;
    private string _currentNameTrig;
    private string _previousNameBool;

    private int _animationCount;
    private int _currentAnimIndex;
    private int _currentAnim;
    
 
    List<string> boolName = new List<string>();
    List<string> trigName = new List<string>();

    // Use this for initialization
    void Start()
    {
        _currentAnim = 0;
        _currentAnimIndex = 0;
        prev = GameObject.Find("Prev");
        next = GameObject.Find("Next");
        prev.SetActive(false);
        animator.Add(agnieszka.GetComponent<Animator>());
        animator.Add(marek.GetComponent<Animator>());

        _animationCount = anim.animationClips.Length;
        AnimatorControllerParameter[] parameters = animator[0].parameters;
        
       
        
        for (int i = 0; i < _animationCount-1; i++)
        {
            boolName.Add(parameters[i].name);

        }
        for (int i = (_animationCount - 1); i < (_animationCount - 1) * 2; i++)
        {
            trigName.Add(parameters[i].name);

        }
        animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);

    }
	// Update is called once per frame
	void Update ()
    {
       if(change)
        {
            if (agnieszka.activeSelf == true)
            {      
                _currentAnimIndex = 0;
                animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
            }
            if (marek.activeSelf == true)
            {
                _currentAnimIndex = 1;
                animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);


            }
        }
    }


    public void PlayAnim()
    {
        if(animator[_currentAnimIndex].GetBool(boolName[_currentAnim]) == true)
        {
            animator[_currentAnimIndex].SetTrigger(trigName[_currentAnim]); 
        }
    }

    public void NextAnim()
    {    
        if(_currentAnim < _animationCount - 2)
        {
            animator[_currentAnimIndex].SetBool(boolName[_currentAnim], false);
            animator[_currentAnimIndex].SetTrigger("IdleOn");
            if (_currentAnim == 0)
            {
                prev.SetActive(true);
            }
                    _currentAnim++;
           
            if (_currentAnim == _animationCount - 2)
            {
                next.SetActive(false);
             
            }
            animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
        }
        
    }
    public void PrevAnim()
    {      
        if (_currentAnim > 0)
        {
            animator[_currentAnimIndex].SetBool(boolName[_currentAnim], false);
            animator[_currentAnimIndex].SetTrigger("IdleOn");
            if (_currentAnim == _animationCount - 2)
            {
                next.SetActive(true);

            }
            _currentAnim--;
            if (_currentAnim == 0)
            {
                prev.SetActive(false);
            }
            animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
        }
        
    }
}
