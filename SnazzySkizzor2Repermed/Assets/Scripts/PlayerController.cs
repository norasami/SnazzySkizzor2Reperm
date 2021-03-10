using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool skizzorTime;
    bool cuttingTime;
    bool cutHere_01;
    bool cutHere_02;
    bool cutHere_03;
    bool cutHere_04;
    bool cutLength_01;
    bool cutLength_02;
    bool cutLength_03;
    bool cutLength_04;
    bool combTime;
    bool combAvailable;
    bool styleTime;
    bool styleFromHere_01;
    bool styleFromHere_02;
    bool styleFromHere_03;
    bool styleFromHere_04;
    bool styleToHere_01;
    bool styleToHere_02;
    bool styleToHere_03;
    bool styleToHere_04;
    bool styleUp;
    bool styleLeft;
    bool styleRight;
    public int depth;
    Animator cursorAnim;
    Animator hairAnim;
    GameObject cutTrig_01;
    GameObject cutTrig_02;
    GameObject cutTrig_03;
    GameObject cutTrig_04;
    GameObject comb;
    GameObject styleTrig_01;
    GameObject styleTrig_02;
    GameObject styleTrig_03;
    GameObject styleTrig_04;
    Vector3 mouseDownPos;
    Vector3 mouseUpPos;
    void Start()
    {
        cursorAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        hairAnim = GameObject.FindWithTag("Hair").GetComponent<Animator>();

        cutTrig_01 = GameObject.FindWithTag("CutTrig_01");
        cutTrig_02 = GameObject.FindWithTag("CutTrig_02");
        cutTrig_03 = GameObject.FindWithTag("CutTrig_03");
        cutTrig_04 = GameObject.FindWithTag("CutTrig_04");
        cutTrig_01.GetComponent<BoxCollider2D>().enabled = false;
        cutTrig_02.GetComponent<BoxCollider2D>().enabled = false;
        cutTrig_03.GetComponent<BoxCollider2D>().enabled = false;
        cutTrig_04.GetComponent<BoxCollider2D>().enabled = false;

        comb = GameObject.FindWithTag("Comb");
        styleTrig_01 = GameObject.FindWithTag("StyleTrig_01");
        styleTrig_02 = GameObject.FindWithTag("StyleTrig_02");
        styleTrig_03 = GameObject.FindWithTag("StyleTrig_03");
        styleTrig_04 = GameObject.FindWithTag("StyleTrig_04");
        comb.GetComponent<SpriteRenderer>().enabled = false;
        comb.GetComponent<BoxCollider2D>().enabled = false;
        styleTrig_01.GetComponent<BoxCollider2D>().enabled = false;
        styleTrig_02.GetComponent<BoxCollider2D>().enabled = false;
        styleTrig_03.GetComponent<BoxCollider2D>().enabled = false;
        styleTrig_04.GetComponent<BoxCollider2D>().enabled = false;
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
            cutTrig_01.GetComponent<BoxCollider2D>().enabled = true;
            cutTrig_02.GetComponent<BoxCollider2D>().enabled = true;
            cutTrig_03.GetComponent<BoxCollider2D>().enabled = true;
            cutTrig_04.GetComponent<BoxCollider2D>().enabled = true;
            cuttingTime = true;
        }

        if (combAvailable == true)
        {
            comb.GetComponent<SpriteRenderer>().enabled = true;
            comb.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (styleTime == true && cutLength_01 == true)
        {
            styleTrig_01.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (styleTime == true && cutLength_02 == true)
        {
            styleTrig_02.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (styleTime == true && cutLength_03 == true)
        {
            styleTrig_03.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (styleTime == true && cutLength_04 == true)
        {
            styleTrig_04.GetComponent<BoxCollider2D>().enabled = true;
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
            cutHere_01 = true;
        }
        else
        {
            cutHere_01 = false;
        }

        if (other.CompareTag("CutTrig_02"))
        {
            cutHere_02 = true;
        }
        else
        {
            cutHere_02 = false;
        }

        if (other.CompareTag("CutTrig_03"))
        {
            cutHere_03 = true;
        }
        else
        {
            cutHere_03 = false;
        }

        if (other.CompareTag("CutTrig_04"))
        {
            cutHere_04 = true;
        }
        else
        {
            cutHere_04 = false;
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
            styleFromHere_01 = true;
        }
        else
        {
            styleFromHere_01 = false;
        }

        if (other.CompareTag("StyleTrig_02"))
        {
            styleFromHere_02 = true;
        }
        else
        {
            styleFromHere_02 = false;
        }

        if (other.CompareTag("StyleTrig_03"))
        {
            styleFromHere_03 = true;
        }
        else
        {
            styleFromHere_03 = false;
        }

        if (other.CompareTag("StyleTrig_04"))
        {
            styleFromHere_04 = true;
        }
        else
        {
            styleFromHere_04 = false;
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

        if(cutHere_01 == true)
        {
            hairAnim.SetTrigger("CutPoint1");
            cutLength_01 = true;
        }
        else
        {
            cutLength_01 = false;
        }

        if (cutHere_02 == true)
        {
            hairAnim.SetTrigger("CutPoint2");
            cutLength_02 = true;
        }
        else
        {
            cutLength_02 = false;
        }

        if (cutHere_03 == true)
        {
            hairAnim.SetTrigger("CutPoint3");
            cutLength_03 = true;
        }
        else
        {
            cutLength_03 = false;
        }

        if (cutHere_04 == true)
        {
            hairAnim.SetTrigger("CutPoint4");
            cutLength_04 = true;
        }
        else
        {
            cutLength_04 = false;
        }

        if (combTime == true)
        {
            cursorAnim.SetTrigger("combTime");
            styleTime = true;
        }

        if (styleFromHere_01 == true)
        {
            styleToHere_01 = true;
        }
        else
        {
            styleToHere_01 = false;
        }

        if (styleFromHere_02 == true)
        {
            styleToHere_02 = true;
        }
        else
        {
            styleToHere_02 = false;
        }

        if (styleFromHere_03 == true)
        {
            styleToHere_03 = true;
        }
        else
        {
            styleToHere_03 = false;
        }

        if (styleFromHere_04 == true)
        {
            styleToHere_04 = true;
        }
        else
        {
            styleToHere_04 = false;
        }
    }

    void OnMouseUp()
    {
        mouseUpPos = Input.mousePosition;

        if (styleToHere_01 == true && styleLeft == true)
        {
            Debug.Log("Hairstyle1");
        }
        else if (styleToHere_01 == true && styleUp == true)
        {
            Debug.Log("Hairstyle2");
        }
        else if (styleToHere_01 == true && styleRight == true)
        {
            Debug.Log("Hairstyle3");
        }
        else if (styleToHere_02 == true && styleLeft == true)
        {
            Debug.Log("Hairstyle4");
        }
        else if (styleToHere_02 == true && styleUp == true)
        {
            Debug.Log("Hairstyle5");
        }
        else if (styleToHere_02 == true && styleRight == true)
        {
            Debug.Log("Hairstyle6");
        }
        else if (styleToHere_03 == true && styleLeft == true)
        {
            Debug.Log("Hairstyle7");
        }
        else if (styleToHere_03 == true && styleUp == true)
        {
            Debug.Log("Hairstyle8");
        }
        else if (styleToHere_03 == true && styleRight == true)
        {
            Debug.Log("Hairstyle9");
        }
        else if (styleToHere_04 == true && styleLeft == true)
        {
            Debug.Log("Hairstyle10");
        }
        else if (styleToHere_04 == true && styleUp == true)
        {
            Debug.Log("Hairstyle11");
        }
        else if (styleToHere_04 == true && styleRight == true)
        {
            Debug.Log("Hairstyle12");
        }
    }
}
