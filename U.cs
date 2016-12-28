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

	public GameObject[] _lands = new GameObject[3];
	public static GameObject[] lands;

	public static int current = 0;


	void Awake () {
		Land_main = _Land_main;
		Settings = _Settings;
		lands = _lands;

	}
}
