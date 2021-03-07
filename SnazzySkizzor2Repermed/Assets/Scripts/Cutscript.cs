using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscript : MonoBehaviour
{
    public bool cuttingTime;
    public Animator cutAnim;
    void Start()
    {
        cutAnim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cuttingTime = true;

        }
    }
}


