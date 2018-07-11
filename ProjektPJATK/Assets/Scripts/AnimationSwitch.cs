using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationSwitch : MonoBehaviour {

   
    public Animator animator;
    public GameObject agnieszka;
    private string _currentNameBool;
    private string _currentNameTrig;
    private string _previousNameBool;
    private int _currentAnim;
    private bool next;
    List<string> boolName = new List<string>();
    List<string> trigName = new List<string>();

    // Use this for initialization
    void Start()
    {
        _currentAnim = 0;
        next = false;

        animator = agnieszka.GetComponent<Animator>();
        AnimatorControllerParameter[] parameters = animator.parameters;


        
        for (int i = 0; i < 13; i++)
        {
            boolName.Add(parameters[i].name);

        }
        for (int i = 13; i < 26; i++)
        {
            trigName.Add(parameters[i].name);

        }
        Debug.Log(trigName.Count);
        
    }
	// Update is called once per frame
	void Update ()
    {
    }

    public void PlayAnim()
    {
        if(animator.GetBool(boolName[_currentAnim]) == true)
        {
            animator.SetTrigger(trigName[_currentAnim]); 
        }
    }

    public void NextAnim()
    {
        
        if(_currentAnim < 12)
        {
            animator.SetBool(boolName[_currentAnim], false);
            animator.SetTrigger("IdleOn");
            _currentAnim++;
            animator.SetBool(boolName[_currentAnim], true);
        }
        
    }
    public void PrevAnim()
    {
        
        if (_currentAnim > 0)
        {
            animator.SetBool(boolName[_currentAnim], false);
            animator.SetTrigger("IdleOn");
            _currentAnim--;
            animator.SetBool(boolName[_currentAnim], true);
        }
        
    }
}
