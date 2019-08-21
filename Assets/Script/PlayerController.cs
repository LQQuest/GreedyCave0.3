using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private Animator anim;
    private GameMaster gm;

    public static int hp = 6;
    public static bool gameOver = false;
    public static bool gameFinish = false;
    public static int nextscore = 0;

    public float KnockbackCount = 0;
    public float KnockbackLenght;
    // public float knockbackX;
    // public float knockbackY;

    public bool IFrame = false;

    
    public GameObject LoadScreen;
    public GameObject FinishUI;

    void Start()
    {
        extraJumps = extraJumpsValue;
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }

    private void FixedUpdate() {
        if (gameFinish == false && gameOver == false && SpawnRooms.stopSpawnRoom == true)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            anim.SetBool("Ground", isGrounded);

            anim.SetFloat("vSpeed", rb.velocity.y);
            moveInput = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            if (KnockbackCount <= 0 )
            {   
                IFrame = false;
                
            }else{          
                IFrame = true;
                KnockbackCount -= Time.deltaTime;
            }
            

            if (facingRight == false && moveInput > 0){
                Flip();
            } else if(facingRight == true && moveInput < 0){
                Flip();
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

       
    }
    
    void Update()
    {      

        if(hp == 0)
        {
            gameOver = true;
            anim.SetTrigger("Dead");
            rb.velocity = Vector2.right * 0f;
            nextscore = 0;
        }
        // Debug.Log("Groung "+ isGrounded);
        if (gameFinish == false && gameOver == false && SpawnRooms.stopSpawnRoom == true)
        {
            LoadScreen.SetActive(false);
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
        
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            gm.score += 20;
        }
        if (other.gameObject.tag == "Gem")
        {
            gm.score += 100;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "door")
        {
            nextscore = gm.score;
            Debug.Log("Score "+ nextscore);
            rb.velocity = Vector2.right * 0f;
            anim.SetTrigger("Win");
            FinishUI.SetActive(true);
            gameFinish = true;
        }
        if(other.gameObject.tag == "Eat")
        {
            hp ++;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Spike" && IFrame == false)
        {   
            
            hp--;
            KnockbackCount = KnockbackLenght;
            gameObject.GetComponent<Animation>().Play("DamageBurst");
        }
        
    }
    
}
