using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

using System.Collections.Generic;
using System.Linq;

public class U : MonoBehaviour {

	public GameObject _Main_scene;
	public static GameObject Main_scene;
	
	// the settings elements
	public GameObject _Settings;
	public static GameObject Settings;
	// if settings is active then 'true'
	public static bool Settings_active = false;

	// The current coutry
	public static int current_country = 1;

	// Level and other objetc
	public GameObject _LevelAllObj;
	public static GameObject LevelAllObj;

	// the level
	public GameObject _TheLevel;
	public static GameObject TheLevel;

	// the answer
	public GameObject _Answer;
	public static GameObject Answer;
	// the answer img
	public GameObject _AnswerImg;
	public static GameObject AnswerImg;
	
	// the sprite of riddle
	public GameObject _RiddleSprite;
	public static GameObject RiddleSprite;

	// the swipe for select countries
	public GameObject _UISwipe;
	public static GameObject UISwipe;

	public static bool WHILE_TRUE_ANSWER = true;

	public static bool[] HOW_BUTTONS_DONE;

	// -1 - идет игра
	// 	0 - начальный режим
	//  1 - строим поля для ввода ответа, строим нужные для уровня буквы и прописываем вних символы (BuildFieldAndChar)
	public static int GAME_STARTED = -1;

	public static bool Button_Next_Active = true;
	public static bool Button_Back_Active = true;

	public static bool MoveLevel_back = false;
	public static bool MoveLevel_next = false;

	public static int[] opened_levels;

	public static int PP_Money {
		set { 
			PlayerPrefs.SetInt("Money",value);
			Money_set.set_money = true; 
		}
		get { return PlayerPrefs.GetInt("Money"); } 
	}

	public static int PP_Level {
		set { PlayerPrefs.SetInt("Level", value); }
		get { return PlayerPrefs.GetInt("Level"); } 
	}

	public static string PP_Levels {
		set { PlayerPrefs.SetString("Levels", value); }
		get { return PlayerPrefs.GetString("Levels"); } 
	}

	public static int current_level;

	public static string[] _LEVELS_ANSWER = new string[] {
		"pogba", 	"coutinho", "mahrez", 	"payet", 	"shaqiri",
		"silva", 	"hazard", 	"benteke", 	"son", 		"mane",
		"wilshere", "fonte", 	"williams", "negredo", 	"terry",
		"foster", 	"aguero", 	"morgan", 	"ozil", 	"rojo",
		"deeney", 	"kone", 	"luiz", 	"allen", 	"eriksen"
	};

	public static string[] _LEVELS_CHARS = new string[] {
		"xfompajigckvby", "bjitohcnfmgkuo", "ornzmigfuacehj", "cgranephmyojtf", "nfhmyipasiqter",
		"vlnertspamfihi", "narfapdziisehd", "nmfhneqakeytbe", "imfgapnhicyosv", "kngfohmijtcnae",
		"elgfcitkrwsmhe", "mgpoevkcnxyjtf", "gwcheimtliksla", "gheqydepnirioa", "tfcrroypgjnekx",
		"spnhoerdfatiai", "eoprnasiaogfuh", "mouohraaisgfpn", "jfnlnzchktmgoi", "rtlikhgconfomj",
		"hpesydainafeeg", "ilnoeknfgjtmcz", "jnltkzonuifzgc", "eohaskdnpriiey", "ophastdnirella"
	};

	// какая по счету была нажата буква
	public static int What_button_Enter = 0;

	public GameObject ENTER_CHARS;
	public static GameObject _ENTER_CHARS;

	public GameObject FIELD_ANSWER_CHARS;
	public static GameObject _FIELD_ANSWER_CHARS;

	void Awake () {
		// crete static variable
		Main_scene = _Main_scene;
		Settings = _Settings;

		LevelAllObj = _LevelAllObj;
		TheLevel = _TheLevel;
		Answer = _Answer;
		AnswerImg = _AnswerImg;
		RiddleSprite = _RiddleSprite;

		UISwipe = _UISwipe;

		_ENTER_CHARS = ENTER_CHARS;
		_FIELD_ANSWER_CHARS = FIELD_ANSWER_CHARS;

		int Reset = 1;
 
		if(Reset == 1){
			PlayerPrefs_reset();
		} else {
			PlayerPrefs_continue();
		}

		current_level = PP_Level;
		// Debug.Log(PP_Level);
		
		// Debug.Log(PP_Levels);

		opened_levels = StringToArr(PP_Levels);

	}

	public static string ArrToStringUniq(int[] x){

		int[] nx = UniqItem(x);
		
		string s = "";

		for(int l = 0; l < nx.Length; l++){
			if(nx[l] == 0) continue;

			if(l == nx.Length-1)
				s += nx[l].ToString();
			else
				s += (nx[l].ToString() + ",");
		}

		return s;
	}

	public static int[] StringToArr(string s, int add_new=0){

		int size = (s.Length+1)/2;

		size += 1;

		int[] x = new int[size];

		if (s.Length > 1){

			string[] substrings = s.Split(',');
			int i = 0;
			foreach (var substring in substrings) {
				int.TryParse (substring, out x[i]);
				i++;
			}

		} else if (s.Length == 1) {

			int.TryParse (s, out x[0]);

		} 
		if(add_new != 0) {
			x[x.Length-1] = add_new;
		}

		int[] nx = UniqItem(x);
		
		return nx;
	}

	private void PlayerPrefs_reset(){
		PlayerPrefs.SetInt("Money", 3000);
		PlayerPrefs.SetInt("Level", 1);
		PlayerPrefs.SetString("Levels","");
	}

	private void PlayerPrefs_continue(){
		PP_Money = (PP_Money == null) ? 200 : PP_Money;
		PP_Level = (PP_Level == null) ? 1 : PP_Level;
		PP_Levels = (PP_Levels == null) ? "" : PP_Levels;
	}

	public static void LoadScene (string w){
		SceneManager.LoadScene (w);
	}

	public static int[] UniqItem(int[] x){
		int temp;
		
		for (int i = 0; i < x.Length; i++)
			for (int j = i + 1; j < x.Length; j++)
				if (x[i] > x[j]) {
					temp = x[i];
					x[i] = x[j];
					x[j] = temp;
				}
				
		int[] nx = x.Distinct().ToArray();

		return nx;
	}
}

public class ClickButton : MonoBehaviour{

	public void OnMouseDown(){
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	public void OnMouseUp(){
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

}