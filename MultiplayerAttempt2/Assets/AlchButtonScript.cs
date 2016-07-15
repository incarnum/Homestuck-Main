using UnityEngine;
using System.Collections;

public class AlchButtonScript : MonoBehaviour {


	void Update () {

	}

	public void ButtonPressed() {
		GameObject.Find ("LocalPlayer").GetComponent<SburberScript> ().CmdInstantiateAlchemiter ();
	}
}
