using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;



public class PlatformController : MonoBehaviour {
		
		//	GameObject shipController;
		
		
		Vector position;
		Hand hand;
		
		Frame frame;
		
		[SerializeField]
		Transform platformTransform;
		
		GameObject platformBasePosition;
		GameObject platformController;
		
		Vector3 lastPosition;
		
		float miceMoveY = 0.0f;
		
		[SerializeField]
		float sensitivityY = 0.005f;
		
		float miceMoveX = 0.0f;
		
		[SerializeField]
		float sensitivityX = 0.005f;
		
		static Controller controller = new Controller();
		
		
		void Start () {
//			platformBasePosition = GameObject.Find("PlayerBasePosition");
			platformController = GameObject.Find("PlatformController");
		}
		
		
		void Update () {			
			UpdateLeapMotionPosition();
//			UpdateMicePosition();
		}
		
	// HACK who needs a mouse when you can have leap doo'h
//		void UpdateMicePosition (){
//			
//			Transform tmpPos = shipTransform;
//			
//			miceMoveY += Input.GetAxis("Mouse Y") * sensitivityY;
//			if (Input.GetAxis("Mouse Y") > 0){
//				tmpPos.Translate(Vector3.up * miceMoveY);
//			}
//			if (Input.GetAxis("Mouse Y") < 0){
//				tmpPos.Translate(Vector3.up * miceMoveY);
//			}
//			
//			miceMoveX += Input.GetAxis("Mouse X") * sensitivityX;
//			if (Input.GetAxis("Mouse X") > 0){
//				tmpPos.Translate(Vector3.right * miceMoveX);
//			}
//			if (Input.GetAxis("Mouse X") < 0){
//				tmpPos.Translate(Vector3.right * miceMoveX);
//			}
//			
//			shipTransform.position = tmpPos.position;
//		}
//		
		void UpdateLeapMotionPosition(){
			controller = new Controller ();
			
			Frame frame = controller.Frame ();
			HandList hands = frame.Hands;
			Hand leapHand = hands[0];
			PointableList pointables = frame.Pointables;
			FingerList fingers = frame.Fingers;
			ToolList tools = frame.Tools;
			
			if (leapHand == null){
				platformTransform.localPosition = lastPosition;
			} 
			else 
			{
				Quaternion direction = leapHand.Fingers[1].Bone(Bone.BoneType.TYPE_DISTAL).Basis.Rotation();		
				Quaternion directionCorrected = direction * Quaternion.Euler(35, 0, 0); 
				
				platformTransform.localPosition = platformController.transform.TransformPoint(leapHand.PalmPosition.ToUnityScaled());
				
				directionCorrected.x = 0f;
				directionCorrected.y = 0f;
				
				platformTransform.rotation = directionCorrected;
				lastPosition = platformTransform.localPosition;
				
			}
		}
	}
