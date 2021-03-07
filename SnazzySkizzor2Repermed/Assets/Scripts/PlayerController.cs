using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int depth = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Input.mousePosition;

        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));

        Vector3 playerPosition = transform.position;
        /*if ((playerPosition.x + mousePos.x) < -5.29f)
        {
            wantedPos.x = -5.29f - playerPosition.x;
        }
        else if ((playerPosition.x + mousePos.x) > 4.42f)
        {
            wantedPos.x = 4.42f - playerPosition.x;
        }
        else
        {*/
            wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, depth));
        //}

       /*if ((playerPosition.y + mousePos.y) < -2.52f)
        {
            wantedPos.y = -2.52f - playerPosition.y;
        }
        else if ((playerPosition.y + mousePos.y) > 1.18f)
        {
            wantedPos.y = 1.18f - playerPosition.y;
        }
        else
        {*/
            wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, depth));
        //}

        transform.position = wantedPos;
        
    }
}
