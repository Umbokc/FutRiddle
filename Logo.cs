using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("LoadScene", 3);
	}

	void LoadScene(){
		 SceneManager.LoadScene ("_main");
	}
}
