using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	[SerializeField] private AnimationCurve rotationAcceleration;
	[SerializeField] private Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);

	private float time = 0;
	private Rigidbody playerRigidbody;

	void Awake () {
		if (rotationAcceleration.keys.Length < 1) 
		{
			Debug.LogWarning("Transition Path not configured");
		}
	}

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time += Time.deltaTime;
		float horizontalMovement = Input.GetAxis("Horizontal");
		if (horizontalMovement == 0) 
		{
			time = 0;
		}

		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * horizontalMovement * rotationAcceleration.Evaluate(time));
		rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
	}
}
