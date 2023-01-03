using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WINDOW : MonoBehaviour
{
    // Lightning GameObject
    public GameObject Lightning;

    // Start is called before the first frame update
    void Start()
    {
        // Find GameOjects with tag Window
        GameObject[] windows = GameObject.FindGameObjectsWithTag("WINDOW");
        // If gameobjects are greater than 5 then delete one instace to free up memory
        if (windows.Length >= 5)
            Destroy(windows[0]);
        // Enable lightning after random for a few seconds
        int r = Random.Range(2, 5);
        Invoke("EnableLightning", r);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableLightning()
    {
        
       // Turn on Lightning
        Lightning.SetActive(true);

        int r = Random.Range(2, 5);
        Invoke("NextLightnin", r);
    }
    void TurnOffLightning()
    {

    }
    void NextLightnin()
    {
        // Turn Off Lightning 
        Lightning.SetActive(false);
        int r = Random.Range(2, 5);
        Invoke("EnableLightning", r);
    }
}
