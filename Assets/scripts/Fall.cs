using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	public float duracaoCair;
	private float tempo;
	private bool pisou = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (pisou) {
			tempo+= Time.deltaTime;
			
			if (tempo >= duracaoCair) {
				gameObject.AddComponent("Rigidbody2D");
				Destroy (gameObject,2f);
				tempo = 0f;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.name == "Player") {
			pisou = true;
		}
	}

}
