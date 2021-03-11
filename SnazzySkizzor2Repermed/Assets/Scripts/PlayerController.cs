using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool skizzorTime;
    bool cuttingTime;
    bool[] cutHere;
    bool[] cutLength;
    bool combTime;
    bool combAvailable;
    bool styleTime;
    bool[] styleFromHere;
    bool[] styleToHere;
    bool styleUp;
    bool styleLeft;
    bool styleRight;
    public int depth;
    Animator cursorAnim;
    Animator hairAnim;
    public GameObject[] cutTrigs;
    GameObject comb;
    public GameObject[] styleTrigs;
    Vector3 mouseDownPos;
    Vector3 mouseUpPos;
    void Start()
    {
        cursorAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        hairAnim = GameObject.FindWithTag("Hair").GetComponent<Animator>();

        cutHere = new bool[4];
        cutLength = new bool[4];
        styleFromHere = new bool[4];
        styleToHere = new bool[4];

        foreach (GameObject cutTrig in cutTrigs)
        {
            cutTrig.GetComponent<BoxCollider2D>().enabled = false;
        }
        
        comb = GameObject.FindWithTag("Comb");
        comb.GetComponent<SpriteRenderer>().enabled = false;
        comb.GetComponent<BoxCollider2D>().enabled = false;
        foreach (GameObject styleTrig in styleTrigs)
        {
            styleTrig.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
        transform.position = wantedPos;

        Vector3 dragDistance = mouseUpPos - mouseDownPos;
        if (dragDistance.y > 0 && Mathf.Abs(dragDistance.y) > Mathf.Abs(dragDistance.x))
        {
            styleUp = true;
        }
        else if (dragDistance.x < 0 && Mathf.Abs(dragDistance.y) < Mathf.Abs(dragDistance.x))
        {
            styleLeft = true;
        }
        else if (dragDistance.x > 0 && Mathf.Abs(dragDistance.y) < Mathf.Abs(dragDistance.x))
        {
            styleRight = true;
        }

        if (skizzorTime == true)
        {
            foreach (GameObject cutTrig in cutTrigs)
            {
                cutTrig.GetComponent<BoxCollider2D>().enabled = true;
            }
            cuttingTime = true;
        }

        if (combAvailable == true)
        {
            comb.GetComponent<SpriteRenderer>().enabled = true;
            comb.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (styleTime == true)
        {
            for (int i = 0; i < cutLength.Length; i++)
            {
                if (cutLength[i] == true)
                {
                    styleTrigs[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Skizzors"))
        {
            skizzorTime = true;
        }
        else
        {
            skizzorTime = false;
        }

        if (other.CompareTag("CutTrig_01"))
        {
            cutHere[0] = true;
        }
        else
        {
            cutHere[0] = false;
        }

        if (other.CompareTag("CutTrig_02"))
        {
            cutHere[1] = true;
        }
        else
        {
            cutHere[1] = false;
        }

        if (other.CompareTag("CutTrig_03"))
        {
            cutHere[2] = true;
        }
        else
        {
            cutHere[2] = false;
        }

        if (other.CompareTag("CutTrig_04"))
        {
            cutHere[3] = true;
        }
        else
        {
            cutHere[3] = false;
        }

        if (other.CompareTag("Comb"))
        {
            combTime = true;
        }
        else
        {
            combTime = false;
        }

        if (other.CompareTag("StyleTrig_01"))
        {
            styleFromHere[0] = true;
        }
        else
        {
            styleFromHere[0] = false;
        }

        if (other.CompareTag("StyleTrig_02"))
        {
            styleFromHere[1] = true;
        }
        else
        {
            styleFromHere[1] = false;
        }

        if (other.CompareTag("StyleTrig_03"))
        {
            styleFromHere[2] = true;
        }
        else
        {
            styleFromHere[2] = false;
        }

        if (other.CompareTag("StyleTrig_04"))
        {
            styleFromHere[3] = true;
        }
        else
        {
            styleFromHere[3] = false;
        }
    }

    void OnMouseDown()
    {
        mouseDownPos = Input.mousePosition;
        
        if(skizzorTime == true)
        {
            cursorAnim.SetTrigger("skizzorTime");
            hairAnim.SetTrigger("Haircut");
            combAvailable = true;
        }

        if(cuttingTime == true)
        {
            cursorAnim.SetTrigger("cutHere");
        }

        if(cutHere[0] == true)
        {
            hairAnim.SetTrigger("CutPoint1");
            cutLength[0] = true;
        }
        else
        {
            cutLength[0] = false;
        }

        if (cutHere[1] == true)
        {
            hairAnim.SetTrigger("CutPoint2");
            cutLength[1] = true;
        }
        else
        {
            cutLength[1] = false;
        }

        if (cutHere[2] == true)
        {
            hairAnim.SetTrigger("CutPoint3");
            cutLength[2] = true;
        }
        else
        {
            cutLength[2] = false;
        }

        if (cutHere[3] == true)
        {
            hairAnim.SetTrigger("CutPoint4");
            cutLength[3] = true;
        }
        else
        {
            cutLength[3] = false;
        }

        if (combTime == true)
        {
            cursorAnim.SetTrigger("combTime");
            styleTime = true;
        }

        for (int i = 0; i < styleFromHere.Length; i++)
        {
            if (styleFromHere[i] == true)
            {
                styleToHere[i] = true;
            }
            else
            {
                styleToHere[i] = false;
            }
        }
    }

    void OnMouseUp()
    {
        mouseUpPos = Input.mousePosition;

        if (styleToHere[0] == true && styleLeft == true)
        {
            Debug.Log("Hairstyle1");
        }
        else if (styleToHere[0] == true && styleUp == true)
        {
            Debug.Log("Hairstyle2");
        }
        else if (styleToHere[0] == true && styleRight == true)
        {
            Debug.Log("Hairstyle3");
        }
        else if (styleToHere[1] == true && styleLeft == true)
        {
            Debug.Log("Hairstyle4");
        }
        else if (styleToHere[1] == true && styleUp == true)
        {
            Debug.Log("Hairstyle5");
        }
        else if (styleToHere[1] == true && styleRight == true)
        {
            Debug.Log("Hairstyle6");
        }
        else if (styleToHere[2] == true && styleLeft == true)
        {
            Debug.Log("Hairstyle7");
        }
        else if (styleToHere[2] == true && styleUp == true)
        {
            Debug.Log("Hairstyle8");
        }
        else if (styleToHere[2] == true && styleRight == true)
        {
            Debug.Log("Hairstyle9");
        }
        else if (styleToHere[3] == true && styleLeft == true)
        {
            Debug.Log("Hairstyle10");
        }
        else if (styleToHere[3] == true && styleUp == true)
        {
            Debug.Log("Hairstyle11");
        }
        else if (styleToHere[3] == true && styleRight == true)
        {
            Debug.Log("Hairstyle12");
        }
    }
}
