using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{   private GameObject player;
    LevelSystem playerLevel;
    public int enemyLevel;
    public float enemyXp;
    public float XpMultiplier;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            collider.transform.GetComponent<PlayerHealth>().TakeDamage(10);
            // Destroy(gameObject);
            OnDead();
        }
        
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = player.GetComponent<LevelSystem>();
        enemyLevel = Random.Range(1, playerLevel.level + 2);

        //Scale Enemy XP ----- don't use this if you want to set enemy levels manually.
        enemyXp = Mathf.Round(enemyLevel * 6 * XpMultiplier);
       
    }
     public  void OnDead() 
    {
       
        playerLevel.GainExperienceScalable(enemyXp, enemyLevel);
       
    }
}
