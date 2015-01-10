using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	
	[SerializeField]	
	private float movementSpeed = 5;
	
	private Transform _transform;
	
	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		
		_transform.localPosition += input * Time.deltaTime * movementSpeed;
	}
}
