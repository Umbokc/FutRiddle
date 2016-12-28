using UnityEngine;
using System.Collections;

public class Money_set : MonoBehaviour {

	public GameObject cart;

	private TextMesh money;

	void Start () {

		money = GetComponent<TextMesh> ();

		int numMoney = PlayerPrefs.GetInt("Money") == null ? PlayerPrefs.GetInt("Money") : 200;

		money.text = numMoney.ToString ();

		set_pos_x(money.gameObject, money.transform.position.x);
		set_pos_x(cart, cart.transform.position.x);
	}

	void Update () {

	}


	void set_pos_x (GameObject go, float startpos) {
		Vector3 purp = go.transform.position;

		for(int i = 1; i < money.text.Length; i++) startpos -= 0.25f;

		purp.x = startpos;

		go.transform.position = purp;
	}
}
