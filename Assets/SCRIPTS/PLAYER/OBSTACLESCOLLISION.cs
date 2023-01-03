using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBSTACLESCOLLISION : MonoBehaviour
{
    // This will contain number of collisions
    int collisions;
    // This game Object will hold Ghost
    GameObject ghost;
    // This gameobject will hold FailedPanel
    public GameObject FAILEDPANEL;
    // This audiosoruce will contain HurtSound which will play on first collision
    public AudioSource HurtSound;
    // This aurdiosource will contain Death Sound which will play on second collision
    public AudioSource Death;
    // This will contain animator
    private Animator Animator;
    // Start is called before the first frame update

    public GameObject HEART1;
    public GameObject HEART2;

    void Start()
    {
        // At start collisions are 0
        collisions = 0;
        // Assign Ghost to ghost
        ghost = GameObject.Find("GHOST");
        // This will assign animator
        Animator = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        // If player falls in gap between ground
        if(this.transform.position.y<-6)
        {

            GAMEMECHANICS.state = "failed";
            Death.Play();
            FAILEDPANEL.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // If player touchsd the ghost
        Debug.Log(other.name);
        if (other.name == "GHOST")
            collisions = 2;

        collisions++;
        // On first collision
        if (collisions == 1)
        {
            HEART2.SetActive(false);
            // Play Hurt Animation
            Animator.SetBool("Hurt", true);
            // Play Hurt Sound
            HurtSound.Play();
            // ON FIRST COLLISION GHOST GETS NEAR TO PLAYER
            // Check whether if ghost is too near to the player or not
            if(ghost.transform.position.x+14f<transform.position.x-5)
            {
                ghost.transform.position = new Vector3(ghost.transform.position.x + 14f, ghost.transform.position.y, ghost.transform.position.z);

            }
           
            Invoke("hurtanimation", 0.5f);
        }
        else
        {
            HEART1.SetActive(false);
            // On Second Collision
            ghost.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Animator Animator = GetComponent<Animator>();
            // RUN DEATH ANIMATION
            Animator.SetBool("Death", true);
            // CALL GAMEFAILED FUNCTION
            Invoke("GAMEFAILED", 2f);
            // PLAY DEATH SOUND
            Death.Play();
        }
  
    }

    // To play hurt animation
   void hurtanimation()
    {
        // HURT ANIMATION
        Animator.SetBool("Hurt", false);
    }
    // game failed animation
  void GAMEFAILED()
    {
        // CHANGE GAME STATE TO FAILED
        GAMEMECHANICS.state = "failed";
        // TURN ON GAMEFAILED PANEL
        FAILEDPANEL.SetActive(true);
    }
}
