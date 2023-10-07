/*Julian Avila
 * Project 1
 * Allows pencil to follow mouse
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilFollowMouse : MonoBehaviour
{
    Vector3 cursorPosition;
    Vector3 rotatePosition;
    public float speed = 3f;
    // Update is called once per frame
    void Update()
    {
        cursorPosition = Input.mousePosition;
       cursorPosition.z = speed;
       transform.position = Camera.main.ScreenToWorldPoint(cursorPosition);
        rotatePosition = new Vector3(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y);
        transform.right = rotatePosition;

    }


}
