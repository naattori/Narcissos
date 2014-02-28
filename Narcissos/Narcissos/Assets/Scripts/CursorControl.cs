using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

	public Texture2D WalkCursor;
	public Texture2D LookCursor;
	public Texture2D TouchCursor;
	public Texture2D UseCursor;

	public int cursorSizeX = 32;
	public int cursorSizeY = 32;

	public static bool lookable = false;
	public static bool useHand = false;

	void Start () {
		Screen.showCursor = false;
	}

	void Update () {
		if (lookable == false) {
			useHand = false;
		}
		else if (Input.GetMouseButtonUp (1)) {
			if (useHand == false) {
				useHand = true;
			}
			else {
				useHand = false;
			}
		}
	}
	
	void OnGUI() {

		if (lookable == true) {
			if (useHand == true) {
				GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, 
				                          Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), TouchCursor);
			}
			else {
				GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, 
				                          Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), LookCursor);
			}
		}
		else {
			GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, 
			                          Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), WalkCursor);
		}
	}
}
