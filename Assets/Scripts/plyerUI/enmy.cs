using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            collider.transform.GetComponent<PlayerHealth>().TakeDamage(10);
            // Destroy(gameObject);
        }
        
    }
}
