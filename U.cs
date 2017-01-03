﻿using UnityEngine;
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
	public static int current_land = 0;

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

	// the swipe for select levels
	public GameObject _UISwipeLevel;
	public static GameObject UISwipeLevel;

	// all levels img
	public Sprite[] _LevelsImg = new Sprite[25];
	public static Sprite[] LevelsImg;

	// all levels img answer
	public Sprite[] _LevelsImgAnsw = new Sprite[25];
	public static Sprite[] LevelsImgAnsw;

	public static bool WHILE_TRUE_ANSWER = true;

	public static bool GAME_STARTED = true;


	public static int Money {
		set { Money_set.SetMoney(value); }
		get { return PlayerPrefs.GetInt("Money"); } 
	}

	public static int Level {
		// set { Money_set.SetMoney(value); }
		get { return PlayerPrefs.GetInt("Level"); } 
	}
	public static int current_level = 1;

	public static string[] _LEVELS_ANSWER = new string[] {
		"pogba", 	"coutinho", "payet", 	"mahrez", 	"shaqiri",
		"silva", 	"hazard", 	"benteke", 	"son", 		"mane",
		"wilshere", "fonte", 	"williams", "negredo", 	"terry",
		"foster", 	"aguero", 	"morgan", 	"ozil", 	"rojo",
		"deeney", 	"kone", 	"luiz", 	"allen", 	"eriksen"
	};

	// public static string[] _LEVELS_CHARS = new string[] {
	// 	"JKVFPIXBGOAYCM", "JKFTHIOBGONUCM", "JAFRHIOZGENUCM", "JAFRHPOTGENYCM", "IAFRHPSTQENYIM",
	// 	"IFARSPHTLENVIM", "IFARSPHZAENDID", "BAFNHKETQENYEM", "IHFVPINSGOAYCM", "JKFTHINAGONECM",
	// 	"RKFTHIESGEWLCM", "JKFVPTXNGOEYCM", "AKITHIESGLWLCM", "IADRHPEGQENYIO", "JKFRPTXNGOEYCR",
	// 	"IFARSPHOAENTID", "UFARSPHOAENGIO", "UFARSAHOPMNGIO", "JKFTHINLGONZCM", "JKFTHINLGOORCM",
	// 	"YFAESAHEPDNGIE", "JKFTEINLGONZCM", "JKFTUINLGONZCZ", "IADRHPESKENYIO", "ILARSPHOAENTLD"
	// };

	public static string[] _LEVELS_CHARS = new string[] {
		"xfompajigckvby", "bjitohcnfmgkuo", "ornzmigfuacehj", "cgranephmyojtf", "nfhmyipasiqter",
		"vlnertspamfihi", "narfapdziisehd", "nmfhneqakeytbe", "imfgapnhicyosv", "kngfohmijtcnae",
		"elgfcitkrwsmhe", "mgpoevkcnxyjtf", "gwcheimtliksla", "gheqydepnirioa", "tfcrroypgjnekx",
		"spnhoerdfatiai", "eoprnasiaogfuh", "mouohraaisgfpn", "jfnlnzchktmgoi", "rtlikhgconfomj",
		"hpesydainafeeg", "ilnoeknfgjtmcz", "jnltkzonuifzgc", "eohaskdnpriiey", "ophastdnirella"
	};

	public static int What_button_Enter = 0;

	public static GameObject[] _ENTER_CHARS = new GameObject[8];

	void Awake () {
		// crete static variable
		Land_main = _Land_main;
		Settings = _Settings;
		lands = _lands;

		LevelAllObj = _LevelAllObj;
		TheLevel = _TheLevel;
		Answer = _Answer;
		AnswerImg = _AnswerImg;
		RiddleSprite = _RiddleSprite;

		UISwipe = _UISwipe;
		UISwipeLevel = _UISwipeLevel;

		LevelsImg = _LevelsImg;
		LevelsImgAnsw = _LevelsImgAnsw;


		PlayerPrefs.SetInt("Money", 200);
		// PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") == null ? 200 : PlayerPrefs.GetInt("Money"));
		PlayerPrefs.SetInt("Level", 1);
		// PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level") == null ? 1 : PlayerPrefs.GetInt("Level"));
	}

	void Start (){
		AnswerImg.GetComponent<SpriteRenderer>().sprite = LevelsImgAnsw[current_level-1];
	}
}