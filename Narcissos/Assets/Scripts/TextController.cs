using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextController : MonoBehaviour {

	public float textShowTime = 2.0f;

	private string CurrentText;
	private Dictionary<string, string> observations = new Dictionary<string, string>();

	void Start () {
		observations.Add ("Ruby", "Ooh, shiny...");
	}

	public void ShowText (string IDstring) {
		observations.TryGetValue (IDstring, out CurrentText);
		transform.guiText.text = CurrentText;
		transform.guiText.enabled = true;
		StartCoroutine (HideText());
	}

	IEnumerator HideText () {
		yield return new WaitForSeconds(textShowTime);
		transform.guiText.enabled = false;
	}
}
