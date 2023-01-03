using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHOSTMOVEMENT : MonoBehaviour
{
   
    void Update()
    {
        // First Check if game is in running state and not in pause state or game failed state
        if(GAMEMECHANICS.state=="running")
        {
            // If Ghost is too far from the player then bring him close but not too close just before camera 
            // Check x position of Player and then bring ghost 20 x from player
            if(GameObject.Find("Player").transform.position.x-transform.position.x>10)
                transform.position = new Vector3(GameObject.Find("Player").transform.position.x-10f, transform.position.y, transform.position.z);

            // move the ghost towards the player continuosly
            // Increase x cordinate position of ghost so that the ghost keeps on moving to the right
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
        }
            
    }
}
