using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject Face;
    void Start()
    {
        // Find timer for ghost face to appear
        int r = Random.Range(2, 5);
        Invoke("EnableFace", r);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnableFace()
    {

        // Face will appear
        Face.SetActive(true);
        // Then face will disappear after random few milli seconds
        int r = Random.Range(1, 3);
        Invoke("NextFace", r);
    }
    void NextFace()
    {
        Face.SetActive(false);
        int r = Random.Range(4, 7);
        Invoke("EnableFace", r);
    }
}
