using UnityEngine;
using System.Collections;

public class ClickCharAdd_Sub : ClickButton {
	
	public TheButton_add_sub theButton_add_sub;

	private static GameObject old;

	void OnMouseUpAsButton (){
		U.CLickPlay();
		switch (theButton_add_sub){
			case TheButton_add_sub.charAdd:
				if(U.PP_Money >= 100){
					// беру следующую букву
					string chr = U._LEVELS_ANSWER[U.current_level-1][U.What_button_Enter].ToString().ToUpper();
					
					GameObject go;

					// ищю букву и удаляю ее из списка (клавы)
					for(int i = 0; i < U._ENTER_CHARS.transform.childCount; i++ ){

						go = U._ENTER_CHARS.transform.GetChild (i).gameObject;

						if(go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper() == chr && !go.GetComponent<ClickChar>().destroyed){
							go.GetComponent<ClickChar>().TheClick_add_and_edit();
							// отнимаю 100 монет
							U.PP_Money -= 100;
							break;
						}
					}
				}
				break;
			case TheButton_add_sub.charSub:
				if(U.PP_Money >= 100){
	
					GameObject go;
	
					for(int i = 0; i < U._ENTER_CHARS.transform.childCount; i++ ){
	
						go = U._ENTER_CHARS.transform.GetChild (i).gameObject;
	
						int a = U._LEVELS_ANSWER[U.current_level-1].ToString().ToUpper().IndexOf(go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper());
						
						if(a == -1 && old != go && go.GetComponent<ClickChar>().destroyed == false){
							go.GetComponent<ClickChar>().Destroy_the();
							U.PP_Money -= 100;
							old = go;
							break;
						}
					}
				}
				break;
		}
	}
}

public enum TheButton_add_sub {
	charAdd,
	charSub
}