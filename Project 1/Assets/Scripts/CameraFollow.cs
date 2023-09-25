using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, -9);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position + offset;
    }
}
