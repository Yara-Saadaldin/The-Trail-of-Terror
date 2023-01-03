using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEMECHANICS : MonoBehaviour
{
    // this will hold state of gameobject
    // This is static string because this variable will be accessed by other gameobect script as well
    public static string state;
    // This will hold Pause Panel
    public GameObject Pausepanel;


    void Start()
    {
        // In state game will be in running state
        state = "running";
    }


    // Update is called once per frame
    void Update()
    {
        // If p button is pressed the pause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            state = "paused";
            Pausepanel.SetActive(true);

        }
        // If R button is pressed it will result to Resume the game if game is paused or restart if game failed.
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(state=="paused")
            {
                state = "running";
                Pausepanel.SetActive(false);
            }
            if(state=="failed")
            {   
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }
    public void pause()
    {
        state = "paused";
        Pausepanel.SetActive(true);
    }
    public void resume()
    {
        state = "running";
        Pausepanel.SetActive(false);
    }
    // This will change state of game
    public void SetState(string s)
    {
        state = s;
    }
}
