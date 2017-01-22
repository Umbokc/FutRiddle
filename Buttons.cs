using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	public TheButton theButton;

	private float speed = 4f; 

	private Animation animSetting;
	private Animation animLand;
	private Animation animLevel;
	private Animation animLevelAnswer;

	void Start(){
		animSetting = U.Settings.GetComponent<Animation>();
		animLand = U.Main_scene.GetComponent<Animation>();
		animLevel = U.TheLevel.GetComponent<Animation>();
		animLevelAnswer = U.Answer.GetComponent<Animation>();
	}

	void Update(){
	}

	void OnMouseDown(){
		if((theButton == TheButton.back && !U.Button_Back_Active) || (theButton == TheButton.next && !U.Button_Next_Active))
			return;
		else
			transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		if((theButton == TheButton.back && !U.Button_Back_Active) || (theButton == TheButton.next && !U.Button_Next_Active))
			return;
		else
			transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
		switch (theButton){
			// нажатие на SelecLevel
			case TheButton.SelecLevel: 
				// обработка свайпов для изменения страны 
				U.UISwipe.SetActive (false);

				// главное меню
				U.Main_scene.SetActive (false);
				// начало игры
				U.LevelAllObj.SetActive (true);
				// загадка
				U.TheLevel.SetActive (true);
				// ответ (видны только пройденные)
				U.Answer.SetActive (false);
				// вопросительный знак в ответах (тех которые еще не пройденные)
				U.TheQuestionMark.SetActive (false);
				
				U.GAME_STARTED = 1;

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
					else if (U.Answer.active)
						ToSettingAndBack(animLevelAnswer);
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
			case TheButton.next:
				if(U.Button_Next_Active){
					U.MoveLevel_next = true;
				}
				break;
			case TheButton.back:
				if(U.Button_Back_Active){
					U.MoveLevel_back = true;
				}
				break;
			case TheButton.startGame:
				U.Answer.SetActive (false);
				U.TheQuestionMark.SetActive (false);

				U.TheLevel.SetActive (true);

				// U.RiddleSprite.GetComponent<SpriteRenderer>().sprite = U.LevelsImg[U.current_level];
				U.RiddleSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("levels/Uroven-" + U.current_level);
				U.GAME_STARTED = 1;

				break;
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
	back,
	startGame
}