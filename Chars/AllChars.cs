using UnityEngine;
using System.Collections;

public class AllChars : MonoBehaviour {

	public Transform all_chars;

	private int TheLevel = 1;

	void Start () {
		// int TheLevel = PlayerPrefs.GetInt("Level");
		// SetChars();
	}
	
	void Update (){
		if(U.GAME_STARTED == 1){
			U.GAME_STARTED = 2;
			TheLevel = U.current_level;
			SetChars();
		}
	}

	void SetChars () {
		int i = 0;
		foreach(Transform child in all_chars){
			TextMesh TheChar = child.gameObject.GetComponentInChildren<TextMesh>();
			TheChar.text = U._LEVELS_CHARS[TheLevel-1][i].ToString().ToUpper();
			i++;
		}
	}
}
