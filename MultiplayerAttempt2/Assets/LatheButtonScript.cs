using UnityEngine;
using System.Collections;

public class LatheButtonScript : MonoBehaviour {


	void Update () {

	}

	public void ButtonPressed() {
		GameObject.Find ("LocalPlayer").GetComponent<SburberScript> ().CmdInstantiateTotemLathe ();
	}
}
