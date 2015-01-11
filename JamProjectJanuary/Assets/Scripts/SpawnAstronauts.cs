using UnityEngine;
using System.Collections;

public class SpawnAstronauts : MonoBehaviour {

	public GameObject Astronaut;
	public float SpawnTimeDelta=1f;
	public float circleSize = 1f;
	bool SpawnNew=true;
	Vector2 spawnPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(SpawnNew==true){
			Instantiate(Astronaut, getPosition(), transform.rotation);
			SpawnNew=false;
			StartCoroutine(reLoad());
			}
	}

	public Vector3 getPosition(){
		spawnPosition =  Random.insideUnitCircle * circleSize;
		Vector3 Position = new Vector3(transform.position.x+spawnPosition.x,transform.position.y+spawnPosition.y,0);
		print (Position);
		return Position;
		
			//transform.position.x = newPosition.x;
			//transform.position.y = newPosition.y;

	}
	IEnumerator reLoad(){
		yield return new WaitForSeconds(SpawnTimeDelta);
		SpawnNew=true;
	}
}
