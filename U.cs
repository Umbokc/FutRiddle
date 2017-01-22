using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

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

	// -1 - идет игра
	// 	0 - начальный режим
	//  1 - строим поля для ввода ответа, строим нужные для уровня буквы и прописываем вних символы (BuildFieldAndChar)
	public static int GAME_STARTED = -1;

	public static bool Button_Next_Active = true;
	public static bool Button_Back_Active = true;

	public static bool MoveLevel_back = false;
	public static bool MoveLevel_next = false;

	public static int[] opened_levels = new int[25];

	public static int Money {
		set { Money_set.SetMoney(value); }
		get { return PlayerPrefs.GetInt("Money"); } 
	}

	public static int Level {
		set { PlayerPrefs.SetInt("Level", value); }
		get { return PlayerPrefs.GetInt("Level"); } 
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

	public static GameObject[] _ENTER_CHARS = new GameObject[14];
	public static GameObject[] _FIELD_ANSWER_CHARS = new GameObject[8];

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

		PlayerPrefs.SetInt("Money", 200);
		// PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") == null ? 200 : PlayerPrefs.GetInt("Money"));
		PlayerPrefs.SetInt("Level", 1);
		current_level = PlayerPrefs.GetInt("Level");
		// PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level") == null ? 1 : PlayerPrefs.GetInt("Level"));
		PlayerPrefs.SetString("Levels",PlayerPrefs.GetString("Levels") == null ? "" : PlayerPrefs.GetString("Levels"));
		// PlayerPrefs.SetString("Levels","");
		
		string opened_lvls = PlayerPrefs.GetString("Levels");
		if (opened_lvls.Length > 1){

			string[] substrings = opened_lvls.Split(',');
			int i = 0;
			foreach (var substring in substrings) {
				int.TryParse (substring, out opened_levels[i]);
				i++;
			}
		} else if (opened_lvls.Length == 1) {
			int.TryParse (opened_lvls, out opened_levels[0]);
		}
	}

	public static void LoadScene (string w){
		SceneManager.LoadScene (w);
	}

}
