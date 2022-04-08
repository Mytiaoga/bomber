using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	GameObject bomb;
	Bomb bombExplosion;

	// Use this for initialization
	void Start () {
		bomb = GameObject.FindGameObjectWithTag("Bomb");
		bombExplosion = GetComponent<Bomb>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		Destroy(col.gameObject);
	}
}
