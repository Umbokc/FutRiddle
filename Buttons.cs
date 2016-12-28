using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	public TheButton theButton;

	private float speed = 4f; 

	private Animation animSetting;
	private Animation animLand;

	void Start(){
		animSetting = U.Settings.GetComponent<Animation>();
		animLand = U.Germany_main.GetComponent<Animation>();
	}

	void Update(){

	}

	void OnMouseDown(){
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
		switch (theButton){
			case TheButton.SelecLevel: break;
			case TheButton.ToSetting:
				if (!animSetting["ToDown"].enabled){
					ToSettingAndBack(animSetting);
					ToSettingAndBack(animLand);
					U.Settings_active = !U.Settings_active;
				}
				break;
			case TheButton.FreeCoins: break;
			case TheButton.leaderboard: break;
			case TheButton.sound: break;
			case TheButton.about: break;
			case TheButton.contacts: break;
		}
	}

	void ToSettingAndBack(Animation anim) {

		anim["ToDown"].time = U.Settings_active ? anim["ToDown"].length : 0;
		anim["ToDown"].speed = U.Settings_active ? -1 : 1;

		anim.Play ("ToDown");
	}
}

public enum TheButton {
	SelecLevel,
	ToSetting,
	FreeCoins,
	leaderboard,
	sound,
	about,
	contacts
}