using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    private SpriteRenderer bubbleSprite;
    private Vector4 krem = new Vector4(1f, 0.8980392f, 0.8f, 1f);
    private Vector4 siyah = new Vector4(0.1294118f, 0.1254902f, 0.1254902f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        bubbleSprite = GetComponent<SpriteRenderer>();
        if (transform.position.y < 0)
        {
            bubbleSprite.color = siyah;
        }
        else { bubbleSprite.color = krem;  }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

    
       
    }
}
