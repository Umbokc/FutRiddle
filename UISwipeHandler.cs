using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UISwipeHandler : MonoBehaviour, IBeginDragHandler, IPointerDownHandler, IDragHandler{

	public GameObject check_point;
	public SpriteRenderer Country;
	public TextMesh name;

	public void OnBeginDrag(PointerEventData eventData){

		Vector2 delta = eventData.delta;

		if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y)){
			if(delta.x > 0){ // to right 
				if (U.current_country > 1) MoveLandToSide("right");
			} else { // to left
				if (U.current_country < 3) MoveLandToSide("left");
			}
		} else {
			if(delta.y > 0){ // to up
				Debug.Log("to up");
			} else { // to down
				Debug.Log("to down");
			}
		}
	}

	public void OnDrag(PointerEventData eventData){

	}
	
	void Update(){

	}

	public void OnPointerDown(PointerEventData eventData){
		
		// Ray ray = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
		// Vector3 point = ray.origin + (ray.direction * 4.5f);
		// if (point.x > 0) {
		// 	Debug.Log ("right");
		// } else {
		// 	Debug.Log ("left");
		// }
	}

	private void MoveLandToSide(string to_where){

		float x_check = 0.3f;
		int indecr = 1;

		indecr *= (to_where == "right") ? -1 : 1;
		x_check *= indecr;

		Vector3 target = check_point.transform.position;
		target.x += x_check;
		check_point.transform.position = target;


		U.current_country += indecr;
		
		string theCountry = (U.current_country == 1) ? "England" 
											: (U.current_country == 2) ? "Germany" 
											: (U.current_country == 3) ? "Spain" 
											: "" ;

		Country.sprite = Resources.Load<Sprite>("land/"+theCountry);
		
		name.text = theCountry;

	}
}
