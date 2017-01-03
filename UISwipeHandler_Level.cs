using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UISwipeHandler_Level : MonoBehaviour, IBeginDragHandler, IPointerDownHandler, IDragHandler{

	public TextMesh Level;
	public GameObject[] Next_Back = new GameObject[2];

	void Start (){

	}

	public void OnBeginDrag(PointerEventData eventData){

		// Vector2 delta = eventData.delta;

		// if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y)){
		// 	if(delta.x > 0){ // to right 
		// 		if (U.current_level > 1) MoveLevelToSide("right");
		// 	} else { // to left
		// 		if (U.current_level < U.LevelsImg.Length) MoveLevelToSide("left");
		// 	}
		// }
	}

	public void OnDrag(PointerEventData eventData){

	}

	public void OnPointerDown(PointerEventData eventData){
	
	}

	private void Update () {
		if(U.MoveLevel_back){
			U.MoveLevel_back = false;
			MoveLevelToSide("right");
		}
		if(U.MoveLevel_next){
			U.MoveLevel_next = false;
			MoveLevelToSide("left");
		}
		if (U.GAME_STARTED == 0){
			U.GAME_STARTED = -1;
			Check_Start();
		}
	}

	private void MoveLevelToSide(string to_where){

		int num = (to_where == "right") ? -1 : 1;
		U.current_level += num;

		switch(U.current_level){
			case 1: MoveAnwerImg(0); 		break; 		case 2: MoveAnwerImg(0); 		break; 
			case 3: MoveAnwerImg(-0.23f); 	break; 		case 4: MoveAnwerImg(-0.32f);	break; 
			case 5: MoveAnwerImg(0.29f); 	break; 		case 6: MoveAnwerImg(-0.31f); 	break;
			case 7: MoveAnwerImg(0); 		break; 		case 8: MoveAnwerImg(0); 		break; 
			case 9: MoveAnwerImg(0.18f); 	break; 		case 10: MoveAnwerImg(-0.25f); 	break; 
			case 11: MoveAnwerImg(-0.43f); 	break; 		case 12: MoveAnwerImg(0.16f); 	break; 
			case 13: MoveAnwerImg(-0.34f); 	break; 		case 14: MoveAnwerImg(-0.34f); 	break; 
			case 15: MoveAnwerImg(-0.34f); 	break; 		case 16: MoveAnwerImg(0.45f); 	break; 
			case 17: MoveAnwerImg(0.09f); 	break; 		case 18: MoveAnwerImg(-0.45f); 	break; 
			case 19: MoveAnwerImg(0.03f); 	break; 		case 20: MoveAnwerImg(-0.45f); 	break; 
			case 21: MoveAnwerImg(0); 		break; 		case 22: MoveAnwerImg(0); 		break; 
			case 23: MoveAnwerImg(0.4f); 	break; 		case 24: MoveAnwerImg(0.23f); 	break; 
			case 25: MoveAnwerImg(0.23f); 	break; 
		}
		
		Check_Start();

		Level.text = "LEVEL " + U.current_level.ToString();
	}

	private void MoveAnwerImg(float how_x){
		Vector3 target = U.AnswerImg.transform.position;
		target.x = how_x;
		U.AnswerImg.transform.position = target;
	}

	private void Check_Start(){

		U.AnswerImg.GetComponent<SpriteRenderer>().sprite = U.LevelsImgAnsw[U.current_level-1];
		
		U.AnswerImg.GetComponent<SpriteRenderer>().color = new Vector4(0f,0f,0f,1f);
		U.TheQuestionMark.SetActive (true);

		foreach(int i in U.opened_levels){
			if (U.current_level == i){
				U.AnswerImg.GetComponent<SpriteRenderer>().color = new Vector4(1f,1f,1f,1f);
				U.TheQuestionMark.SetActive (false);
				break;
			}
		}

		if (U.current_level == 1) {
			Next_Back[1].GetComponent<SpriteRenderer>().color = new Vector4(0.5f,0.5f,0.5f,1f);
			U.Button_Back_Active = false;
		} else if (U.current_level == U.LevelsImg.Length) {
			Next_Back[0].GetComponent<SpriteRenderer>().color = new Vector4(0.5f,0.5f,0.5f,1f);
			U.Button_Next_Active = false;
		} else {
			U.Button_Next_Active = true;
			U.Button_Back_Active = true;
			Next_Back[0].GetComponent<SpriteRenderer>().color = new Vector4(1f,1f,1f,1f);
			Next_Back[1].GetComponent<SpriteRenderer>().color = new Vector4(1f,1f,1f,1f);
		}
	}
}
