using UnityEngine;
using System.Collections;

public class Money_set : MonoBehaviour {

	public GameObject cart;

	private TextMesh money;

	private static int numMoney;
	private static bool set_money = false;

	private float startpos_money;
	private float startpos_cart;

	void Start () {

		money = GetComponent<TextMesh> ();

		numMoney = PlayerPrefs.GetInt("Money");
		
		startpos_money = money.transform.position.x;
		startpos_cart = cart.transform.position.x;

		SetMoney(numMoney);
	}

	void Update () {
		if (set_money){

			set_money = !set_money;

			money.text = numMoney.ToString ();

			PlayerPrefs.SetInt("Money",numMoney);

			set_pos_x(money.gameObject, startpos_money);
			set_pos_x(cart, startpos_cart);
		}
	}

	public static void SetMoney(int num_money){
		numMoney = num_money;
		set_money = true;
	}

	void set_pos_x (GameObject go, float startpos) {
		Vector3 purp = go.transform.position;

		for(int i = 1; i < money.text.Length; i++) startpos -= 0.25f;

		purp.x = startpos;

		go.transform.position = purp;
	}
}
