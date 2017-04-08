using UnityEngine;
using System.Collections;

public class ClickChar : MonoBehaviour {

	public bool destroyed = false;
	public Vector3 the_tp;

	private Animation anim_destroy;
	private bool thebool_dest;	


	void Start(){
		anim_destroy = gameObject.GetComponent<Animation>();

		the_tp = transform.position;
	}

	void OnMouseDown(){
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
			Camera.main.GetComponent<AudioSource> ().Play ();
			TheClick();
	}

	public void TheClick(){

		// получаем колличество символов ответа
		int len_word = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].Length;
		
		// если нажатых букв было меньше чем длина ответа то true
		if (U.What_button_Enter < len_word && !destroyed){

			for(int ki = 0; ki < U.HOW_BUTTONS_DONE.Length; ki++){
				if(U.HOW_BUTTONS_DONE[ki]){
					continue;
				} else {
					U.What_button_Enter = ki;
					break;
				}
			}

			// получем символ нажатой буквы
			TextMesh chr = GetComponentInChildren<TextMesh>();
			// добаляем символ в поле для ответа
			U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.GetChild (U.What_button_Enter).gameObject.GetComponentInChildren<TextMesh>().text = chr.text;

			// буква есть
			U.HOW_BUTTONS_DONE[U.What_button_Enter] = true;

			// вызываем проверку символов
			U.check_char = true;

			Destroy_the();
		}
	}

	public void Destroy_the(bool thebool = true){

		thebool_dest = thebool;
		
		GetComponent<BoxCollider2D> ().enabled = !thebool;

		float y = 1.9f;

		if(thebool) set_z();

		if(thebool)
			StartCoroutine(U.Down(transform, y));
		else
			StartCoroutine(U.Up(transform, y));

		if(!thebool) Invoke("set_z", 1f);

		destroyed = thebool;
	}

	public void Restart_the_fast(){

		thebool_dest = false;

		GetComponent<BoxCollider2D> ().enabled = true;
		
		float y = 1.9f;

		// StartCoroutine(U.Up(transform, y));

		U.tp_to(gameObject, the_tp.x, the_tp.y, the_tp.z);

		destroyed = false;
	}

	void set_z () {
		float z = 0.2f;
	
		z *= thebool_dest ? 1 : -1;

		Vector3 t = transform.position;
		t.z -= z;
		transform.position = t;
	
	}

}
