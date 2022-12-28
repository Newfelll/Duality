using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject otherTrigger;
    private BoxCollider2D coll;
    private BoxCollider2D thisc;

    // Start is called before the first frame update
    void Start()
    {
        coll = otherTrigger.GetComponent<BoxCollider2D>();
        thisc =GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            coll.enabled = true;
            thisc.enabled = false;
        }


    }
}
