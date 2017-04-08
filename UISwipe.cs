using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UISwipe : MonoBehaviour, IBeginDragHandler, IPointerDownHandler, IDragHandler{

	public GameObject check_point;
	public GameObject Land;
	public TextMesh name;
	
	private Sprite nextLand;
	private GameObject pref;

	public static bool tomove_ok = true;

	public void OnBeginDrag(PointerEventData eventData){

		Vector2 delta = eventData.delta;

		if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y) && tomove_ok){
			if(delta.x > 0){ // to right 
				if (U.global_level > 1) MoveLandToSide("right");
			} else { // to left
				if (U.global_level < 3) MoveLandToSide("left");
			}
		} else {
			if(delta.y > 0){ // to up
				// Debug.Log("to up");
			} else { // to down
				// Debug.Log("to down");
			}
		}
	}

	public void OnDrag(PointerEventData eventData){
	}
	
	void Update(){
	}

	public void OnPointerDown(PointerEventData eventData){

	}

	private void MoveLandToSide(string to_where){
		
		tomove_ok = false;


		float x_check = 0.3f;
		int indecr = 1;

		indecr *= (to_where == "right") ? -1 : 1;
		x_check *= indecr;

		Vector3 target = check_point.transform.position;
		target.x += x_check;
		check_point.transform.position = target;

		U.global_level += indecr;
		
		string theLand =  (U.global_level == 1) ? "England" 
										: (U.global_level == 2) ? "Germany" 
										: (U.global_level == 3) ? "Spain" 
										: "" ;

		nextLand = Resources.Load<Sprite>("land/"+theLand);

		GameObject go = Resources.Load<GameObject>("Land");

		float x = 6f;
		x *= (to_where == "right") ? -1 : 1;

		Vector3 crd = new Vector3(x,0.77f,0); 

		pref = Instantiate(go,crd,Quaternion.identity) as GameObject;

		pref.GetComponent<SpriteRenderer>().sprite = nextLand;


		if(to_where == "right"){
			StartCoroutine(U.Right(pref.transform, 6f, 0.7f));
			StartCoroutine(U.Right(Land.transform, 6, 0.7f, End_move));
		} else {
			StartCoroutine(U.Left(pref.transform, 6f, 0.7f));
			StartCoroutine(U.Left(Land.transform, 6, 0.7f, End_move));
		}

		name.text = theLand;

		U.Global_Level = U.global_level;
	}

	void End_move(){
		Land.GetComponent<SpriteRenderer>().sprite = nextLand;

		Vector3 t = Land.transform.position;
		t.x = 0;
		Land.transform.position = t;

		Destroy(pref);

		tomove_ok = true;
	}
}
