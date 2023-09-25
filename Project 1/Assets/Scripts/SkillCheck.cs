using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    public GameObject bar;
    public bool goingUp = true;
    public bool stopped = false;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        //set upper limit of bar
        if (bar.transform.localPosition.y >= 0.15f)
        {
            goingUp = false;
        }

        //set lower limit of bar
        else if (bar.transform.localPosition.y <= -0.15f) { //NOTE: localPosition is using the transform of the bar relative to the transform of the zones
            goingUp = true;
        }

        //send bar up zones sprite
        if (goingUp && !stopped) {
            bar.transform.Translate(Vector2.up * Time.deltaTime * speed);
        }

        //send bar down zones sprite
        if (!goingUp && !stopped) { 
            bar.transform.Translate(Vector2.down * Time.deltaTime * speed);
        }

        //space to stop the bar
        if (Input.GetKeyDown(KeyCode.Space)) {
            stopped = true;
        }
    }
}
