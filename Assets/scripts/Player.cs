using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float velocidade;
	public float forcaPulo;
	public Transform chaoVerificador;
	private bool estaNoChao;

	public Transform spritePlayer;
	private Animator animator;

	public GameObject vida;
	public int maxVida;
	private int vidaAtual;


	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator> ();

		//Vida
		vidaAtual = maxVida;
		vida.guiText.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		vida.guiText.text = "HP: " + vidaAtual + "/" + maxVida;
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

		if (Input.GetButtonDown ("Jump") && estaNoChao) {
			rigidbody2D.AddForce(transform.up * forcaPulo);		
		}

		estaNoChao = Physics2D.Linecast (transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer ("Piso"));
		animator.SetFloat("movimento", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));
		animator.SetBool("chao", estaNoChao);
	}

	public void PerdeVida(int dano) {
		vidaAtual -= dano;
		
		if (vidaAtual <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if ((vidaAtual * 100 / maxVida) < 30) {
			vida.guiText.color = Color.red;
		}
		
		vida.guiText.text = "HP: " + vidaAtual + "/" + maxVida;
	}

	public void RecuperaVida(int recupera) {
		vidaAtual += recupera;
		
		if (vidaAtual > maxVida) {
			vidaAtual = maxVida;
		}
		
		if ((vidaAtual * 100 / maxVida) >= 30) {
			vida.guiText.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		}
		
		vida.guiText.text = "HP: " + vidaAtual + "/" + maxVida;
	}
}
