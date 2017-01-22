using UnityEngine;
using System.Collections;


public class Logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("LoadScene", 3);
	}

	void LoadScene(){
		 U.LoadScene ("_main");
	}
}
