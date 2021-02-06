#pragma strict

var nextPrefab : GameObject;

function Start () {

}

function Update () {

}

function OnMouseDown (){
	Instantiate(nextPrefab, transform.position, transform.rotation);
	Destroy(gameObject);
	
}