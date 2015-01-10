using UnityEngine;
using System.Collections;

public class Eater : MonoBehaviour {

	private PlayerControl playerControl;

	// Use this for initialization
	void Start () {
		playerControl = GetComponentInParent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Eater collider");
		if (other.gameObject.tag == ("Astronaut")) 
		{
			Vector3 spawnPosition = other.gameObject.transform.localPosition;
			Object.Destroy(other.gameObject);
			playerControl.spawnChild(spawnPosition);	
		}
	}
}
