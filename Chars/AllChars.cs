using UnityEngine;
using System.Collections;

public class AllChars : MonoBehaviour {

	public Transform all_chars;

	private string[] levels_chars = {
										"JKVFPIXBGOAYCM",
										"JKFTHIOBGONUCM",
										"JAFRHIOZGENUCM",
										"JAFRHPOTGENYCM",
										"IAFRHPSTQENYIM"
									};

	void Start () {
		int i = 0;
		foreach(Transform child in all_chars){
			
			int TheLevel = PlayerPrefs.GetInt("Level");

			TextMesh TheChar = child.gameObject.GetComponentInChildren<TextMesh>();
			TheChar.text = levels_chars[TheLevel-1][i].ToString();
			
			i++;
		}
	}
	
	void Update () {
	
	}
}
