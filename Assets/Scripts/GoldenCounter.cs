using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GoldenCounter : MonoBehaviour, IPointerClickHandler {
	public float counter=0;
	public GameObject nextPrefab;
	public BoxCollider myBoxCollider;
	public float scaleLimit;
	// Use this for initialization
	void Start () {
		myBoxCollider = gameObject.GetComponent("BoxCollider") as BoxCollider;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.localScale.x >=7.15){
			myBoxCollider.enabled = true;
		}
	}

	//void Selected(){
	//	if (gameObject.transform.localScale.x >=scaleLimit){
	//		Instantiate(nextPrefab, new Vector3(0,0,0) , Quaternion.identity);
	//		Destroy(transform.parent.gameObject);
	//	}
	//}

    public void OnPointerClick(PointerEventData eventData)
    {
		Instantiate(nextPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		Destroy(transform.parent.gameObject);
	}
}
