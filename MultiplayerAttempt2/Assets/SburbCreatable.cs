using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;

public class SburbCreatable : NetworkBehaviour {
	private float verticalOffset;
	private float startPos;
	private GameObject localPlayer;
	Rigidbody body;
	Transform transformpos;
	private bool placing;


//	void Start () {
//		placing = true;
//		verticalOffset = 0;
//		body = GetComponent<Rigidbody>();
//		transformpos = GetComponent<Transform>();
//		localPlayer = GameObject.Find ("LocalPlayer");
//
//	}

	void Awake()
	{
		if (GameObject.Find ("GameMode").GetComponent<GameMode> ().currentGameMode == 3) {
			placing = true;
			verticalOffset = 0;
			body = GetComponent<Rigidbody>();
			body.useGravity = false;
			transformpos = GetComponent<Transform>();
			localPlayer = GameObject.Find ("LocalPlayer");
			startPos = transformpos.position.y;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().CmdProvideSelectedToServer (gameObject);
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().gravity = false;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().working = true;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().CmdProvideGravityToServer (false);
		}
	}
		
	void Update () {

		verticalOffset += Input.GetAxis("Mouse ScrollWheel");
		if (GameObject.Find ("GameMode").GetComponent<GameMode> ().currentGameMode == 3 && placing) {
			float distance_to_screen = Camera.main.WorldToScreenPoint (gameObject.transform.position).z;
			Vector3 pos_move = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y + 20, distance_to_screen + verticalOffset / 2));
			transform.position = new Vector3 (pos_move.x, startPos + verticalOffset, pos_move.z);
		}
	}
		
	void OnMouseDown()
	{
		if (GameObject.Find ("GameMode").GetComponent<GameMode> ().currentGameMode == 3) {
			body.useGravity = true;
			verticalOffset = 0;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().gravity = true;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().working = false;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().CmdProvideGravityToServer (true);
			placing = false;
			Debug.Log ("mousdown triggered");
		}
	}
		
}
