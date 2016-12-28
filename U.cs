using UnityEngine;
using System.Collections;

public class U : MonoBehaviour {

	public GameObject _Germany_main;
	public static GameObject Germany_main;
	
	// the settings elements
	public GameObject _Settings;
	public static GameObject Settings;
	// if settings is active then 'true'
	public static bool Settings_active = false;


	void Awake () {
		Germany_main = _Germany_main;
		Settings = _Settings;
	}
}
