using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Select_Level : MonoBehaviour{

	public TextMesh Level;
	public GameObject[] Next_Back = new GameObject[2];

	void Start (){
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
		
		MoveAnswerImg(0);
		U.AnswerImg.GetComponent<SpriteRenderer>().sprite =  Resources.Load<Sprite>("levels/question");

		Check_Start();

		Level.text = "LEVEL " + U.current_level.ToString();
	}

	private void MoveAnswerImg(float how_x){
		Vector3 target = U.AnswerImg.transform.position;
		target.x = how_x;
		U.AnswerImg.transform.position = target;
	}

	private void Check_Start(){

		foreach(int i in U.opened_levels){
			if (U.current_level == i){
				U.AnswerImg.GetComponent<SpriteRenderer>().sprite =  Resources.Load<Sprite>("levels/answer/" + U.current_level);

				switch(U.current_level){
					case 1: MoveAnswerImg(0); 		break; 		case 2: MoveAnswerImg(0); 		break; 
					case 3: MoveAnswerImg(-0.23f); 	break; 		case 4: MoveAnswerImg(-0.32f);	break; 
					case 5: MoveAnswerImg(0.29f); 	break; 		case 6: MoveAnswerImg(-0.31f); 	break;
					case 7: MoveAnswerImg(0); 		break; 		case 8: MoveAnswerImg(0); 		break; 
					case 9: MoveAnswerImg(0.18f); 	break; 		case 10: MoveAnswerImg(-0.25f); break; 
					case 11: MoveAnswerImg(-0.43f); break; 		case 12: MoveAnswerImg(0.16f); 	break; 
					case 13: MoveAnswerImg(-0.34f); break; 		case 14: MoveAnswerImg(-0.34f); break; 
					case 15: MoveAnswerImg(-0.34f); break; 		case 16: MoveAnswerImg(0.45f); 	break; 
					case 17: MoveAnswerImg(0.09f); 	break; 		case 18: MoveAnswerImg(-0.45f); break; 
					case 19: MoveAnswerImg(0.03f); 	break; 		case 20: MoveAnswerImg(-0.45f); break; 
					case 21: MoveAnswerImg(0); 		break; 		case 22: MoveAnswerImg(0); 		break; 
					case 23: MoveAnswerImg(0.4f); 	break; 		case 24: MoveAnswerImg(0.23f); 	break; 
					case 25: MoveAnswerImg(0.23f); 	break; 
				}
				break;
			}
		}

		if (U.current_level == 1) {
			Next_Back[1].GetComponent<SpriteRenderer>().color = new Vector4(0.5f,0.5f,0.5f,1f);
			U.Button_Back_Active = false;
		} else if (U.current_level == U._LEVELS_CHARS.Length) {
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
