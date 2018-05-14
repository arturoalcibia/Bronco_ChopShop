using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour {

	public float moveSpeed;
	public RuntimeAnimatorController[] animFiles;
	Animator animComponent;
	// Use this for initialization
	void Start () {
		int index = Random.Range(0, animFiles.Length);
		animComponent = GetComponent<Animator>();
		animComponent.runtimeAnimatorController = animFiles[index];
		Debug.Log(animComponent.runtimeAnimatorController);
	}
	
	// Update is called once per frame
	void Update () {

        float mvSped = moveSpeed * -1;

        float inc = PlayerPrefs.GetFloat("VelocityIncrement") *
            (float)PlayerPrefs.GetInt("CurrentVelocity");

        mvSped -= inc;

		transform.position = new Vector3(transform.position.x + mvSped, transform.position.y);
	}
}
