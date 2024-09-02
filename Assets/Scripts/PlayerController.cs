using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float velocidade = 3f;


	void Start()
    {   
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{
		pular();
		ajustarVelocidade();

	}

	private void pular()
	{
		// configurando botao de pular
		if (Input.GetKeyDown(KeyCode.Space))
		{
			myRB.velocity = new Vector2(0, velocidade);
		}
	}

	void ajustarVelocidade()
    {
        // limitando a velocidade para nao ficar uma velocidade absurda
        if (myRB.velocity.y > velocidade)
        {
            myRB.velocity = new Vector2 (0, velocidade);
        } else if (myRB.velocity.y < -velocidade)
        {
            myRB.velocity = new Vector2(0, -velocidade);
        }
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		SceneManager.LoadScene("Jogo");
	}
}
