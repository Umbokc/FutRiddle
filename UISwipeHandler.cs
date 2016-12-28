using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UISwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler{

#if UNITY_EDITOR
	public void OnBeginDrag(PointerEventData eventData){

		Vector2 delta = eventData.delta;

		if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y)){
			if(delta.x > 0) Debug.Log("right");
			else Debug.Log("left");
		} else {
			if(delta.y > 0)	Debug.Log("up");
			else Debug.Log("down");
		}
	}
	public void OnDrag(PointerEventData eventData){

	}
#endif
}
