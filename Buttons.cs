using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	public TheButton theButton;

	private float speed = 4f; 

	private Animation animSetting;
	private Animation animLand;
	private Animation animLevel;

	void Start(){
		animSetting = U.Settings.GetComponent<Animation>();
		animLand = U.Land_main.GetComponent<Animation>();
		animLevel = U.TheLevel.GetComponent<Animation>();
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
			case TheButton.SelecLevel: 
				U.UISwipe.SetActive (false);
				U.Land_main.SetActive (false);
				U.LevelAllObj.SetActive (true);
				U.TheLevel.SetActive (false);
				U.Answer.SetActive (true);
				U.AnswerImg.transform.GetChild (0).gameObject.SetActive (true);
				break;
			case TheButton.ToSetting:
				if (!animSetting["ToDown"].enabled){
					
					U.Settings_active = !U.Settings_active;

					if (U.Settings_active)
						U.UISwipe.SetActive (false);
					else 
						U.UISwipe.SetActive (true);

					ToSettingAndBack(animSetting);

					if (U.TheLevel.active)
						ToSettingAndBack(animLevel);
					else
						ToSettingAndBack(animLand);
				}
				break;
			case TheButton.FreeCoins: 
				U.Money = U.Money + 20;
				break;
			case TheButton.leaderboard: break;
			case TheButton.sound: break;
			case TheButton.about: break;
			case TheButton.contacts: break;
		}
	}

	void ToSettingAndBack(Animation anim) {
		anim["ToDown"].time = U.Settings_active ? 0 : anim["ToDown"].length;
		anim["ToDown"].speed = U.Settings_active ? 1 : -1;

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
	contacts,
	next,
	back
}