using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// строим уровень
public class BuildLevel : MonoBehaviour {
	
	public Image bg_level;
	public GameObject bg_change;
	public GameObject riddleimg;
	public GameObject Level_text;
	public GameObject Answer;
	public GameObject EnterChars;
	public GameObject Riddle_block;
	
	public GameObject Next_btn;
	public GameObject Back_btn;

	void Start () {
	}
	
	void Update () {
		if(U.GAME_STATUS == 1){
			
			// Level_text.text = "LEVEL " + U.current_level.ToString() + "/30";

			// Фон
			SetBg();

			riddleimg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("levels/"+ U.Global_Level.ToString() +"/uroven-"+ U.current_level.ToString());
			
			// строим поля для ввода ответа
			SetFieldAnswerChars();

			// клава
			SetChars();

			// передаем эстафету дальше
			U.GAME_STATUS = 2;
		}
		if(U.GAME_STATUS == 5){
			Retry_lelvel();
			U.GAME_STATUS  = 0;
		}
	}

	void SetFieldAnswerChars (){

		// удаляем обьекты предыдущего уровня, если они есть
		for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.childCount; k++ ){
			U._FIELD_ANSWER_CHARS.transform.GetChild (k).gameObject.SetActive(false);
		}

		// получаем колличество символов ответа
		int len_word = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].Length;

		bool[] how_btn = new bool[len_word];
		
		for(int ki = 0; ki < len_word; ki++) how_btn[ki] = false;

		U.HOW_BUTTONS_DONE = how_btn;

		U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.SetActive(true);
		for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.childCount; k++ ){
			U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.GetChild (k).gameObject.GetComponentInChildren<TextMesh>().text = "";
		}

		// if(!U.PreviewField)
			// U.Allow_click_field = true;
	}

	void SetChars () {
		for(int k = 0; k < U._ENTER_CHARS.transform.childCount; k++ ){
			GameObject TheChar = U._ENTER_CHARS.transform.GetChild (k).gameObject;
			TheChar.GetComponentInChildren<TextMesh>().text =  U._LEVELS_CHARS[U.Global_Level-1,U.current_level-1][k].ToString().ToUpper();
			
			ClickChar TheChar_click = TheChar.GetComponentInChildren<ClickChar>();

			if(TheChar.transform.position.y != TheChar_click.the_tp.y && 0 != TheChar_click.the_tp.y){
				TheChar_click.Restart_the_fast();
				// U.tp_to(TheChar, 999, TheChar_click.the_tp.y, TheChar_click.the_tp.z);
			}
		}
	}

	void SetBg(){
		bg_change.GetComponent<Image>().sprite = Resources.Load<Sprite>("levels/"+ U.Global_Level.ToString() + "/bg");
		bg_change.SetActive(true);
		bg_change.GetComponent<Animation>().Play("Change_bg");
		Invoke("End_SetBg", 0.6f);
	}

	void End_SetBg(){
		bg_change.SetActive(false);
		bg_level.sprite = Resources.Load<Sprite>("levels/"+ U.Global_Level.ToString() + "/bg");
	}

	void Retry_lelvel(){

		U.current_level = U.PP_Level;
		
		// 
		Riddle_block.GetComponent<Animation>().Play("ToNextLevel");

		// Level_text.text = "LEVEL " + U.current_level.ToString() + "/30";
		
		riddleimg.SetActive(true);
		Answer.SetActive(false);

		riddleimg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("levels/"+ U.Global_Level.ToString() +"/uroven-"+ U.current_level.ToString());
		
		// строим поля для ввода ответа
		SetFieldAnswerChars ();

		U.tp_to(U._FIELD_ANSWER_CHARS, 999, 0);

		// клава
		SetChars();
		EnterChars.SetActive(true);

		U.Level.GetComponent<Animation>().Play("ToNextLevel_2");
		
		// передаем эстафету дальше
		U.GAME_STATUS = 3;

		U.tp_to(Next_btn, 3.829f);
		U.tp_to(Back_btn, -3.829f);

	}

	public void PrintFloat (float theValue) {
    Debug.Log ("PrintFloat is called with a value of " + theValue);
	}

}
