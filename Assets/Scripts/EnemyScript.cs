using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    Transform capsuleTrans;
    int randomDirection;
    [SerializeField] int enemyType;
    [SerializeField] GameObject player;
    float speed;
    bool checkRot;

    // Use this for initialization
    void Start () {
        capsuleTrans = GetComponent<Transform>();
        speed = .03f;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        randomDirection = Random.Range(1, 4);
        //Debug.Log(speed);
        //ENEMY A (Feigned Ignorance Pattern)
        if (enemyType == 1)
        {
            RaycastHit hit;
            Debug.DrawRay(capsuleTrans.position, capsuleTrans.forward * .5f, Color.red);
            if (!(Physics.Raycast(capsuleTrans.position, capsuleTrans.forward, out hit, .5f)) )
            {
                capsuleTrans.Translate(0, 0, speed);
                

            }
            else if (Physics.Raycast(capsuleTrans.position, capsuleTrans.forward, out hit, 1) && hit.collider.gameObject.tag != "Player")
            {
                capsuleTrans.localPosition = new Vector3(Mathf.RoundToInt(capsuleTrans.position.x),
            1f, Mathf.RoundToInt(capsuleTrans.position.z));
                if (randomDirection == 1) //Flip backwards
                {
                    capsuleTrans.Rotate(0, 180f, 0);
                }
                else if (randomDirection == 2)
                {
                    capsuleTrans.Rotate(0, 90, 0);
                }
                else if (randomDirection == 3)
                {
                    capsuleTrans.Rotate(0, -90, 0);
                }
                else if (randomDirection == 4)
                {
                    capsuleTrans.Rotate(0, -180f, 0);
                }
            }
        }

        //ENEMY B (Whim Pattern)
        if (enemyType == 2)
        {
            RaycastHit hit;
            Debug.DrawRay(capsuleTrans.position, Vector3.back * 10, Color.red);
            Debug.DrawRay(capsuleTrans.position, Vector3.left * 10, Color.red);
            Debug.DrawRay(capsuleTrans.position, Vector3.forward * 10, Color.red);
            if (!(Physics.Raycast(capsuleTrans.position, capsuleTrans.forward, out hit, 1)))
            {
                capsuleTrans.Translate(0, 0, .05f);
            }
            else if (Physics.Raycast(capsuleTrans.position, capsuleTrans.forward, out hit, 1))
            {
                if (hit.collider.gameObject.tag != "Player")
                {
                    if (randomDirection == 1) //Flip backwards
                    {
                        capsuleTrans.Rotate(0, 180f, 0);
                    }
                    else if (randomDirection == 2)
                    {
                        capsuleTrans.Rotate(0, 90, 0);
                    }
                    else if (randomDirection == 3)
                    {
                        capsuleTrans.Rotate(0, -90, 0);
                    }
                    else if (randomDirection == 4)
                    {
                        capsuleTrans.Rotate(0, -180f, 0);
                    }
                }
            }
            if (Physics.Raycast(capsuleTrans.position, Vector3.back, out hit, 10))
            {
                capsuleTrans.Translate(0, 0, 0);
                if (hit.collider.gameObject.tag == "Player" && !checkRot)
                {
                    Debug.Log("YES");
                    capsuleTrans.Rotate(0, 90f, 0);
                    checkRot = true;
                    Debug.Log("PASS");
                }
            }
            if (Physics.Raycast(capsuleTrans.position, Vector3.forward, out hit, 10))
            {
                capsuleTrans.Translate(0, 0, 0);
                if (hit.collider.gameObject.tag == "Player" && !checkRot)
                {
                    Debug.Log("YES");
                    capsuleTrans.Rotate(0, -90f, 0);
                    checkRot = true;
                    Debug.Log("PASS");
                }
            }
            if (Physics.Raycast(capsuleTrans.position, Vector3.left, out hit, 10))
            {
                capsuleTrans.Translate(0, 0, 0);
                if (hit.collider.gameObject.tag == "Player" && !checkRot)
                {
                    Debug.Log("YES");
                    capsuleTrans.Rotate(0, -180f, 0);
                    checkRot = true;
                    Debug.Log("PASS");
                }
            }
            else
            {
                checkRot = false;
            }
        }

        //ENEMY C (Bomb Search Pattern)
        if(enemyType == 3)
        {

        }   

    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Enemy hits Player!");
    //        Destroy(col.gameObject);
    //    }
    //}
}
