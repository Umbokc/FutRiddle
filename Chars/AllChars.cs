using UnityEngine;
using System.Collections;

public class AllChars : MonoBehaviour {

	public Transform all_chars;

	private string[] levels_chars = {"JKVFPIXBGOAYCM","AAAAAAAAAAAAAA"};

	void Start () {
		int i = 0;
		foreach(Transform child in all_chars){
			
			TextMesh TheChar = child.gameObject.GetComponentInChildren<TextMesh>();
			TheChar.text = levels_chars[0][i].ToString();
			
			i++;
		}
	}
	
	void Update () {
	
	}
}
