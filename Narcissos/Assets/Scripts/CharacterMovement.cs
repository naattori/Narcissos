using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float movementSpeed = 10.0f;

	public static bool isMoving;

	private Vector2 targetPosition;
	private Vector2 movementDirection;
	private Vector2 moveStartPos;
	private float moveLength;

	void Awake () {
		targetPosition = transform.position;
		isMoving = false;
	}

	void Update () {
		if (Input.GetMouseButtonUp (0) && ((CursorControl.lookable == false) || (CursorControl.useHand == true))) {
			SetMoveTarget();
		}
		if   (((Vector2)transform.position - (Vector2)moveStartPos).sqrMagnitude < moveLength) {
			if (transform.FindChild("PlaceHolderChar").animation.isPlaying != true) {
				transform.FindChild("PlaceHolderChar").animation.Play();
			}
			transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
			isMoving = true;
		}
		else {
			transform.FindChild("PlaceHolderChar").animation.Stop();
			isMoving = false;
		}
	}

	void SetMoveTarget () {
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		moveStartPos = transform.position;
		moveLength = ((Vector2)targetPosition - (Vector2)transform.position).sqrMagnitude;
		movementDirection = ( (Vector2) targetPosition -  (Vector2) transform.position).normalized;
		Debug.Log ("Clicked, TargetPosition = " + targetPosition + " and movementDirection = " + movementDirection);
	}
}
