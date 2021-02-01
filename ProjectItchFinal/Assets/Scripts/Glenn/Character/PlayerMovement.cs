using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundedRayOrigin;
    [SerializeField] private float groundedRayDistance = .2f;
    private Rigidbody2D rb;
    
    private SpriteRenderer spriteRenderer;


    private float jumpTime = 1f; // how long it takes in seconds to charge the bar fully
    [SerializeField] private Image pogoChargeBar;
    [SerializeField] private float jumpForce;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private Vector2 jumpforceModifier = Vector2.one;
    public bool isGrounded;
    private float chargeValue; // value from 0 to 1


    //[SerializeField] private Image heart1, heart2, heart3;
    [SerializeField] private Image[] hearts;
    private int hp = 3;

    private float jumpPickupTimer = 10f;
    private bool jumpPickupIsPickedUp = false;

    public Collider2D PlayerCollider { get => playerCollider; }

    private float jumpRotationTimer = 1000f;
    private float myRotationValue = 0;

    private Animator animator;

    public bool isDead;

    public bool FacingRight
    {
        get
        {
            return !spriteRenderer.flipX;
        }
    }

    public int FacingDirection
    {
        get
        { 
            return spriteRenderer.flipX ? -2 : 2;
        }
    }

	private void Awake() {
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        isDead = false;
        animator = GetComponent<Animator>();

        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Debug.Log(rb.velocity.y);
        animator.SetBool("IsJumping", !isGrounded);

        Jump();

        if (jumpPickupIsPickedUp)
        {
            if (jumpPickupTimer <= 0)
            {
                ResetJumpPickupTimer();
            }
            else
            {
                jumpPickupTimer -= Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
        // dit is de grounded check die alleen wordt uitgevoerd als zijn velocity 0 of lager is
        if (rb.velocity.y <= 0) {
            Ray2D ray = new Ray2D(groundedRayOrigin.position, Vector2.down);
            RaycastHit2D[] raycastHits = Physics2D.RaycastAll(ray.origin, ray.direction, groundedRayDistance);
            for (int i = 0; i < raycastHits.Length; i++) {
                if (raycastHits[i].collider.tag == "Ground") {
                    isGrounded = true;
                    rb.velocity = Vector2.zero;
                    break;
                }
            }
        } else {
            isGrounded = false;
		}
       // Debug.Log(isGrounded);
    }


    private void Jump()
    {
        
        #region Jump
        // charge power whenever you hold down the space button
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("IsChargingJump", true);
            chargeValue = Mathf.Clamp01(chargeValue + Time.deltaTime / jumpTime); // charge jump and prevent value from exceeding 1
        }

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(20f * FacingDirection * chargeValue * jumpforceModifier.x, chargeValue * jumpForce * jumpforceModifier.y); // execute jump
            chargeValue = 0f; // reset charge
            //SoundManager.PlaySound("Jump_sound");
            SoundManager.PlaySound("Jump_sound");
        }
        pogoChargeBar.fillAmount = chargeValue;

        if (isGrounded == false)
        {
            animator.SetBool("IsChargingJump", false);
            animator.SetBool("IsJumping", true);


            if (rb.velocity.y >= 20)
            {
                animator.SetFloat("RotationY", rb.velocity.y);
               // PlayerRotatesInAir();
            }

            //PlayerRotatesInAir();
        }
        else if (isGrounded == true) //zodra hij op de grond staat
        {
            animator.SetBool("IsJumping", false);
            myRotationValue = 0; //myRotationValue wordt op 0 gezet
            transform.rotation = Quaternion.AngleAxis(myRotationValue, Vector3.back); //transform.rotation op de z as wordt hetzelfde als de myRotationValue, in dit geval is dat 0
            animator.SetFloat("RotationY", rb.velocity.y);
        }
        #endregion
    }
   

    public void TakeDamage()
    {
        UpdateHitpoints(-1);
        SoundManager.PlaySound("Hurt_Sound");
    }

    private void GetHP()
    {
        UpdateHitpoints(1);
        SoundManager.PlaySound("Health_pickup_sound");
    }

    private void UpdateHitpoints(int change) 
    {
        hp = Mathf.Clamp(hp + change, 0, 3); //hp gaat + de change en zit altijd tussen de 0 en de 3
        for (int i = 0; i < hearts.Length; i++) 
        {
            hearts[i].enabled = i < hp; //zet de harten aan
		}
        if (hp == 0) 
        {
            isDead = true;
            SoundManager.PlaySound("death_sound");

        }
    }

   
    private void GetJumpPickup()
    {
        jumpPickupIsPickedUp = true;
        jumpTime = 0.5f;
        jumpPickupTimer = 10f;
    }

    private void ResetJumpPickupTimer()
    {
        jumpPickupIsPickedUp = false;
        jumpTime = 1f;
        jumpPickupTimer = 10f;
    }
     
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeathCollider deathCollider = collision.GetComponent<DeathCollider>();
        if (deathCollider != null) {
            isDead = true;
		}

        if (collision.gameObject.tag == "HeartPickup")
        {
            GetHP();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "JumpPickup")
        {
            GetJumpPickup();
            Destroy(collision.gameObject);
        }

    }
    public void Dead()
    {
        isDead = true;
    }

}
