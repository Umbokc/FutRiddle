using UnityEngine;
using System.Collections;

public class ClickField : MonoBehaviour{

	public void OnMouseDown(){
			transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	public void OnMouseUp(){
			transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
			Camera.main.GetComponent<AudioSource> ().Play ();
			Retry_chr();
	}

	public void Retry_chr(){
		if(gameObject.GetComponentInChildren<TextMesh>().text != ""){
			
			string chr = gameObject.GetComponentInChildren<TextMesh>().text.ToString().ToUpper();
			
			GameObject go;

			for(int i = 0; i < U._ENTER_CHARS.transform.childCount; i++ ){
				go = U._ENTER_CHARS.transform.GetChild (i).gameObject;
				if(go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper() == chr && go.GetComponent<ClickChar>().destroyed == true){
					go.GetComponent<ClickChar>().Destroy_the(false);

					// получаем колличество символов ответа
					int len_word = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].Length;

					for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.childCount; k++ ){
						if(gameObject == U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.GetChild (k).gameObject){
							U.What_button_Enter = k;
							U.HOW_BUTTONS_DONE[U.What_button_Enter] = false;
							break;
						}
					}

					break;
				}
			}

			gameObject.GetComponentInChildren<TextMesh>().text = "";
		}
	}
}
