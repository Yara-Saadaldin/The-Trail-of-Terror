using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TIMER : MonoBehaviour
{
    // This is timer
    float timer = 0.0f;
    // This is the counting time
    int counter = 0;
    // This will hold Audio Source for timer sound
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // If game is running the score starts counting
        if (GAMEMECHANICS.state == "running")
        {
            // Turn on background sound
            if (!sound.isPlaying)
                sound.Play();
            timer += Time.deltaTime;
            int seconds = (int)(timer);
            this.GetComponent<Text>().text = seconds.ToString();
        }
        else
            // if game is paused then stop the background sound
            sound.Stop();
  
       
    }
}
