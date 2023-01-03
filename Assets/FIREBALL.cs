using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FIREBALL : MonoBehaviour
{
    // hld collider
    private Collider2D Collider;
    // hold direction of fireball
    private string direction;
    // Start is called before the first frame update
    void Start()
    {
        // find Player Gameobject
        GameObject p = GameObject.Find("Player");
        // randomly decide the fireball direction  whether from top to bottom or bottom to top
        int r = Random.Range(0, 10);
        if (r % 2 == 0)
            direction = "down";
        else
            direction = "up";

        
        if(direction=="down")
            this.transform.position=new Vector3(p.transform.position.x+7, transform.position.y, transform.position.z);
        else
            this.transform.position = new Vector3(p.transform.position.x + 7, p.transform.position.y-2, transform.position.z);
        Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If direction is down then fireball will move up by decreasing y position
        if (direction=="down")
            this.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        else
            // If direction is up then fireball will move down by increasing y position
            this.transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);


        // If fireball is above ground and below ceiling then remove the fireball
        // To free up the memory
        if (transform.position.y<-6 || transform.position.y > 7)
            Destroy(this.gameObject);


    }
    
  }
