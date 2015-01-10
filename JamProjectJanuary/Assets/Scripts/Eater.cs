using UnityEngine;
using System.Collections;

public class Eater : MonoBehaviour {

	private PlayerControl playerControl;

	// Use this for initialization
	void Start () {
		GetComponentInParent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Eater collider");
		if (other.gameObject.tag == ("Astronaut")) 
		{
			Object.Destroy(other.gameObject);
		}
	}
}
