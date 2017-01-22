using UnityEngine;
using System.Collections;

// строим поля с буквами
public class BuildFieldAndChar : MonoBehaviour {
	
	// координаты полей по Y
	private float   _FIELD_ANSWER_CHARS_COORD_Y = -1.32f;
	// координаты полей по X
	private float[] _FIELD_ANSWER_CHARS_COORD_X_3 = new float[] { -1f, 0f, 1f };
	private float[] _FIELD_ANSWER_CHARS_COORD_X_4 = new float[] { -1.51f, -0.51f, 0.49f, 1.49f };
	private float[] _FIELD_ANSWER_CHARS_COORD_X_5 = new float[] { -1.67f, -0.84f, -0.01f, 0.82f, 1.65f };
	private float[] _FIELD_ANSWER_CHARS_COORD_X_6 = new float[] { -2.08f, -1.25f, -0.42f, 0.41f, 1.24f, 2.09f };
	private float[] _FIELD_ANSWER_CHARS_COORD_X_7 = new float[] { -2.04f, -1.36f, -0.68f, 0f, 0.68f, 1.36f, 2.04f };
	private float[] _FIELD_ANSWER_CHARS_COORD_X_8 = new float[] { -2.4f, -1.72f, -1.04f, -0.36f, 0.32f, 1f, 1.68f, 2.38f };

	// координаты букв 
	private float[] _ENTER_CHARS_COORD_Y = new float[] { -3.9f, -4.6f };
	private float[] _ENTER_CHARS_COORD_X = new float[] { -2.443335f, -1.746668f, -1.050001f, -0.3533344f, 0.3433323f, 1.039999f, 1.736666f };

	void Start () {
	}
	
	void Update () {
		if(U.GAME_STARTED == 1){
			// передаем эстафету дальше
			U.GAME_STARTED = 2;
			// строим поля для ввода ответа
			SetFieldAnswerChars();
			SetChars();
		}
	}

	void SetFieldAnswerChars (){

		// удаляем обьекты предыдущего уровня, если они есть
		foreach(GameObject go in U._FIELD_ANSWER_CHARS){
			Destroy(go);
		}

		// получаем колличество символов ответа
		int len_word = U._LEVELS_ANSWER[U.current_level-1].Length;

		// исходя из длины ответа выбираем координаты обьектов куда будет прописаться ответ
		float[] _FIELD_ANSWER_CHARS_COORD = (len_word == 3) ? _FIELD_ANSWER_CHARS_COORD_X_3 :
											(len_word == 4) ? _FIELD_ANSWER_CHARS_COORD_X_4 :  
											(len_word == 5) ? _FIELD_ANSWER_CHARS_COORD_X_5 :  
											(len_word == 6) ? _FIELD_ANSWER_CHARS_COORD_X_6 :  
											(len_word == 7) ? _FIELD_ANSWER_CHARS_COORD_X_7 :  
											(len_word == 8) ? _FIELD_ANSWER_CHARS_COORD_X_8 : 
											null;

		int i = 0;
		// получем поле для отображения введенного символа 
		GameObject entr = Resources.Load<GameObject>("field_answer_char");
		// создаем поля 
		foreach(float x in _FIELD_ANSWER_CHARS_COORD){
			// координаты нахождения поля
			Vector3 crd = new Vector3(x,_FIELD_ANSWER_CHARS_COORD_Y,0); 
			// создание обьекта
			GameObject go = Instantiate(entr,crd,Quaternion.identity) as GameObject;
			// присвоение обьекту родителя
			go.transform.SetParent (U.TheLevel.transform);
			// запись обьекта в глобальный массив
			U._FIELD_ANSWER_CHARS[i] = go;
			
			i++;
		}
	}

	void SetChars () {

		int i = 0;
		// получем обьекты буквы 
		GameObject entr = Resources.Load<GameObject>("enter_char");
		
		// создаем буквы
		for(int j = 0; j < 2; j++){
			foreach(float x in _ENTER_CHARS_COORD_X){
				// координаты нахождения буквы
				Vector3 crd = new Vector3(x,_ENTER_CHARS_COORD_Y[j],-0.01f);
				// создание обьекта
				GameObject go = Instantiate(entr,crd,Quaternion.identity) as GameObject;
				// получаем дочерний обьект буквы в виде текста 
				TextMesh TheChar = go.GetComponentInChildren<TextMesh>();
				// изменяем символ
				TheChar.text = U._LEVELS_CHARS[U.current_level-1][i].ToString().ToUpper();
				// запись обьекта в глобальный массив
				U._ENTER_CHARS[i] = go;
				
				i++;
			}
		}
	}
}
