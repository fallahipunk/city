using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class ChickenController : MonoBehaviour {

	public float minMoveTime = 3;
	public float maxMoveTime = 10;

	public float idleChance = 0.5f;
	public float moveSpeed = 0.25f;


	protected CharacterController controller = null;
	protected Vector3 move = Vector3.zero;
	protected Animator chickenAnimator = null;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		chickenAnimator = GetComponentInChildren<Animator>();
		StartCoroutine(RandomRoutine());
	}

	void Update () 
	{
		controller.SimpleMove(move);
		transform.LookAt(transform.position + move);

		chickenAnimator.SetFloat("speed", move.magnitude);
	}

	private IEnumerator RandomRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minMoveTime, maxMoveTime)); 

			if (Random.value < idleChance)
			{
				move = Vector3.zero;
				chickenAnimator.SetBool("eat", false);

				if (Random.value < 0.5f)
				{
					chickenAnimator.SetBool("eat", true);
				}
			}
			else
			{
				move = new Vector3(Random.Range(-moveSpeed, moveSpeed), 0, Random.Range(-moveSpeed, moveSpeed));
				chickenAnimator.SetBool("eat", false);
			}
	
		}


	}
}