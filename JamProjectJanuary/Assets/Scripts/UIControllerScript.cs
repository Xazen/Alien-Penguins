using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIControllerScript : MonoBehaviour {
	
	
	public int AstronautsNumber;
	public int PenguinNumber=4;
	public Slider Bar;
	public GameObject GameWon;
	public GameObject GameOver;
	bool gameStarted=false;
	public int AddLayer2;
	public int AddLayer3;
	public int AddLayer4;
	public int AddLayer5;
	public int AddLayer6;
	public int AddLayer7;
	public int AddLayer8;
	public AudioSource Source1;
	public AudioSource Source2;
	public AudioSource Source3;
	public AudioSource Source4;
	public AudioSource Source5;
	public AudioSource Source6;
	public AudioSource Source7;
	public AudioSource Source8;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			AstronautsNumber = GameObject.FindGameObjectsWithTag("Astronaut").Length;

			//PenguinNumber = GameObject.FindGameObjectsWithTag("Penguin").Length;

		//PenguinNumber=GameObject.FindGameObjectsWithTag("Penguin").Length;
		Bar.maxValue=AstronautsNumber+PenguinNumber;
		Bar.value=AstronautsNumber;
		if(!gameStarted && AstronautsNumber>=1){
			gameStarted=true;
		}
		if(PenguinNumber==0){
			GameOver.SetActive(true);
			//GameWon.
		}
		if(PenguinNumber==0&&gameStarted){
			GameWon.SetActive(true);
		}
		if(PenguinNumber>AddLayer2){
			Source2.mute=false;
		}
		if(PenguinNumber>AddLayer3){
			Source3.mute=false;
		}
		if(PenguinNumber>AddLayer4){
			Source4.mute=false;
		}
		if(PenguinNumber>AddLayer5){
			Source5.mute=false;
		}
		if(PenguinNumber>AddLayer6){
			Source6.mute=false;
		}
		if(PenguinNumber>AddLayer7){
			Source7.mute=false;
		}
		if(PenguinNumber>AddLayer8){
			Source8.mute=false;
		}
	}
}
