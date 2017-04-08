using System;
using UnityEngine;
using System.Linq;
using System.Collections;
using Random = System.Random;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class U : MonoBehaviour {

	public GameObject _Level; 	public static GameObject Level;
	public GameObject _Land; 			public static GameObject Land;
	public GameObject _Settings; 	public static GameObject Settings;

	// 1 - начало постройки уровня
	// 2 - уровень построен, запуск показа уровня
	// 3 - идет игра
	// 4 - уровень пройден
	// 5 - начало сдедующего уровня
	public static int GAME_STATUS = 0;

	public static bool[] HOW_BUTTONS_DONE;

	public static int current_level = 1;
	
	public static bool check_char = false;

	public static bool NextLevel_btn = false;


	public static string[,] _LEVELS_ANSWER = new string[,] {
		{
			"pogba", "coutinho", "mahrez", "payet", "shaqiri", "silva", "hazard", "benteke", "son", "mane", "wilshere", "fonte", "williams", "negredo", "terry", "foster", "aguero", "morgan", "ozil", "rojo", "deeney", "kone", "luiz", "eriksen", "allen", "sanchez", "coleman", "keane", "vardy", "gueye"
		},
		{
			"neuer", "reus", "leno", "keita", "toprak", "naldo", "bruma", "modeste","werner", "roger", "hazard", "ntep", "kostic", "kruse", "weigl", "aranguiz", "sanches","bailey", "pulisic", "lahm", "vogt", "gomez", "brooks", "bentaleb", "hasebe", "hector", "stindl", "gnabry", "robben", "dembele"
		},
		{
			"ronaldo", "neymar", "godin", "iborra", "carrasco", "rulli", "bruno", "fajr", "kroos", "nasri", "gabi", "orellana", "kameni", "boateng", "iniesta", "vietto", "zurutuza", "susaeta", "messi", "caicedo", "sansone", "bale", "torres", "isco", "aduriz", "mallo", "aspas", "benzema", "thomas", "suarez"
		}
	};

	public static string[,] _LEVELS_CHARS = new string[,] {
		{
			"xfompajigckvby", "bjitohcnfmgkuo", "ornzmigfuacehj", "cgranephmyojtf", "nfhmyipasiqter", "vlnertspamfihi", "narfapdziisehd",
			"nmfhneqakeytbe", "imfgapnhicyosv", "kngfohmijtcnae", "elgfcitkrwsmhe", "mgpoevkcnxyjtf", "gwcheimtliksla", "gheqydepnirioa",
			"tfcrroypgjnekx", "spnhoerdfatiai", "eoprnasiaogfuh", "mouohraaisgfpn", "jfnlnzchktmgoi", "rtlikhgconfomj", "hpesydainafeeg",
			"ilnoeknfgjtmcz", "jnltkzonuifzgc", "eohaskdnpriiey", "ophastdnirella", "iaerhpczqsnyio", "naolhcetqebyjm", "jkvkptxnaoeyer",
			"iaarvphoaenyld", "caolhpugeenycr"
		},
		{
			"nkfupexbgoryce", "jsfthunaronecm", "lsfthunaronecm", "okiuptxbgarece", "ifaosptraendkd", "nklupaxbgorycd", "okiuptxbcareme",
			"madshpetqenyio", "inaosrtraenwke", "okirpgxbcareme", "ifaosphraendzd", "isfthpnaronecm", "wnaosctraenike", "skirpgubcareme",
			"lkiupwxbgarece", "jkfraiozgonuca", "amdshcetmenyis", "ieaospbralndzy", "acdspletieuyis", "nsfthejarolpcm", "fsgthpnaronvcm",
			"gkirpgubmazeqe", "bnaoecsraeniko", "bkeriboltonega", "ieaosperabndzh", "tnaoechrmeniko", "mnalsctrdenike", "ieaospgyrbndzw",
			"tnaoecernebikb", "lmdshbetoeneis"
		},
		{
			"ralohdetqenyio", "nnaoscykameire", "ikdupexsnorycg", "ieadaprbslrozi", "chcraiozsonura", "oriupgxlcraeml", "nelupbxanorycq",
			"cdjrhunatonefm", "griopgusvakeoe", "osxgpuincraema", "esgthbnaroleci", "oaithiesrlnlca", "ikaoscmlaendrd", "agdbhctemenyio",
			"sydnictireayih", "ftaoscvkateicr", "uaithiusrunzcz", "sauohaetgenyis", "irghptusvaseme", "wlechacdmenyio", "andsnletoeuyis",
			"enbthanauoleci", "btarsctraoeicr", "shgthimarozvcn", "izawsculjendrd", "imghotllvaudre", "iadopelsnusyca", "andonlezoebyim",
			"keadhpmosltozi", "znaoecsraeuikn"
		}
	};

	// какая по счету была нажата буква
	public static int What_button_Enter = 0;

	public static int[] opened_levels;

	// The current land
	public static int global_level = 1;
	
	public static int Global_Level {
		set { PlayerPrefs.SetInt("GlobalLevel", value); }
		get { return PlayerPrefs.GetInt("GlobalLevel"); } 
	}

	public static int PP_Money {
		set { 
			PlayerPrefs.SetInt("Money",value);
			MoneySet.set_money = true; 
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

	public static bool Settings_active = false;


	public GameObject ENTER_CHARS;
	public static GameObject _ENTER_CHARS;

	public GameObject FIELD_ANSWER_CHARS;
	public static GameObject _FIELD_ANSWER_CHARS;
	void Awake () {
		Level = _Level;
		Land = _Land;
		Settings = _Settings;
	
		_ENTER_CHARS = ENTER_CHARS;
		_FIELD_ANSWER_CHARS = FIELD_ANSWER_CHARS;
	
		PlayerPrefs_reset();
		// PlayerPrefs_continue();


		current_level = PP_Level;
		opened_levels = StringToArr(PP_Levels);
	}

	// void Update(){Debug.Log(GAME_STATUS);}

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

		if (s.Length == 0 && add_new == 0) {
			x[0] = 0;
			return x;
		} 


		if(add_new != 0) {
			x[x.Length-1] = add_new;
		}

		int[] nx = UniqItem(x);
		
		return nx;
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

	private void PlayerPrefs_reset(){
		PP_Money = 3000;
		PP_Level = 1;
		Global_Level = 1;
		PP_Levels = "";
	}

	private void PlayerPrefs_continue(){
		PP_Money = 			(PP_Money == null) 			? 200 : PP_Money;
		PP_Level = 			(PP_Level == null) 			? 1 	: PP_Level;
		Global_Level = 	(Global_Level == null) 	? 1 	: Global_Level;
		PP_Levels = 		(PP_Levels == null) 		? "" 	: PP_Levels;
	}

	public static float Wait_For_Seconds = 0.03f;
	public const float __EPSILON = 0.0001f;

	public static IEnumerator Down(Transform obj, float distance, float speed = 0.2f, Action act = null) {
		
		float yend = obj.position.y - distance;

		while ((obj.position.y - yend) > __EPSILON) {
			Vector3 v = obj.position;
			v.y -= speed;
			obj.position = v;
			yield return new WaitForSeconds(Wait_For_Seconds);
		}
		
		Vector3 vend = obj.position;
		vend.y = yend;
		obj.position = vend;
		
		if(act != null)
			act();
	}

	public static IEnumerator Up(Transform obj, float distance, float speed = 0.2f, Action act = null) {
		float ystart = obj.position.y;
		float yend = ystart + distance;

		while ((yend - obj.position.y) > __EPSILON) {
			Vector3 v = obj.position;
			v.y += speed;
			obj.position = v;
			yield return new WaitForSeconds(Wait_For_Seconds);
		}

		Vector3 vend = obj.position;
		vend.y = yend;
		obj.position = vend;
		
		if(act != null)
			act();
	}

	public static IEnumerator Left(Transform obj, float distance, float speed = 0.2f, Action act = null) {
		
		float yend = obj.position.x - distance;

		while ((obj.position.x - yend) > __EPSILON) {
			Vector3 v = obj.position;
			v.x -= speed;
			obj.position = v;
			yield return new WaitForSeconds(Wait_For_Seconds);
		}
		
		Vector3 vend = obj.position;
		vend.x = yend;
		obj.position = vend;
		
		if(act != null)
			act();
	}

	public static IEnumerator Right(Transform obj, float distance, float speed = 0.2f, Action act = null) {
		float ystart = obj.position.x;
		float yend = ystart + distance;

		while ((yend - obj.position.x) > __EPSILON) {
			Vector3 v = obj.position;
			v.x += speed;
			obj.position = v;
			yield return new WaitForSeconds(Wait_For_Seconds);
		}

		Vector3 vend = obj.position;
		vend.x = yend;
		obj.position = vend;
		
		if(act != null)
			act();
	}

	public static void tp_to(GameObject go, float x = 999, float y = 999, float z = 999){
		
		Vector3 t = go.transform.position;
		
		if(x == 999) x = t.x; else t.x = x;
		if(y == 999) y = t.y; else t.y = y;
		if(z == 999) z = t.z; else t.z = z;

		go.transform.position = t;
	}

	public static void Anim_go(Animation anim, string name, bool b = true) {

		anim[name].time = b ? 0 : anim[name].length;
		anim[name].speed = b ? 1 : -1;

		anim.Play (name);
	}

}
