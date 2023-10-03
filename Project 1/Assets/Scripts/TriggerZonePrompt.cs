using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZonePrompt : MonoBehaviour
{
    // Start is called before the first frame update

    public bool inZone= false;
    public GameObject pressEPrompt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            inZone = true;
            pressEPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            inZone = false;
            pressEPrompt.SetActive(false);
        }
    }
}
