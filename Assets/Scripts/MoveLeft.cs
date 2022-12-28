using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private static float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed + Time.deltaTime;
        if (transform.position.x < -25.51f)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }





    
}
