using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	
	public float time;
	public Transform[] positionPrefabs;
	public GameObject[] listPrefabs;

	public int handCount = 0;

	GameObject track;

	void Start () 
	{
		StartCoroutine(spawnHand());
	}
	
	IEnumerator spawnHand()
	{
		while(true)
		{

			int prefab = Random.Range(0, 2);
			track = (GameObject)Instantiate(listPrefabs[prefab], positionPrefabs[0].transform.position, Quaternion.Euler(0, 0, 0));
			yield return new WaitForSeconds(2f);
			track.name = "hand" + handCount;
			handCount ++;

		}
	}

	void Update () {
		
		
	}
}
