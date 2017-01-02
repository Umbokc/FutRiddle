using UnityEngine;
using System.Collections;

public class AllChars : MonoBehaviour {

	public Transform all_chars;

	void Start () {
		int i = 0;
		foreach(Transform child in all_chars){
			
			int TheLevel = PlayerPrefs.GetInt("Level");

			TextMesh TheChar = child.gameObject.GetComponentInChildren<TextMesh>();
			TheChar.text = U._LEVELS_CHARS[TheLevel-1][i].ToString().ToUpper();
			
			i++;
		}
	}
	
	void Update () {
	
	}
}
