using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public ItemUnlocker padlock;
    public ItemUnlocker plank;
    public ItemUnlocker cables;

    public ChickenEater chicken;

    public GameObject doll;

    public bool obstaclesRemoved = false;
    public bool chickenEaten = false;
    public bool dollShot = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameEndCheck();

    }

    public void GameEndCheck()
    {
        if (padlock.unlocked || plank.unlocked || cables.unlocked)
        {
            obstaclesRemoved = true;
        }

        if (chicken.chickenCounter == 0)
        {
            chickenEaten = true;
        }
        if (!doll.activeSelf)
        {
            dollShot = true;
        }
    }
}
