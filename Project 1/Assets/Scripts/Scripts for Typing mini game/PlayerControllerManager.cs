using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerManager : MonoBehaviour
{
    bool keyHasBeenPressed;
    private GameObject letter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Letter"))
        {
            //if matcher collides with a letter and the player types the letter, destroy the letter
            if (other.gameObject.name == "Letter A(Clone)")
            {
                if (Input.GetKey(KeyCode.A))
                {
                    Destroy(other.gameObject);
                    Debug.Log("Hit");
                }

            }
            if (other.gameObject.name == "Letter B(Clone)")
            {
                if (Input.GetKey(KeyCode.B))
                {
                    Destroy(other.gameObject);
                    Debug.Log("Hit");
                }
            }

            if (other.gameObject.name == "Letter D(Clone)")
            {
                if (Input.GetKey(KeyCode.D))
                {
                    Destroy(other.gameObject);
                    Debug.Log("Hit");
                }
            }
        }
    }
    }


