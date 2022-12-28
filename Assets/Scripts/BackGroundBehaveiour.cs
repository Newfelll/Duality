using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundBehaveiour : MonoBehaviour
{
    public BoxCollider2D backgroundCollider;
    private PlatformEffector2D oneWayPlatform;

    public int count = 0;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
        oneWayPlatform = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
   /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (count < 1)
        {
            count++;
        }
        else
            StartCoroutine(MyCoroutine());
       
    }

    IEnumerator MyCoroutine()
    {
        //This is a coroutine
        
        backgroundCollider.enabled = false;

        yield return new WaitForSeconds(1);

        backgroundCollider.enabled = true;
        count = 0;
        
    }*/
}
