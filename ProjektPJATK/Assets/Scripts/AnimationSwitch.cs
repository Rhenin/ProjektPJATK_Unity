﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Animations;

public class AnimationSwitch : CharacterSelection {

    public RuntimeAnimatorController anim;
    
    GameObject counter;
    GameObject prev;
    GameObject next;

    private string _currentNameBool;
    private string _currentNameTrig;
    private string _previousNameBool;
   
    private int _animationCount;
    private int _currentAnimIndex;
    private int _currentAnim;

    List<Animator> animator = new List<Animator>();
    List<string> boolName = new List<string>();

    // Use this for initialization
    void Start()
    {
        _currentAnim = 0;
        _currentAnimIndex = 0;
        _animationCount = anim.animationClips.Length;

        counter = GameObject.Find("Count");
        prev = GameObject.Find("Prev");
        next = GameObject.Find("Next");
        prev.SetActive(false);

        foreach(GameObject ch in characterList)
        {
            animator.Add(ch.GetComponent<Animator>());
        }
              
        
        AnimatorControllerParameter[] parameters = animator[0].parameters;
   
        for (int i = 0; i < _animationCount-1; i++)
        {
            boolName.Add(parameters[i].name);

        }
        animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);

        counter.GetComponent<Text>().text  = (_currentAnim+1).ToString() + " / " + (_animationCount -1).ToString();
        
    }
	// Update is called once per frame
	void Update ()
    {
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




            /*if (agnieszka.activeSelf == true)
            {      
                _currentAnimIndex = 0;
                animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
            }
            if (marek.activeSelf == true)
            {
                _currentAnimIndex = 1;
                animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
            }*/
        }
    }


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

    public void PauseAnim()
    {
        animator[_currentAnimIndex].enabled = false;
    }
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
            counter.GetComponent<Text>().text = (_currentAnim+1).ToString() + " / " + (_animationCount - 1).ToString();
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
            counter.GetComponent<Text>().text = (_currentAnim+1).ToString() + " / " + (_animationCount - 1).ToString();
            if (_currentAnim == 0)
            {
                prev.SetActive(false);
            }
            animator[_currentAnimIndex].SetBool(boolName[_currentAnim], true);
        }
        
    }
}