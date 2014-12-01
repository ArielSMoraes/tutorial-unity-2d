using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float velocidade;
	public float forcaPulo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Movimentacao();
	}

	void Movimentacao() {
		if (Input.GetAxisRaw("Horizontal") > 0) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);	
			transform.eulerAngles = new Vector2(0,0);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}

		if (Input.GetButtonDown ("Jump")) {
			rigidbody2D.AddForce(transform.up * forcaPulo);		
		}
	}
}
