using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomePlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool facingRight = true;

    private int extraJumps;
    public int extraJumpsValue;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;
    private GameMaster gm;
    private Rigidbody2D rb;
    public GameObject dm;
    public GameObject loadScreen;

    public GameObject target;
    private bool eventPosition;
    private bool eventMove;

    void Start()
    {
        extraJumps = extraJumpsValue;
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        GameMaster.scene = 2;
        Destroy(loadScreen,2f);
        gm.SavePlayer();
        eventPosition = true;
        eventMove = false;

    }

    private void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rb.velocity.y);

        if (eventMove == true)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
            if (facingRight == false && moveInput > 0){
                Flip();
            } else if(facingRight == true && moveInput < 0){
                Flip();
            }
        }
        
        
        
        if(!isGrounded)
            return;

        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else{
            anim.SetBool("isRunning", true);
        }
    }

    

    void Update()
    {   
        if (transform.position != target.transform.position && eventPosition == true)
        {
            float step = 0.7f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            anim.SetBool("isRunning", true); 
            
        }else if (transform.position == target.transform.position)
        {
            eventPosition = false;
            eventMove = true;
            
        }
        
        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("Ground", false);
        }  
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "altar")
        {
            dm.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
