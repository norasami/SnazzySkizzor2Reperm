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
    public int depth;
    Animator cursorAnim;
    Animator hairAnim;
    GameObject cutTrig_01;
    GameObject cutTrig_02;
    GameObject cutTrig_03;
    GameObject cutTrig_04;
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
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Input.mousePosition;

        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
        
        transform.position = wantedPos;

        //transform.rotation = Quaternion.LookRotation(mousePos, wantedPos);

        if (skizzorTime == true)
        {
            cutTrig_01.GetComponent<BoxCollider2D>().enabled = true;
            cutTrig_02.GetComponent<BoxCollider2D>().enabled = true;
            cutTrig_03.GetComponent<BoxCollider2D>().enabled = true;
            cutTrig_04.GetComponent<BoxCollider2D>().enabled = true;
            cuttingTime = true;
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

        if(other.CompareTag("CutTrig_01"))
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
    }

    void OnMouseDown()
    {
        if(skizzorTime == true)
        {
            cursorAnim.SetTrigger("skizzorTime");
            hairAnim.SetTrigger("Haircut");
        }

        if(cuttingTime == true)
        {
            cursorAnim.SetTrigger("cutHere");
        }

        if(cutHere_01 == true)
        {
            hairAnim.SetTrigger("CutPoint1");
        }

        if (cutHere_02 == true)
        {
            hairAnim.SetTrigger("CutPoint2");
        }

        if (cutHere_03 == true)
        {
            hairAnim.SetTrigger("CutPoint3");
        }

        if (cutHere_04 == true)
        {
            hairAnim.SetTrigger("CutPoint4");
        }
    }
}
