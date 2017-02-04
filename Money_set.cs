using UnityEngine;
using System.Collections;

public class Money_set : MonoBehaviour {

	public GameObject cart;

	private TextMesh money;

	public static bool set_money = false;

	private float startpos_money;
	private float startpos_cart;

	void Start () {

		money = GetComponent<TextMesh> ();

		startpos_money = money.transform.position.x;
		startpos_cart = cart.transform.position.x;

		set_money = true;
	}

	void Update () {
		if (set_money){

			set_money = !set_money;

			money.text = U.PP_Money.ToString ();
			
			set_pos_x(money.gameObject, startpos_money);
			set_pos_x(cart, startpos_cart);
		}
	}

	void set_pos_x (GameObject go, float startpos) {
		Vector3 purp = go.transform.position;

		for(int i = 1; i < money.text.Length; i++) startpos -= 0.25f;

		purp.x = startpos;

		go.transform.position = purp;
	}
}
