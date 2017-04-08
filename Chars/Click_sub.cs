using UnityEngine;
using System.Collections;

public class Click_sub : MonoBehaviour {

	private static GameObject old;

	void OnMouseDown(){
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
		if(U.PP_Money >= 100){
			Camera.main.GetComponent<AudioSource> ().Play ();
			Sub();
		}
	}

	void Sub(){
		GameObject go;

		for(int i = 0; i < U._ENTER_CHARS.transform.childCount; i++ ){

			go = U._ENTER_CHARS.transform.GetChild (i).gameObject;

			int a = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].ToString().ToUpper().IndexOf(go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper());
			
			if(a == -1 && old != go && go.GetComponent<ClickChar>().destroyed == false){
				go.GetComponent<ClickChar>().Destroy_the();
				U.PP_Money -= 15;
				old = go;
				break;
			}
		}
	}

}
