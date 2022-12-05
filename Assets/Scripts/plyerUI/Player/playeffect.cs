using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public enum SKillSortEnnum
{
    skill1,
    skill2,
    skill3
}

public class playeffect : MonoBehaviour
{
  
    public static playeffect Instance;
  private GameObject skill1, skill2, skill3;
    private GameObject player;
    public void Start()
    {
        Instance = this;
        player = GameObject.Find("PlayerArmature");
        skill1 = player.transform.Find("Magic circle 5").gameObject;
        skill2 =  player.transform.Find("Magic circle 7").gameObject;
        skill3 =player.transform.Find("Magic circle 6").gameObject;
        
                 
        
    }
   

    public void stop(SKillSortEnnum stop)
    {
        switch (stop)
        {
            case SKillSortEnnum.skill1:
            {
                skill1.SetActive(false);
                
            }
                break;
            case SKillSortEnnum.skill2:
            {
                
                skill2.SetActive(false);
                

            }
                break;
            case SKillSortEnnum.skill3:
            {
                skill3.SetActive(false);
               
            }
                break;
        }
    }

   

    public void UseSkill(SKillSortEnnum skillsort)
    {
        switch (skillsort)
        {
            case SKillSortEnnum.skill1:
            {
               
                skill1.SetActive(true);
                
               
                       
                    

            }
                break;
            case SKillSortEnnum.skill2:
            {
                skill2.SetActive(true);
                

            }
                break;
            case SKillSortEnnum.skill3:
            { 
                skill3.SetActive(true);
               
            }
                break;
        }
    }
}