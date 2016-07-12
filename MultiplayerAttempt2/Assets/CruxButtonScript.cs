using UnityEngine;
using System.Collections;

public class CruxButtonScript : MonoBehaviour {
	

	void Update () {
	
	}

	public void ButtonPressed() {
		GameObject.Find ("LocalPlayer").GetComponent<SburberScript> ().CmdInstantiateCruxtruder ();
	}
}
