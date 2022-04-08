using UnityEngine;
using System.Collections;
using System;

public class Player1 : MonoBehaviour
{

    //Indicates what player this is: P1 or P2
    public float moveSpeed = 5f;
    public bool canDropBombs = true;
    //Can the player drop bombs?
    public bool canMove = true;
    //Can the player move?

    private int bombs = 2;
    //Amount of bombs the player has left to drop, gets decreased as the player
    //drops a bomb, increases as an owned bomb explodes

    //Prefabs
    public GameObject bombPrefab;

    //Cached components
    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        //Cache the attached components for better performance and less typing
        rigidBody = GetComponent<Rigidbody> ();
        myTransform = transform;
        //animator = myTransform.Find ("PlayerModel").GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateMovement();
    }

    private void UpdateMovement ()
    {
        //animator.SetBool ("Walking", false);

        if (!canMove)
        { //Return if player can't move
            return;
        }

        //Depending on the player number, use different input for moving

            UpdatePlayer1Movement ();
        
    }

    /// <summary>
    /// Updates Player 1's movement and facing rotation using the WASD keys and drops bombs using Space
    /// </summary>
    private void UpdatePlayer1Movement ()
    {
        if (Input.GetKey (KeyCode.W))
        { //Up movement
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler (0, 0, 0);
            //animator.SetBool ("Walking", true);
        }

        if (Input.GetKey (KeyCode.A))
        { //Left movement
            rigidBody.velocity = new Vector3 (-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler (0, 270, 0);
            //animator.SetBool ("Walking", true);
        }

        if (Input.GetKey (KeyCode.S))
        { //Down movement
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler (0, 180, 0);
            //animator.SetBool ("Walking", true);
        }

        if (Input.GetKey (KeyCode.D))
        { //Right movement
            rigidBody.velocity = new Vector3 (moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler (0, 90, 0);
            //animator.SetBool ("Walking", true);
        }

        if (canDropBombs && Input.GetKeyDown (KeyCode.Space))
        { //Drop bomb
            DropBomb ();
        }
    }

    /// <summary>
    /// Updates Player 2's movement and facing rotation using the arrow keys and drops bombs using Enter or Return
    /// </summary>
  
    /// <summary>
    /// Drops a bomb beneath the player
    /// </summary>
    private void DropBomb ()
    {
        if (bombPrefab)
        { //Check if bomb prefab is assigned first
            Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(myTransform.position.x),
  1f, Mathf.RoundToInt(myTransform.position.z)),
  bombPrefab.transform.rotation);

        }
    }

 
}
