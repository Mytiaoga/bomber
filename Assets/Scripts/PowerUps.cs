using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	public int powerUpType;
	GameObject player;
	GameObject bomb;
	public int bombNumber;
	bool touch;

	// Use this for initialization
	void Start () {
		/*Power Type
		 * 1 = Fire Up
		 * 2 = Speed Up
		 * 3 = Bomb Up
		 */
		bombNumber = 1;
		player = GameObject.FindGameObjectWithTag("Player");
		bomb = GameObject.FindGameObjectWithTag("Player");
		touch = true;
	}

	// Update is called once per frame
	void Update() {
		if (!touch)
		{
			Debug.Log("YES");
			bombNumber = 2;
		}
        else
        {
			bombNumber = 1;
		}
	}

	void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
			if(powerUpType == 1)
            {
				bomb.GetComponent<Player>().explosionS = 3;
			}
			if(powerUpType == 2)
            {
				player.GetComponent<Player>().moveSpeed = 10f;
            }
			if(powerUpType == 3)
            {
				Debug.Log("NO");
				touch = false;
            }
			Destroy(gameObject);
        }
    }
}
