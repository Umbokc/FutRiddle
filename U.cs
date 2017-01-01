using UnityEngine;
using System.Collections;

public class U : MonoBehaviour {

	public GameObject _Land_main;
	public static GameObject Land_main;
	
	// the settings elements
	public GameObject _Settings;
	public static GameObject Settings;
	// if settings is active then 'true'
	public static bool Settings_active = false;

	public GameObject[] _lands = new GameObject[3];
	public static GameObject[] lands;
	// The current coutry
	public static int current = 0;

	// Level and other objetc
	public GameObject _LevelAllObj;
	public static GameObject LevelAllObj;

	// the level
	public GameObject _TheLevel;
	public static GameObject TheLevel;
	// the sprite of riddle
	public GameObject _RiddleSprite;
	public static GameObject RiddleSprite;

	// the swipe area
	public GameObject _UISwipe;
	public static GameObject UISwipe;

	public static bool WHILE_TRUE_ANSWER = true;

	public static bool GAME_STARTED = true;


	void Awake () {
		Land_main = _Land_main;
		Settings = _Settings;
		lands = _lands;

		LevelAllObj = _LevelAllObj;
		TheLevel = _TheLevel;
		RiddleSprite = _RiddleSprite;

		UISwipe = _UISwipe;

		PlayerPrefs.SetInt("Money", 200);
		// PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") == null ? 200 : PlayerPrefs.GetInt("Money"));
		PlayerPrefs.SetInt("Level", 1);
		// PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level") == null ? 1 : PlayerPrefs.GetInt("Level"));
	}

	public static int Money {
		set { Money_set.SetMoney(value); }
		get { return PlayerPrefs.GetInt("Money"); } 
	}

	public static int Level {
		// set { Money_set.SetMoney(value); }
		get { return PlayerPrefs.GetInt("Level"); } 
	}

	public static string[] _LEVELS_ANSWER = new string[] {
											"pogba",
											"coutinho",
											"payet",
											"mahrez",
											"shaqiri",
											"silva",
											"hazard",
											"benteke",
											"son",
											"mane",
											"wilshere",
											"fonte",
											"williams",
											"negredo",
											"terry",
											"foster",
											"aguero",
											"morgan",
											"ozil",
											"rojo",
											"deeney",
											"kone",
											"luiz",
											"allen",
											"eriksen"
	};

	public static string[] _LEVELS_CHARS = new string[] {
										"JKVFPIXBGOAYCM",
										"JKFTHIOBGONUCM",
										"JAFRHIOZGENUCM",
										"JAFRHPOTGENYCM",
										"IAFRHPSTQENYIM"
	};

	public static int What_button_Enter = 0;

	public static GameObject[] _ENTER_CHARS = new GameObject[8];

}