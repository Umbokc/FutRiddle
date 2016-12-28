using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UISwipeHandler : MonoBehaviour, IBeginDragHandler, IPointerDownHandler, IDragHandler{


	public void OnBeginDrag(PointerEventData eventData){

		Vector2 delta = eventData.delta;

		if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y)){
			if(delta.x > 0){ // to right 
				if (U.current > 0){
					MoveLand(5f);
					U.current--;
					MoveLand(5f);
				}
			} else { // to left
				if (U.current < U.lands.Length-1){
					MoveLand(-5f);
					U.current++;
					MoveLand(-5f);
				}
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
			Debug.Log(U.current);

	}
	
	void Update(){
		Debug.Log(U.current);
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

	private void MoveLand(float how){
		Vector3 target = U.lands[U.current].transform.position;
		target.x += how;
		U.lands[U.current].transform.position = target;
	}
}
