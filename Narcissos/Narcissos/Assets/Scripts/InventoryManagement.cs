using UnityEngine;
using System.Collections;

public class InventoryManagement : MonoBehaviour {
	
	private bool isHiding = true;

	void Update () {
		if (Input.mousePosition.y/Screen.height > 0.9) {
			ShowInventory();
		}
		else if (isHiding == false){
			StartCoroutine (HideInventory());
			isHiding = true;
		}
	}

	public void ShowInventory() {
		transform.FindChild ("ExampleInventoryBox").guiTexture.enabled = true;
		transform.FindChild ("ExampleInventoryItemRuby").guiTexture.enabled = true;
		isHiding = false;
	}

	IEnumerator HideInventory() {
		yield return new WaitForSeconds (1);
		transform.FindChild ("ExampleInventoryBox").guiTexture.enabled = false;
		transform.FindChild ("ExampleInventoryItemRuby").guiTexture.enabled = false;
	}
}
