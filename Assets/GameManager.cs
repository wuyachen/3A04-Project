﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int Health;
    int Food;
    int Day;
    int Money;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        Food = 100;
        Day = 1;
        Money = 0;

        Debug.Log(Health);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
