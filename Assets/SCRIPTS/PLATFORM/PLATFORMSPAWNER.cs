using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATFORMSPAWNER : MonoBehaviour
{
    // This will duplicate Platforms
    private GameObject[] PLATFORMS;
    // This will hold player object
    public GameObject Player;
    // This will hold last enemy position
    float lastenemyposition;
    // This is counter for spawning enemies
    int counter;
    // This array will hold all enemies
    public GameObject[] Obstacles;
    // Start is called before the first frame update
    void Start()
    {
        // This counter value is for creating first obstacle
        counter = Random.Range(0, 1000);
        // This will make platform
        MakePaltform();
        //This will spawn first enemy/obstacle
        spawnEnemey();

    }
    void spawnEnemey()
    {
        // If counter is above 1000 then enemy will be created. by decreasing this we can lower the difficulty
        if (counter >= 10) 

        {
            // To Generate Random Obstacle
            int random = Random.Range(0, Obstacles.Length);
            // Find All Obstacles
            GameObject[] ENEMIES = GameObject.FindGameObjectsWithTag("ENEMY");
            // If Obstacles are present then find distance from last Obstacle 
            // is 14 x distance then we can spawn new obstacle 
            // distance between 2 obstacles
            if(ENEMIES.Length>0)
            {
                lastenemyposition = ENEMIES[ENEMIES.Length-1].transform.position.x;
                // New obstacle will be created after certain distance from player
                float newposition = Player.transform.position.x + 14.012f;
               
                // If new obstacle is not too close to previous obstacle
                if (newposition - lastenemyposition > 20)
                {
                   // Crate new Random Obstacle
                    Instantiate(Obstacles[random], new Vector3(newposition, Obstacles[random].transform.position.y, Obstacles[random].transform.position.z), Obstacles[random].transform.rotation);
                }
            }
            else
            {
                // This is first obstacle meaning that if there is no previous obstacle Then This obstacle will run

                float newposition = Player.transform.position.x + 14.012f;
                Instantiate(Obstacles[random], new Vector3(newposition, Obstacles[random].transform.position.y, Obstacles[random].transform.position.z), Obstacles[random].transform.rotation);
            }

            // To Free memory we Delete previous obstacles which have been passed by player
            if (ENEMIES.Length > 5)
            {
                Destroy(ENEMIES[0]);
            }
            
            //Duration to create next obstacle
            counter = Random.Range(0, 1000);
        }
        else
            counter++;
    }
    
    // Platform space on wihch player will jump across 
    public float makejump()
    {
        // Platform space on wihch player will jump across 
        // Obstacle which will be jumped by player
        // The space between platform will have random space 
        float r =Random.Range(45.91f, 49f);
        return r;
    }
    void MakePaltform()
    {
       
            // Find Platform GameObjects
            PLATFORMS = GameObject.FindGameObjectsWithTag("PLATFORM");
            // Instantiate New Platform
            GameObject NEW = Instantiate(PLATFORMS[PLATFORMS.Length - 1], new Vector3(PLATFORMS[PLATFORMS.Length - 1].transform.position.x + makejump(), PLATFORMS[PLATFORMS.Length - 1].transform.position.y, PLATFORMS[PLATFORMS.Length - 1].transform.position.z), PLATFORMS[PLATFORMS.Length - 1].transform.rotation);
            // Make new platform the child of GAME OBJECT Platform
            NEW.transform.parent = GameObject.Find("Platform").transform;

        // To spawn background
        GameObject[] BG = GameObject.FindGameObjectsWithTag("BACKGROUND");
        GameObject NEW2 = Instantiate(BG[BG.Length - 1], new Vector3(BG[BG.Length - 1].transform.position.x+115, BG[BG.Length - 1].transform.position.y, BG[BG.Length - 1].transform.position.z), BG[BG.Length - 1].transform.rotation);

        // To spawn ceiling
        GameObject[] CIELING = GameObject.FindGameObjectsWithTag("Ceiling");
        GameObject NEW3 = Instantiate(CIELING[CIELING.Length - 1], new Vector3(CIELING[CIELING.Length - 1].transform.position.x + 40, CIELING[CIELING.Length - 1].transform.position.y, CIELING[CIELING.Length - 1].transform.position.z), CIELING[CIELING.Length - 1].transform.rotation);


        // Even if player move back, the player will be caught up by ghost
        if (PLATFORMS.Length >= 10)
            Destroy(PLATFORMS[4]);

    }
    // Update is called once per frame
    void Update()
    {
        // TO CHECK IF GAME IS IN RUNNING STATE

        if(GAMEMECHANICS.state=="running")
        {
            // TO CREATE OBSTACLE
            spawnEnemey();
            // To make platform
            // We check distance from last platform and player and if that distance is less than 1 then we create a platform
            float d = (PLATFORMS[PLATFORMS.Length - 1].transform.localPosition.x - Player.transform.position.x);
            if (d < 1)
                MakePaltform();
        }
   
    }
}
