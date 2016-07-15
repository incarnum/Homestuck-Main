using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SburberScript : NetworkBehaviour {
	public GameObject crux;
	public GameObject tote;
	public GameObject alchemiter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	[Command]
	public void CmdInstantiateCruxtruder () {
		//Debug.Log ("instantiating");
		GameObject cruxo = Instantiate (crux);
		NetworkServer.Spawn (cruxo);
	}

	[Command]
	public void CmdInstantiateTotemLathe () {
		//Debug.Log ("instantiating");
		GameObject totem = Instantiate (tote);
		NetworkServer.Spawn (totem);
	}

	[Command]
	public void CmdInstantiateAlchemiter () {
		//Debug.Log ("instantiating");
		GameObject alch = Instantiate (alchemiter);
		NetworkServer.Spawn (alch);
	}

}
