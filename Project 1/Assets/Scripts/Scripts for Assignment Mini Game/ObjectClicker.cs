using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        
         if(Input.GetMouseButtonDown(0)&&(((AssignmentMiniGameManager.levelOfDifficulty==1&&(AssignmentMiniGameManager.canClick))||AssignmentMiniGameManager.levelOfDifficulty>1)))
        {
            AssignmentMiniGameManager.successfulHits++;
            AssignmentMiniGameManager.assignmentsRemaining--;
            Destroy(gameObject);
        }
    }
}
