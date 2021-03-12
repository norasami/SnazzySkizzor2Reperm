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
    bool[] styleFromHere;
    bool[] styleToHere;
    bool[] styleDirection;
    public int depth;
    Animator cursorAnim;
    Animator hairAnim;
    public GameObject[] cutTrigs;
    GameObject comb;
    public GameObject[] styleTrigs;
    Vector3 mouseDownPos;
    Vector3 mouseUpPos;
    Vector3 dragDistance;
    void Start()
    {
        cursorAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        hairAnim = GameObject.FindWithTag("Hair").GetComponent<Animator>();

        cutHere = new bool[4];
        cutLength = new bool[4];
        styleFromHere = new bool[4];
        styleToHere = new bool[4];
        styleDirection = new bool[3];

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Skizzors"))
        {
            skizzorTime = true;
        }
        else if (other.CompareTag("CutTrig_01"))
        {
            cutHere[0] = true;
        }
        else if (other.CompareTag("CutTrig_02"))
        {
            cutHere[1] = true;
        }
        else if (other.CompareTag("CutTrig_03"))
        {
            cutHere[2] = true;
        }
        else if (other.CompareTag("CutTrig_04"))
        {
            cutHere[3] = true;
        }
        else if (other.CompareTag("Comb"))
        {
            combTime = true;
        }
        else if (other.CompareTag("StyleTrig_01"))
        {
            styleFromHere[0] = true;
        }
        else if (other.CompareTag("StyleTrig_02"))
        {
            styleFromHere[1] = true;
        }
        else if (other.CompareTag("StyleTrig_03"))
        {
            styleFromHere[2] = true;
        }
        else if (other.CompareTag("StyleTrig_04"))
        {
            styleFromHere[3] = true;
        }
        else
        {
            skizzorTime = false;
            for (int i = 0; i < cutHere.Length; i++)
            {
                cutHere[i] = false;
            }
            combTime = false;
            for (int i = 0; i < styleFromHere.Length; i++)
            {
                styleFromHere[i] = false;
            }
        }
    }

    void OnMouseDown()
    {
        mouseDownPos = Input.mousePosition;

        if (skizzorTime == true)
        {
            cursorAnim.SetTrigger("skizzorTime");
            hairAnim.SetTrigger("Haircut");
            comb.GetComponent<SpriteRenderer>().enabled = true;
            comb.GetComponent<BoxCollider2D>().enabled = true;
            foreach (GameObject cutTrig in cutTrigs)
            {
                cutTrig.GetComponent<BoxCollider2D>().enabled = true;
            }
            cuttingTime = true;
        }

        if (cuttingTime == true)
        {
            cursorAnim.SetTrigger("cutHere");
        }

        if (cutHere[0] == true)
        {
            hairAnim.SetTrigger("CutPoint1");
            cutLength[0] = true;
        }
        else if (cutHere[1] == true)
        {
            hairAnim.SetTrigger("CutPoint2");
            cutLength[1] = true;
        }
        else if (cutHere[2] == true)
        {
            hairAnim.SetTrigger("CutPoint3");
            cutLength[2] = true;
        }
        else if (cutHere[3] == true)
        {
            hairAnim.SetTrigger("CutPoint4");
            cutLength[3] = true;
        }
        else
        {
            for (int i = 0; i < cutLength.Length; i++)
            {
                cutLength[i] = false;
            }
        }

        if (combTime == true)
        {
            cursorAnim.SetTrigger("combTime");
            for (int i = 0; i < cutLength.Length; i++)
            {
                if (cutLength[i] == true)
                {
                    styleTrigs[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
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
        dragDistance = mouseUpPos - mouseDownPos;
        if (dragDistance.y > 0 && Mathf.Abs(dragDistance.y) > Mathf.Abs(dragDistance.x))
        {
            styleDirection[0] = true;
        }
        else if (dragDistance.x < 0 && Mathf.Abs(dragDistance.y) < Mathf.Abs(dragDistance.x))
        {
            styleDirection[1] = true;
        }
        else if (dragDistance.x > 0 && Mathf.Abs(dragDistance.y) < Mathf.Abs(dragDistance.x))
        {
            styleDirection[2] = true;
        }
        else
        {
            for (int i = 0; i < styleDirection.Length; i++)
            {
                styleDirection[i] = false;
            }
        }

        if (styleToHere[0] == true && styleDirection[1] == true)
        {
            hairAnim.SetTrigger("Hairstyle1");
            Debug.Log("Hairstyle1");
        }
        else if (styleToHere[0] == true && styleDirection[0] == true)
        {
            hairAnim.SetTrigger("Hairstyle2");
            Debug.Log("Hairstyle2");
        }
        else if (styleToHere[0] == true && styleDirection[2] == true)
        {
            hairAnim.SetTrigger("Hairstyle3");
            Debug.Log("Hairstyle3");
        }
        else if (styleToHere[1] == true && styleDirection[1] == true)
        {
            hairAnim.SetTrigger("Hairstyle4");
            Debug.Log("Hairstyle4");
        }
        else if (styleToHere[1] == true && styleDirection[0] == true)
        {
            hairAnim.SetTrigger("Hairstyle5");
            Debug.Log("Hairstyle5");
        }
        else if (styleToHere[1] == true && styleDirection[2] == true)
        {
            hairAnim.SetTrigger("Hairstyle6");
            Debug.Log("Hairstyle6");
        }
        else if (styleToHere[2] == true && styleDirection[1] == true)
        {
            hairAnim.SetTrigger("Hairstyle7");
            Debug.Log("Hairstyle7");
        }
        else if (styleToHere[2] == true && styleDirection[0] == true)
        {
            hairAnim.SetTrigger("Hairstyle8");
            Debug.Log("Hairstyle8");
        }
        else if (styleToHere[2] == true && styleDirection[2] == true)
        {
            Debug.Log("Hairstyle9");
        }
        else if (styleToHere[3] == true && styleDirection[1] == true)
        {
            Debug.Log("Hairstyle10");
        }
        else if (styleToHere[3] == true && styleDirection[0] == true)
        {
            Debug.Log("Hairstyle11");
        }
        else if (styleToHere[3] == true && styleDirection[2] == true)
        {
            Debug.Log("Hairstyle12");
        }
    }
}
