using UnityEngine;
using System.Collections;

public class EnterChars : MonoBehaviour {
	

	private float   _ENTER_CHARS_COORDINATE_Y = -1.32f;
	private float[] _ENTER_CHARS_COORDINATE_X_3 = new float[] { -1f, 0f, 1f };
	private float[] _ENTER_CHARS_COORDINATE_X_4 = new float[] { -1.51f, -0.51f, 0.49f, 1.49f };
	private float[] _ENTER_CHARS_COORDINATE_X_5 = new float[] { -1.67f, -0.84f, -0.01f, 0.82f, 1.65f };
	private float[] _ENTER_CHARS_COORDINATE_X_6 = new float[] { -2.08f, -1.25f, -0.42f, 0.41f, 1.24f, 2.09f };
	private float[] _ENTER_CHARS_COORDINATE_X_7 = new float[] { -2.04f, -1.36f, -0.68f, 0f, 0.68f, 1.36f, 2.04f };
	private float[] _ENTER_CHARS_COORDINATE_X_8 = new float[] { -2.4f, -1.72f, -1.04f, -0.36f, 0.32f, 1f, 1.68f, 2.38f };


	void Start () {

		int len_word = U._LEVELS_ANSWER[U.Level-1].Length;

		float[] _ENTER_CHARS_COORDINATE =   (len_word == 3) ? _ENTER_CHARS_COORDINATE_X_3 :
											(len_word == 4) ? _ENTER_CHARS_COORDINATE_X_4 :  
											(len_word == 5) ? _ENTER_CHARS_COORDINATE_X_5 :  
											(len_word == 6) ? _ENTER_CHARS_COORDINATE_X_6 :  
											(len_word == 7) ? _ENTER_CHARS_COORDINATE_X_7 :  
											(len_word == 8) ? _ENTER_CHARS_COORDINATE_X_8 : 
											null;  

		int i = 0;

		foreach(float x in _ENTER_CHARS_COORDINATE){
			GameObject entr= Resources.Load<GameObject>("char_enter");
			Vector3 crd = new Vector3(x,_ENTER_CHARS_COORDINATE_Y,0); 
			// U._ENTER_CHARS[i] = Instantiate(entr,crd,Quaternion.identity) as GameObject;
			GameObject go = Instantiate(entr,crd,Quaternion.identity) as GameObject;
			U._ENTER_CHARS[i] = go;
			i++;
		}
	}
	
	void Update () {
			
	}
}
