using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UISwipeHandler : MonoBehaviour, IBeginDragHandler, IPointerDownHandler, IDragHandler{

	public GameObject check_point;
	public TextMesh name;

	public void OnBeginDrag(PointerEventData eventData){

		Vector2 delta = eventData.delta;

		if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y)){
			if(delta.x > 0){ // to right 
				if (U.current_land > 0) MoveLandToSide("right");
			} else { // to left
				if (U.current_land < U.lands.Length-1) MoveLandToSide("left");
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

		float x_land = 5f, x_check = 0.3f;
		int indecr = 1;

		x_check *= (to_where == "right") ? -1 : 1;
		x_land *= (to_where == "right") ? 1 : -1;
		indecr *= (to_where == "right") ? -1 : 1;

		Vector3 target = check_point.transform.position;
		target.x += x_check;
		check_point.transform.position = target;


		MoveLand(x_land);
		U.current_land += indecr;
		MoveLand(x_land);
		
		name.text = (U.current_land == 2) ? "Spain" : (U.current_land == 1) ? "Germany" : "England" ;

	}

	private void MoveLand(float how){
		Vector3 target = U.lands[U.current_land].transform.position;
		target.x += how;
		U.lands[U.current_land].transform.position = target;
	}
}
