using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
	public float movespeed=2f;
	public float directiontimemax=3f;
	public GameObject go2;
	public MeshFilter ground;
	float directiontime;
	bool newDirection=false;
	Vector3 PlaneNormal;

	Vector3 direction;
	// Use this for initialization
	void Start () {
		computeNewValues();
		newDirection=false;
		StartCoroutine(changeDirection());
	}
	//Vector3.Angle(v3A, v3B)
	// Update is called once per frame
	void Update () {

		//transform.position=transform.position-ground.mesh.normals[0].normalized*0.01f;
		/*
		PlaneNormal = ground.mesh.normals[0].normalized*0.01f;
		PlaneNormal.x+=direction.x;
		PlaneNormal.z+=direction.z;
		transform.position=transform.position-PlaneNormal;
		transform.position=transform.position-ground.mesh.normals[0].normalized*0.01f;
		if(newDirection==false){
			//transform.position += direction * movespeed * Time.deltaTime;
		}else{
			computeNewValues();
			StartCoroutine(changeDirection());
			newDirection=false;
		}
		*/

		Vector3 newRotation = new Vector3(go2.transform.eulerAngles.x, go2.transform.eulerAngles.x, go2.transform.eulerAngles.z);
		gameObject.transform.eulerAngles = newRotation;
		if(newDirection==false){
			transform.Translate(direction.x * movespeed * Time.deltaTime, -0.1f,direction.z * movespeed * Time.deltaTime ,Space.Self);
		}else{
			computeNewValues();
			StartCoroutine(changeDirection());
			newDirection=false;
		}

	}


	public void computeNewValues(){


		direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
		directiontime=1+directiontimemax*Random.Range(0,1);


	}
	IEnumerator changeDirection(){
		yield return new WaitForSeconds(directiontime);
		newDirection=true;
	}
}
