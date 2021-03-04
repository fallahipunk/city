using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveCircle : MonoBehaviour, IDragHandler {
	public float speed = 0.006f;
	public bool isSelected = false;
	public GameObject goldenObject;
	float goldenScaleSpeed = 0.02f;
	public float goldenRotateSpeed = 2;
	public float goldenScaleLimit = 7.2f;
	public float goldenPositionSpeed = 0.01f;
	public GoldenCounter myGoldenCounter;
	Camera cam;

	// Use this for initialization
	void Start () {
		//goldenObject = GameObject.FindGameObjectWithTag("Golden Object");
		myGoldenCounter = goldenObject.GetComponent("GoldenCounter") as GoldenCounter;
		cam = Camera.main;
	}
	

//	void Update() {
//		if(isSelected)
//		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
//			// Get movement of the finger since last frame
//			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//			// Move object across XY plane
//			transform.Translate(-touchDeltaPosition.x * speed*-1, -touchDeltaPosition.y * speed *-1, 0);
//			//enlarge and rotate golden object till fully grown
//			myGoldenCounter.counter += 0.1f;
//			if (myGoldenCounter.counter >=7){
//			if (goldenObject.transform.localScale.x <=goldenScaleLimit){
//				goldenObject.transform.localScale += new Vector3(goldenScaleSpeed,goldenScaleSpeed,goldenScaleSpeed);
//				goldenObject.transform.Rotate ( new Vector3(0,goldenRotateSpeed,0));
//					goldenObject.transform.position -= new Vector3(-goldenPositionSpeed/5,goldenPositionSpeed,0);
//			}
//		}
//	}// end if myGoldenCounter
//		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
//			isSelected = false;
//	}

//}//end update

//	void Selected (){
//		isSelected = true;
//	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 finalPos = eventData.position;
		Vector3 worldFinalPos = cam.ScreenToWorldPoint(new Vector3(finalPos.x, finalPos.y));
		Vector2 initialPos = finalPos - eventData.delta;
		Vector3 worldInitialPos = cam.ScreenToWorldPoint(new Vector3(initialPos.x, initialPos.y));
		transform.Translate(worldFinalPos - worldInitialPos);
		//myGoldenCounter.counter += 0.1f;
		//Debug.Log(myGoldenCounter.counter);
		//if (myGoldenCounter.counter >= 7)
		//{
			if (goldenObject.transform.localScale.x <= goldenScaleLimit)
			{
				goldenObject.transform.localScale += new Vector3(goldenScaleSpeed, goldenScaleSpeed, goldenScaleSpeed);
				goldenObject.transform.Rotate(new Vector3(0, goldenRotateSpeed, 0));
				goldenObject.transform.position -= new Vector3(-goldenPositionSpeed / 5, goldenPositionSpeed, 0);
			}
		//}
	}
}// end class
