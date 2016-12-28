using UnityEngine;
using System.Collections;

public class U : MonoBehaviour {

	public GameObject _Land_main;
	public static GameObject Land_main;
	
	// the settings elements
	public GameObject _Settings;
	public static GameObject Settings;
	// if settings is active then 'true'
	public static bool Settings_active = false;


	void Awake () {
		Land_main = _Land_main;
		Settings = _Settings;
	}
}
