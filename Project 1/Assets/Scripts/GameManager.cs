﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public GameObject skillCheck;

    public TriggerZonePrompt zonePrompt;


   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zonePrompt.inZone && Input.GetKeyDown(KeyCode.E)) {
            skillCheck.SetActive(true);
        }
    }
}
