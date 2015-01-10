using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
	public float movespeed=1f;
	public float directiontimemax=3f;
	float directiontime;
	bool newDirection=false;

	Vector3 direction;
	// Use this for initialization
	void Start () {
		computeNewValues();
		newDirection=false;
		StartCoroutine(changeDirection());
	}
	
	// Update is called once per frame
	void Update () {
		if(newDirection==false){
			transform.position += direction * movespeed * Time.deltaTime;
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
