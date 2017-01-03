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
		if (U.What_button_Enter < U._LEVELS_ANSWER[U.current_level-1].Length){
			TextMesh chr = gameObject.GetComponentInChildren<TextMesh>();
			
			U._ENTER_CHARS[U.What_button_Enter].gameObject.GetComponentInChildren<TextMesh>().text = chr.text;
			
			
			if (chr.text.ToString().ToUpper() == U._LEVELS_ANSWER[U.current_level-1][U.What_button_Enter].ToString().ToUpper() && U.WHILE_TRUE_ANSWER){
				
				if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
					PlayerPrefs.SetString("Levels", PlayerPrefs.GetString("Levels") + ","+ U.current_level);
					U.TheLevel.SetActive (false);
					U.Answer.SetActive (true);
				}

			} else {
				U.WHILE_TRUE_ANSWER = false;
			}

			U.What_button_Enter++;
		}
	}

}
