using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoretext : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = score.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
