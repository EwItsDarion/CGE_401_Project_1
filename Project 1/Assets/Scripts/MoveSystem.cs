using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSystem : MonoBehaviour
{

    public GameManager gamemanager;
    public List<GameObject> moveIcons;
    // Start is called before the first frame update
    void Start()
    {
        ResetMoves();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < moveIcons.Count; ++i)
        {
            if (gamemanager.moves - 1 < i)
                moveIcons[i].SetActive(false);
        }
    }

    public void ResetMoves() { 
        for (int i = 0; i < moveIcons.Count; ++i)
        {
            moveIcons[i].SetActive(true);
        }
    }
}
