using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using StarterAssets;
using UnityEngine;

public class figting : MonoBehaviour
{
    private  Animator _animator;
    public float emXp=1;
    public int PLevel=1;
    private GameObject player;
    LevelSystem playerLevel;
   
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = player.GetComponent<LevelSystem>();
    

    }

    void Update()
    {
        
    }

    // private finger _finger = new finger();
    
    private void open()
    {
        //  _finger.fin= (e) =>
        // {
        //     if (e==1)
        //     {
        //         transform.GetComponent<Collider>().enabled = true;
        //     }
        //     else
        //     {
        //         transform.GetComponent<Collider>().enabled = false;
        //     }
        // };
       
        
    }
    
    public  void OnDead() 
    {
       
        playerLevel.GainExperienceScalable(emXp, PLevel);
       
    }
   
    
    private void OnTriggerEnter(Collider collider)
    {
        
        
       
        if (collider.transform.CompareTag("Enemy"))
        {
           
          Destroy(collider.gameObject);
          OnDead();
        }

    }
}
