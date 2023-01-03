using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blooddrop : MonoBehaviour
{
  
    void Update()
    {
        //when blood drop reaches ground, it goes back up
        if(transform.position.y<-10)
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);

        // moving the drop down by changing the x value position
        transform.position = new Vector3(transform.position.x, transform.position.y-0.07f, transform.position.z);
    }
}
