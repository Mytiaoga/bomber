using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	[SerializeField] GameObject explosionPrefab;
	public LayerMask hardBlock;
	public LayerMask softBlock;
	bool exploded = false;
	public int count;
	public int explosionSize;
	public int bombCounter;
	bool createOnce;
	[SerializeField] GameObject player;
	GameObject BombUp;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		Invoke("Explode", 3f);
		//Size of the explosion
		//explosionSize = player.GetComponent<Player>().explosionS;
		//How many bombs can be placed
		//BombUp = GameObject.Find("Player");
		
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log(bombCounter);
  //      if (!createOnce)
  //      {
		//	//bombCounter += BombUp.GetComponent<Player>().bombCount;
		//	//bombCounter++;
		//	createOnce = true;
		//}
	}

	void Explode()
	{
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		StartCoroutine(CreateExplosions(Vector3.forward));
		StartCoroutine(CreateExplosions(Vector3.right));
		StartCoroutine(CreateExplosions(Vector3.back));
		StartCoroutine(CreateExplosions(Vector3.left));
		GetComponent<MeshRenderer>().enabled = false;
		exploded = true;
		transform.Find("Collider").gameObject.SetActive(false);
		//player.GetComponent<Player>().bombs = bombCounter;
        Destroy(gameObject, .3f);
    }


	private IEnumerator CreateExplosions(Vector3 direction)
	{
		for (int i = 1; i < 3; i++)
		{
			RaycastHit hit;
			Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit,
			  i, hardBlock);
			if (!hit.collider)
			{
				Instantiate(explosionPrefab, transform.position + (i * direction),
				  explosionPrefab.transform.rotation);
				//Debug.Log(i);
			}
			else
			{
				break;
			}
			yield return new WaitForSeconds(.05f);
		}
	}

  //  public void OnTriggerEnter(Collider col)
  //  {
		////CHAIN EXPLOSION
  //      if (!exploded && col.CompareTag("Explosion"))
  //      {
  //          //Debug.Log("Hello");
  //          CancelInvoke("Explode");
  //          Explode();
  //      }
  //  }

}




