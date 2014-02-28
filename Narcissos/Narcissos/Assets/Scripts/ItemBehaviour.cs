using UnityEngine;
using System.Collections;

public class ItemBehaviour : MonoBehaviour {

	public GameObject InventoryVersion;
	public string IDstring;
	private bool isTarget;

	void OnMouseOver () {
		CursorControl.lookable = true;
	}

	void OnMouseExit () {
		CursorControl.lookable = false;
	}

	void Update () {
		if (Input.GetMouseButtonUp(0)) {
		    if ((Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position).sqrMagnitude < 101) {
				if (CursorControl.useHand == true) {
					isTarget = true;
					StartCoroutine (BePickedUp());
				}
				else if (CursorControl.lookable == true) {
					GameObject.FindGameObjectWithTag("Text").SendMessage("ShowText", IDstring);
				}
			}
			else {isTarget = false;}
		}
	}

	IEnumerator BePickedUp() {
		Debug.Log ("Start Picking up");
		yield return new WaitForSeconds (0.1f);
		while (CharacterMovement.isMoving == true) {
			yield return null;
		}
		Debug.Log ("Stopped Moving in PickUp");
		yield return new WaitForSeconds (0.1f);
		if (isTarget == true) {
			Debug.Log ("Object Destroyed");
			CursorControl.lookable = false;
			InventoryVersion.SetActive(true);
			GameObject.FindGameObjectWithTag("Inventory").SendMessage("ShowInventory");
			Destroy(gameObject);
		}
	}
}
