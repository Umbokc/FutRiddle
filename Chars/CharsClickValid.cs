using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharsClickValid : MonoBehaviour {

	public GameObject Answer;
	public GameObject Riddle;

	public GameObject Chars;
	public GameObject RiddleSprite;

	private GameObject AnswerImg;
	private GameObject Next_btn;
	private GameObject Back_btn;

	private float[,] _COORDINATE_ANSWER_IMG_X = new float[,] {
		{ 0, 0, -0.23f, -0.32f, 0.29f, -0.31f, 0, 0, 0.18f, -0.25f, -0.43f, 0.16f, -0.34f, -0.34f, -0.34f, 0.45f, 0.09f, -0.45f, 0.03f, -0.45f, 0, 0, 0.4f, 0.23f, 0.23f , 0, 0, 0, 0, 0},
		{ 0, 0, -0.23f, -0.32f, 0.29f, -0.31f, 0, 0, 0.18f, -0.25f, -0.43f, 0.16f, -0.34f, -0.34f, -0.34f, 0.45f, 0.09f, -0.45f, 0.03f, -0.45f, 0, 0, 0.4f, 0.23f, 0.23f , 0, 0, 0, 0, 0},
		{ 0, 0, -0.23f, -0.32f, 0.29f, -0.31f, 0, 0, 0.18f, -0.25f, -0.43f, 0.16f, -0.34f, -0.34f, -0.34f, 0.45f, 0.09f, -0.45f, 0.03f, -0.45f, 0, 0, 0.4f, 0.23f, 0.23f , 0, 0, 0, 0, 0}
	};


	void Start() {
		AnswerImg = Answer.transform.Find("AnswerImg").gameObject;
		Next_btn = Answer.transform.Find("Buttons/next").gameObject;
		Back_btn = Answer.transform.Find("Buttons/back").gameObject;
	}

	void FixedUpdate(){
		if(U.check_char){
			Check_char();
			U.check_char = !U.check_char;
		}
	}

	void Check_char (){

		int how_btn = 0;
		for(int ki = 0; ki < U.HOW_BUTTONS_DONE.Length; ki++) if(U.HOW_BUTTONS_DONE[ki]) how_btn++;

		// получаем колличество символов ответа
		int len_word = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].Length;

		// если была введена последняя буква
		if (how_btn == len_word){
			string answ = "";
			GameObject go; 

			for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.childCount; k++ ){
				go = U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.GetChild (k).gameObject;
				answ += go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper();
			}

			// вызываем функциию в случае правильного ответа
			if(answ == U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].ToString().ToUpper()){
				// Invoke("TrueAnswer", 2);
				TrueAnswer();
			}
		}

		// увеличаваем номер введенного символа 
		U.What_button_Enter++;
	}

	// введен правильный ответ  
	void TrueAnswer (){

		// обнуляем номер введенной буквы
		U.What_button_Enter = -1;

		// включаю ответ
		Answer.SetActive (true);

		// меняю спрайт 
		AnswerImg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("levels/"+ U.Global_Level.ToString() +"/answer/"+ U.current_level.ToString());;

		// показываем ответ, анимация
		// Riddle.GetComponent<Animation>().Play("ShowAnswerToRight_Riddle");
		Answer.GetComponent<Animation>().Play("ShowAnswer_Answer");
		
		// центрирую картинку
		U.tp_to(AnswerImg, _COORDINATE_ANSWER_IMG_X[U.Global_Level-1,U.current_level-1]);

		Riddle.SetActive (false);

		U.Dont_Touch = true;

		Invoke("Dont_Touch", 0.6f);

		// выключаю клаву
		// Chars.SetActive (false);
		// выключаем риддл
		// RiddleSprite.SetActive(false);

		// создаю клон,
		U._FIELD_ANSWER_CHARS_CLONE = Instantiate(U._FIELD_ANSWER_CHARS, U._FIELD_ANSWER_CHARS.transform.position, Quaternion.identity) as GameObject;
		// двигаю его вниз
		StartCoroutine(U.Down(U._FIELD_ANSWER_CHARS_CLONE.transform, 1.5f));
		// даю ему родителя - блок "ответ"
		U._FIELD_ANSWER_CHARS_CLONE.transform.SetParent (Answer.transform);
		
		// переводи в начальный режим 
		U.GAME_STATUS = 4;
		
		// слудующий уровень 
		U.PP_Level = U.current_level+1;

		if(U.PP_Levels == ""){
			// добавляем пройдиный уровень
			U.opened_levels[0] = U.current_level;
		} else {
			// получаем открытые уровни
			U.opened_levels = U.StringToArr(U.PP_Levels,U.current_level);
		}
		// foreach(var a in U.opened_levels) Debug.Log("the "+a);

		// записываем значение в player prefs
		U.PP_Levels = U.ArrToStringUniq(U.opened_levels);
	}

	void Dont_Touch (){
		U.Dont_Touch = false;
	}
}
