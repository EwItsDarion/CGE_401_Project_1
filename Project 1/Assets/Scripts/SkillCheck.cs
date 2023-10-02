﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCheck : MonoBehaviour
{
   // public GameObject bar;
    public Image bar;
    public bool goingUp = true;
    public bool stopped = false;
    public float speed = 1;
    public Zone stopZone;

    public enum Zone { 
        Great,
        Good,
        Bad,
        none
    }
    // Start is called before the first frame update
    void Start()
    {
        stopZone = Zone.none;

    }

    // Update is called once per frame
    void Update()
    {

        //set upper limit of bar
        if (bar.transform.localPosition.y >= 50f)
        {
            goingUp = false;
        }

        //set lower limit of bar
        else if (bar.transform.localPosition.y <= -50f) { //NOTE: localPosition is using the transform of the bar relative to the transform of the zones
            goingUp = true;
        }

        //send bar up zones sprite
        if (goingUp && !stopped) {
            bar.transform.Translate(Vector2.up * Time.deltaTime * speed);
        }

        //send bar down zones sprite
        if (!goingUp && !stopped) { 
            bar.transform.Translate(Vector2.down *Time.deltaTime * speed);
        }

        //space to stop the bar
        if (Input.GetKeyDown(KeyCode.Space)) {
            stopped = true;
            onStop();
        }
    }

    public void onStop() {
        if ((bar.transform.localPosition.y < -16.5 || bar.transform.localPosition.y > 16.5) ) {
            stopZone = Zone.Bad;
            Console.WriteLine("bad");
        }
        else if ((bar.transform.localPosition.y > -16.5 || bar.transform.localPosition.y < 16.5) && ((bar.transform.localPosition.y > 4 || bar.transform.localPosition.y < -4))) {
            stopZone = Zone.Good;
            Console.WriteLine("good");
        }
        else if (bar.transform.localPosition.y < 4 || bar.transform.localPosition.y > -4) {
            stopZone = Zone.Great;
            Console.WriteLine("great");
        }
    }


}



/* Converted Zones
 * lower bad zone -50 to -16.5
 * upper bad zone 16.5 to 50
 * lower good -16.5 to -4
 * upper good zone 4 to 16.5
 * great zone -4 to 4
 */