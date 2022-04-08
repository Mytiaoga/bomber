using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{

    //Player parameters
    public float moveSpeed = 5f;
    public bool canDropBombs = true;
    //Can the player drop bombs?
    public bool canMove = true;
    //Can the player move?

    public int bombs;
    public int bombCount;
    public int explosionS;
    //Amount of bombs the player has left to drop, gets decreased as the player
    //drops a bomb, increases as an owned bomb explodes

    //Prefabs
    public GameObject bomb;
    GameObject bomB;
    //PowerUps bCounter;

    //Cached components
    Rigidbody rigidBody;
    Transform playerTrans;
    Animator animator;

    //LayerMasks
    public LayerMask softBlock;
    // Use this for initialization
    void Start()
    {
        //Cache the attached components for better performance and less typing
        rigidBody = GetComponent<Rigidbody> ();
        playerTrans = transform;
        //bombs = 1;
        explosionS = 2;
        bomB = GameObject.Find("BombUp");
        //bCounter = bomB.GetComponent<PowerUps>();
        //bombCount = bCounter.GetComponent<PowerUps>().bombNumber;
        bombs = 1;
        //Invoke("StartOfGame", 0);

        //animator = myTransform.Find ("PlayerModel").GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateMovement();

    }

    private void UpdateMovement()
    {
        //animator.SetBool ("Walking", false);

        if (!canMove)
        { //Return if player can't move
            return;
        }
        if (canMove)
        {
            Movement();
        }

    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        { //Up movement
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            playerTrans.rotation = Quaternion.Euler (0, 0, 0);
            //animator.SetBool ("Walking", true);
        }

        else if (Input.GetKey(KeyCode.A))
        { //Left movement
            rigidBody.velocity = new Vector3 (-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            playerTrans.rotation = Quaternion.Euler (0, 270, 0);
            //animator.SetBool ("Walking", true);
        }

        else if (Input.GetKey(KeyCode.S))
        { //Down movement
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            playerTrans.rotation = Quaternion.Euler (0, 180, 0);
            //animator.SetBool ("Walking", true);
        }

        else if (Input.GetKey(KeyCode.D))
        { //Right movement
            rigidBody.velocity = new Vector3 (moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            playerTrans.rotation = Quaternion.Euler (0, 90, 0);
            //animator.SetBool ("Walking", true);
        }
        else
        {
            rigidBody.velocity = new Vector3(0,0,0);
            playerTrans.localPosition = new Vector3(Mathf.RoundToInt(playerTrans.position.x),
            1f, Mathf.RoundToInt(playerTrans.position.z));
        }

        if (canDropBombs && Input.GetKeyDown(KeyCode.Space) && bombs != 0)
        { //Drop bomb
            DropBomb();
        }
       
    }

    private void DropBomb()
    {
        if(bomb)
        {
            //bombs--;
            Instantiate(bomb, new Vector3(Mathf.RoundToInt(playerTrans.position.x),
            1f, Mathf.RoundToInt(playerTrans.position.z)),
            bomb.transform.rotation);
        }
        
    }

        public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Explosion"))
        {
            Debug.Log ("Hit by explosion!");
            //Destroy(gameObject);
        }
    }
}
