using UnityEngine;
using System.Collections;

public class AllCharsClick : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
		if (U.What_button_Enter < U._LEVELS_ANSWER[U.Level-1].Length){
			TextMesh chr = gameObject.GetComponentInChildren<TextMesh>();
			
			U._ENTER_CHARS[U.What_button_Enter].gameObject.GetComponentInChildren<TextMesh>().text = chr.text;
			
			
			if (chr.text.ToString().ToUpper() == U._LEVELS_ANSWER[U.Level-1][U.What_button_Enter].ToString().ToUpper() && U.WHILE_TRUE_ANSWER){
				
				if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.Level-1].Length){
					Debug.Log("ok");
				}

			} else {
				U.WHILE_TRUE_ANSWER = false;
			}

			U.What_button_Enter++;
		}
	}

}
