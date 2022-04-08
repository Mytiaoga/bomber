using UnityEngine;
using System.Collections;

public class SoftBlock : MonoBehaviour {

	[SerializeField] GameObject Explosion;

	// Use this for initialization
	void Start () {
		Explosion = GameObject.FindGameObjectWithTag("Explosion");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
