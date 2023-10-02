using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZonePrompt : MonoBehaviour
{
    // Start is called before the first frame update

    public bool inZone= false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone) {
            print("InZone");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            inZone = false;
        }
    }
}
