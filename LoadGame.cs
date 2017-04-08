using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	void Start () {
		Invoke("LoadScene", 3);
	}

	void LoadScene(){
		SceneManager.LoadScene ("_main");
	}
}
