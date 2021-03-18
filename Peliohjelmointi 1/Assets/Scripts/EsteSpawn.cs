using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Sami Kaski
public class EsteSpawn : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    



    void Start()
    {
        
    }

    
    void Update()
    {
        
        
        GameObject currentChild;
        for (int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
        }
        
        
    }

    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

     

   
}
