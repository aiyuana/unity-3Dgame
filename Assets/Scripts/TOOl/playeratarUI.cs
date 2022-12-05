using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeratarUI : MonoBehaviour
{
    private GameObject attack;
        public void Start()
        {
           
            attack= Resources.Load<GameObject>("Slash12");
           
            
        }
    
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                GameObject clone = Instantiate<GameObject>(attack);
                clone.transform.position = transform.position;
                Destroy(clone,0.2f);
            }
    
            
        }
}
