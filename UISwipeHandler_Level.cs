using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UISwipeHandler_Level : MonoBehaviour, IBeginDragHandler, IPointerDownHandler, IDragHandler{

	public TextMesh Level;

	public void OnBeginDrag(PointerEventData eventData){

		Vector2 delta = eventData.delta;

		if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y)){
			if(delta.x > 0){ // to right 
				if (U.current_level > 1) MoveLevelToSide("right");
			} else { // to left
				if (U.current_level < U.LevelsImg.Length) MoveLevelToSide("left");
			}
		}
	}

	public void OnDrag(PointerEventData eventData){

	}
	
	void Update(){

	}

	public void OnPointerDown(PointerEventData eventData){
		
	}

	private void MoveLevelToSide(string to_where){

		int num = (to_where == "right") ? -1 : 1;
		U.current_level += num;

		U.AnswerImg.GetComponent<SpriteRenderer>().sprite = U.LevelsImgAnsw[U.current_level-1];
		Debug.Log(U.current_level + "/" + U.LevelsImg.Length);		

		Level.text = "LEVEL " + U.current_level.ToString();
		
	}
}
