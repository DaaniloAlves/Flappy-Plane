using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float velocidade = 3f;
	[SerializeField] private TextMeshProUGUI restart;


	void Start()
    {   
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{
		pular();
		ajustarVelocidade();
		ajustarAltura();
	}

	private void pular()
	{
		// configurando botao de pular
		if (Input.GetKeyDown(KeyCode.Space))
		{
			myRB.velocity = new Vector2(0, velocidade);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(1);
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

	void ajustarAltura()
	{
		if (transform.position.y < -3.88) transform.position = new Vector3(transform.position.x, -3.88f, transform.position.z);
		if (transform.position.y > 4.67) transform.position = new Vector3(transform.position.x, 4.67f, transform.position.z);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Instantiate(restart, new Vector3(0, 0, transform.position.z), Quaternion.identity);
		Time.timeScale = 0;
	}
}
