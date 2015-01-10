using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	[SerializeField] private AnimationCurve acceleration;
	[SerializeField] private Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);

	private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontalMovement = Input.GetAxis("Horizontal");

		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * horizontalMovement);
		rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);

		

	}
}
