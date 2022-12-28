using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{
    [Header("Components")]
   // private SpriteRenderer playerSprite;
    private Rigidbody2D playerRb;
    private CircleCollider2D boxCollider;
    public GameObject background;
    private BoxCollider2D back;
    private AudioSource audioSource;
    public Animator SquashAndStretchAnimator;
    public SpriteRenderer playerSprite;
    public PlatformEffector2D oneWayPlatform;

    RaycastHit2D raycastHit2d;
    [SerializeField] private LayerMask ground;
    private Vector4 krem = new Vector4(1f, 0.8980392f, 0.8f, 1f);
    private Vector4 siyah = new Vector4(0.1294118f, 0.1254902f, 0.1254902f, 1f);


    

    [Header("Player properties")]
    [SerializeField] private bool isUp = true;
    [SerializeField] private bool Jump = false;
    [SerializeField] private float divider = 3;
    [SerializeField] private AudioClip transition;
    [SerializeField] private float jumpVelocity = 10f;
    [SerializeField] private float jumpy = 10f;
    [SerializeField] private float raycastDistance = 0.5f;
    [SerializeField] private bool isFalan=true;
    [SerializeField] private int health = 3;
   


    Touch touch;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
      
        boxCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();

        
       
        back = background.GetComponent<BoxCollider2D>();

        

        Color krem = new Color(1f, 0.8980392f, 0.8f, 1f);
        Color siyah = new Color(0.1294118f, 0.1254902f, 0.1254902f, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)||Input.touchCount>0) && IsGrounded())
        {
            back.enabled = false;

             if (oneWayPlatform.rotationalOffset == 180)
             {
                 oneWayPlatform.rotationalOffset = 0;
             }
             else oneWayPlatform.rotationalOffset = 180;
            
            Jump = true;
            

        }

        
        if (touch.phase==TouchPhase.Ended)
        {
            playerRb.velocity = playerRb.velocity / divider;
        }


        if (Input.GetMouseButtonUp(0) )
        {

            playerRb.velocity = playerRb.velocity / divider;

        }

        

        if (transform.position.y < -0.5 && isFalan)
        {
            
                
                ChangeGravity();
                playerSprite.color = siyah;
                isUp = false;
            
            
            
        }
        else if (transform.position.y>0.5 && !isFalan)
        {
            
            ChangeGravity();
            playerSprite.color = krem; isUp = true;
        }



    }




    private void FixedUpdate()
    {
        if (Jump)
        {
            DoJump();
            Jump = false;
        }
    }



    void DoJump()
    {   
        SquashAndStretchAnimator.SetTrigger("Jump");
       
        
        if (isUp)
        {
            
         
            audioSource.Play();
            playerRb.velocity = Vector2.up * jumpVelocity;
        }
        else {  audioSource.Play(); ; playerRb.velocity = Vector2.down * jumpVelocity;  }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sound"))
        {
            audioSource.PlayOneShot(transition);
        }
       

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {

            Debug.Log(collision.transform.position.y - transform.position.y);
            if (Mathf.Abs(collision.transform.position.y - transform.position.y) > 0.80)
            {

                SquashAndStretchAnimator.SetTrigger("Jump");
                if (transform.position.y > 0)
                {

                    playerRb.AddForce(Vector2.up * jumpy, ForceMode2D.Force);
                }
                else { playerRb.AddForce(Vector2.down * jumpy, ForceMode2D.Force); }
            }
            else FindObjectOfType<GameManager>().GameOver();
           

        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
           
            SquashAndStretchAnimator.SetTrigger("Landing");
        }
        
    }
    private bool IsGrounded()
    {
        if (isUp)
        {
           
            raycastHit2d = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, raycastDistance, ground);
            
        }
        else { raycastHit2d = Physics2D.Raycast(boxCollider.bounds.center, Vector2.up, raycastDistance, ground); }


        
        return raycastHit2d.collider != null;
    }
    

    void ChangeGravity()
    {
        if (transform.rotation.z == 0)
        {
            back.enabled = true;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else { back.enabled = true; transform.eulerAngles = new Vector3(0, 0, 0); }
        
        isFalan = !isFalan;
        playerRb.velocity = playerRb.velocity / divider;
        playerRb.gravityScale *= -1;
    }

    

    
}
