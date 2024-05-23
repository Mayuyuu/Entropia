using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    //------------------------------------------------------Déplacements Player
    [SerializeField] private float JumpForce; //Gm

    [SerializeField] private float GroundCheckWidth;
    [SerializeField] private float GroundCheckHeight;

    [SerializeField] private LayerMask JumpLayerMask;

    [SerializeField] private LayerMask GroundLayerMask;

    [SerializeField] private float FallGravityScaleMultiplier = 1f;
    [SerializeField] private float CoyoteTime; //gm
    [SerializeField] private float GroundCheckOffsetY;

    [SerializeField] private Transform Inclinsaison;

    [SerializeField] private Animator dressAnim;
    [SerializeField] private Animator headAnim;

    Vector2 checkpointpos;

    private Rigidbody2D RbPlayer;
    private float HorizontalInput;
    private Vector2 GroundCheckPosition;
    private float GravityScale;
    [SerializeField] private bool isAlive;
    private SpriteRenderer sr;

    Vector2 startPos;

    //------------------------------------------------------ANIMATOR
   private Animator animator;


    //ajout video
    // public bool isOnPlatform;
    // public Rigidbody2D platformRb;
    [SerializeField] int speed;
    float speedMultiplier;
    Vector2 relativeTransform;

    Vector2 zeroVelocity = Vector2.zero;
    Quaternion zeroRotation = Quaternion.identity;


    // public delegate void SpawnPlayer();
    // public SpawnPlayer OnPlayerSpawn;



    //--------------------------------------------------------- Dash
    /*[SerializeField] private TrailRenderer tr;
    [SerializeField] private float TimeInSecToRefill;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private int DashStock;*/

    // Start is called before the first frame update
    void Start()
    {
        RbPlayer = GetComponent<Rigidbody2D>();
        GravityScale = RbPlayer.gravityScale;
        isAlive = true;
        startPos = transform.position;
        animator = GetComponent<Animator>();
        
        //PlayerSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGroundCheckOffset();
        HorizontalInput = Input.GetAxisRaw("Horizontal");

        Collider2D col = Physics2D.OverlapBox(GroundCheckPosition, new Vector2(GroundCheckWidth, GroundCheckHeight), 0, JumpLayerMask); //Overlap -> boite fictive qui permets de check si le player est en collision avec le sol ou pas pour le faire sauter
        // isGrounded = (col != null); //If statement plus court
        if (col != null)
        {
            //Sol sous les pieds
            GameManager.Instance.setIsGrounded(true);
        }
        else if (GameManager.Instance.getIsGrounded())
        {
            //En l'air mais a sauté donc sol sous les pieds
            StartCoroutine(UpdateisGroundedState(false)); //Assynchrone
        }

        if (Input.GetButton("Jump") && GameManager.Instance.getIsGrounded())
        {
            GameManager.Instance.setIsJumping(true);
        }
        else
        {
            GameManager.Instance.setIsJumping(false);
        }
    }
    //  public void SpawnPlayer()
    // {
    //     Player = Instantiate(PrefabPlayer);
    //     DontDestroyOnLoad(Player);
    //     OnPlayerSpawn?.Invoke();
    // }





    // public void PlayerIsDead()
    // {
    //     OnPlayerDeath?.Invoke();
    // }
    private void FixedUpdate()
    {
        Move();

        if (GameManager.Instance.getIsJumping())
        {
            Jump();
        }

        if (RbPlayer.velocity.y < 0)
        {
            //En train de descendre (rechute) -> pour redescendre plus vite que le saut
            RbPlayer.gravityScale = GravityScale * FallGravityScaleMultiplier;
        }
        else
        {
            //En saut ou au sol (monte)
            RbPlayer.gravityScale = GravityScale;
        }

        float targetSpeed = speed * speedMultiplier * relativeTransform.x;

        Utility.HandleSlopes(transform,GroundLayerMask,1.5f);

        // if (isOnPlatform)
        // {
        //     RbPlayer.velocity=new Vector2(targetSpeed+platformRb.velocity.x, RbPlayer.velocity.y);
        // }
        // else
        // {
        //     RbPlayer.velocity=new Vector2(targetSpeed, RbPlayer.velocity.y);
        // }
    }

    //Permet de temporiser un certain temps (CoyoteTime), sur le saut hors d'une plate-forme 
    private IEnumerator UpdateisGroundedState(bool isGroundedState)
    {
        yield return new WaitForSeconds(CoyoteTime);
        GameManager.Instance.setIsGrounded(isGroundedState);
        // transform.position = checkpointpos;
    }

    // Déplacement du joueur sur l'axe horizontal
    //OPTI : Tout mettre dans le FixedUpdate()
    private void Move()
    {
        // Debug.Log(RbPlayer.velocity.x);
        float WalkVelocity = Mathf.Abs(RbPlayer.velocity.x);
        animator.SetFloat("Walk",WalkVelocity);
        dressAnim.SetFloat("Walk", WalkVelocity);
        headAnim.SetFloat("Walk", WalkVelocity);
        //Debug.Log(WalkVelocity);
        Vector2 targetVelocity = new Vector2(HorizontalInput * GameManager.Instance.getSpeed(), RbPlayer.velocity.y);
        RbPlayer.velocity = Vector2.SmoothDamp(RbPlayer.velocity, targetVelocity, ref zeroVelocity, GameManager.Instance.getSmoothing());
        RotateWhenMoving();

    }

    private void RotateWhenMoving()
    {
        float z = Input.GetAxis("Horizontal") * 15.0f; 
        Vector3 euler = transform.localEulerAngles;
        //euler.z = Mathf.Lerp(euler.z, -z, 2.0f * Time.deltaTime); //TOI TU MERDES TOUT
        euler.z= -z;
        transform.localEulerAngles = euler;
    }

    private void Jump()
    {
        RbPlayer.velocity = new Vector2(RbPlayer.velocity.x, JumpForce); //si enlevée ne peut plus sauter
        float JumpVelocity = Mathf.Abs(RbPlayer.velocity.x);
        animator.SetFloat("Jump",JumpForce);
        //dressAnim.SetFloat("Walk", JumpForce);
        //headAnim.SetFloat("Jump", WalkVelocity);
        //Debug.Log(WalkVelocity);

        //je sais pas quoi en faire
        Vector2 targetVelocity = new Vector2(HorizontalInput * GameManager.Instance.getSpeed(), RbPlayer.velocity.y);
        RbPlayer.velocity = Vector2.SmoothDamp(RbPlayer.velocity, targetVelocity, ref zeroVelocity, GameManager.Instance.getSmoothing());
        // RotateWhenMoving();
    }

    private void UpdateGroundCheckOffset()
    {
        // SpriteRenderer spritePlayer = GetComponent<SpriteRenderer>(); // Récupération du sprite du joueur
        //float height = RbPlayer.transform.localScale.y; // Récupération de la hauteur du sprite du joueur
        GroundCheckPosition = new Vector2(transform.position.x, transform.position.y + GroundCheckOffsetY);
    }

    // Callback to draw gizmos that are pickable and always drawn.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(GroundCheckPosition, new Vector2(GroundCheckWidth, GroundCheckHeight));
    }
    public bool IsPlayerAlive()
    {
        return isAlive;
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        checkpointpos = pos;
    }

    private void OnTriggerEnter2D(Collider2D obstacle)
    {
        if (obstacle.CompareTag("KILLZONE"))
        {
            Die();
        }



    }
    //------------------------------------------------------A REVOIR
    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = checkpointpos;
    }



}