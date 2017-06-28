using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	public TheButton theButton;
	
	public GameObject go_UISwipe;

	private bool to_setting_ok = true;

	void Start(){

	}

	void Update(){
		if(U.GAME_STATUS == 2){
			Start_level();
			U.GAME_STATUS = 3;
		}
	}

	void OnMouseDown(){
		if(theButton == TheButton.SpriteAnswer || !UISwipe.tomove_ok)
			return;
		else
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		if(theButton == TheButton.SpriteAnswer || !UISwipe.tomove_ok)
			return;
		else
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
		if(!UISwipe.tomove_ok || !to_setting_ok || U.Dont_Touch)
			return;

		if(theButton != TheButton.SpriteAnswer)
			Camera.main.GetComponent<AudioSource> ().Play ();
		
		//  начало уровня
		if( theButton == TheButton.SelecLevel &&  U.GAME_STATUS != 1) U.GAME_STATUS = 1;
		// if( theButton == TheButton.SelecLevel) transform.localScale = new Vector3(0.5241089f,0.5241089f,0);
		
		if(theButton == TheButton.ToSetting) ToSetting();

		if( theButton == TheButton.FreeCoins) U.PP_Money += 25;

		if( theButton == TheButton.leaderboard) {Debug.Log("leaderboard"); }
		if( theButton == TheButton.sound) {Debug.Log("sound"); }
		if( theButton == TheButton.about) {Debug.Log("about"); }
		if( theButton == TheButton.contacts) {Debug.Log("contacts"); }

		if( theButton == TheButton.next &&  U.GAME_STATUS != 5) U.GAME_STATUS = 5;
		// if( theButton == TheButton.back) U.BackLevel_btn = true;
		if( theButton == TheButton.back) Retry_game();
	}


	void Start_level(){

		go_UISwipe.SetActive (false);
		
		U.Level.SetActive(true);

		U.Anim_go(U.Level.GetComponent<Animation>(), "ShowLevel_Level", true);
		U.Anim_go(U.Land.GetComponent<Animation>(), "ToRight_Main", true);

	}

	// показ и скрытие настроек
	void ToSetting() {
		
		to_setting_ok = false;
		
		U.Settings_active = !U.Settings_active;

		if(U.Settings_active) U.Settings.SetActive(true);

		
		if(U.GAME_STATUS == 0){
			go_UISwipe.SetActive ((U.Settings_active) ? false : true);
			U.Anim_go(U.Land.GetComponent<Animation>(), "ToRight_Main", (U.Settings_active) ? true : false);
		} else {
			U.Anim_go(U.Level.GetComponent<Animation>(), "ToRight_Level", (U.Settings_active) ? true : false);
		}
		
		U.Anim_go(U.Settings.GetComponent<Animation>(), "Show_Settings", (U.Settings_active) ? true : false);

		if(!U.Settings_active) Invoke("Settings_false", 0.6f);

		Invoke("To_setting_ok_change", 0.6f);
	}

	void To_setting_ok_change(){to_setting_ok = true;}

	void Retry_game() {

	}

	void Settings_false(){
		U.Settings.SetActive(false);
	}

}

public enum TheButton {SelecLevel, ToSetting, FreeCoins, leaderboard, sound, about, contacts, next, back, SpriteAnswer}
