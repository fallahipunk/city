//	OnTouchDown.js
//	Allows "OnMouseDown()" events to work on the iPhone.
//	Attack to the main camera.
 
#pragma strict
#pragma implicit
#pragma downcast
 	var moved : boolean = false;
function Update () {
//Debug.Log (moved);
	// Code for OnMouseDown in the iPhone. Unquote to test.
	var hit : RaycastHit;
	var selectedObject: GameObject;
	for (var i = 0; i < Input.touchCount; ++i) {

		if (Input.GetTouch(i).phase == TouchPhase.Began) {
		// Construct a ray from the current touch coordinates
	
		var ray = GetComponent.<Camera>().ScreenPointToRay (Input.GetTouch(i).position);
		if (Physics.Raycast (ray,hit)) {
			Debug.Log ("raycast hit");
			hit.transform.gameObject.SendMessage("Selected");
	      }

	   }
   }
}

