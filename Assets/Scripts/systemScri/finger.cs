using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger : MonoBehaviour
{
    private GameObject Dao;
    public AudioClip attrtSound;
    private AudioSource source;
    
    private Animator  _animator ;
  private void Update()
   {
       
       AnimationClick(); 
   }
  
  private void Start()
  { 
      _animator = gameObject.transform.GetComponent<Animator>();
     
    Dao=GameObject.Find("fring");
 
    
  }

  private void Awake()
  {
    
  }
 
  
  
   private void AnimationClick( )
   {

     
      if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Atk8")||_animator.GetCurrentAnimatorStateInfo(0).IsName("atk_5"))
      {

         Dao.transform.GetComponent<Collider>().enabled = true;
   

    

   AudioManager.instance.AudioPlay(attrtSound);


      }
      else
      {
        
          Dao.transform.GetComponent<Collider>().enabled = false;

      }
      
   }
}
