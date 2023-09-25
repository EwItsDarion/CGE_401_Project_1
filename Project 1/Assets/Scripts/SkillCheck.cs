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
        if (bar.transform.localPosition.y >= 0.15f)
        {
            goingUp = false;
        }
        else if (bar.transform.localPosition.y <= -0.15f) {
            goingUp = true;
        }

        if (goingUp && !stopped) {
            bar.transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (!goingUp && !stopped) { 
            bar.transform.Translate(Vector2.down * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            stopped = true;
        }
    }
}
