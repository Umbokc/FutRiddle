using UnityEngine;
using System.Collections;

public class ClickField : ClickButton {

	void OnMouseUpAsButton (){
		U.CLickPlay();
		if(gameObject.GetComponentInChildren<TextMesh>().text != ""){
			
			string chr = gameObject.GetComponentInChildren<TextMesh>().text.ToString().ToUpper();
			
			GameObject go;

			for(int i = 0; i < U._ENTER_CHARS.transform.childCount; i++ ){
				go = U._ENTER_CHARS.transform.GetChild (i).gameObject;
				if(go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper() == chr && go.GetComponent<ClickChar>().destroyed == true){
					go.GetComponent<ClickChar>().Destroy_the(false);

					Vector3 t = go.transform.position;
					t.y = go.GetComponent<ClickChar>().the_y;
					go.transform.position = t;
					
					for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.childCount; k++ ){
						if(gameObject == U._FIELD_ANSWER_CHARS.transform.GetChild (k).gameObject){
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
