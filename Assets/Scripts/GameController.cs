using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float timer = 2f;
    [SerializeField] private GameObject obstaculo;
    [SerializeField] private float posMin = -1.4f;
    [SerializeField] private float posMax = 2.4f;
    [SerializeField] private AudioClip levelupSound;
    private Vector3 posicaoObstaculo;
    private float score = 0;
    [SerializeField] private TextMeshProUGUI textoScore;
    [SerializeField] private TextMeshProUGUI textoLevel;
    private float level = 1;
    private float pontosNextLevel = 10;
    private float intervaloMin = 0.7f;
    private float intervaloMax = 2f;

    public float getLevel()
    {
        return this.level;
    }

    void Start()
    {
        posicaoObstaculo.x = 12f;
    }

    // Update is called once per frame
    void Update()
	{
		criarObstaculo();
        aumentarPontuacao();
        aumentarLevel();
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(1);
            Time.timeScale = 1;
		}

	}



    void aumentarLevel()
    {
        if (pontosNextLevel < score)
        {
            pontosNextLevel += 15;
            level++;
            textoLevel.text = "Level: " + level.ToString();
            AudioSource.PlayClipAtPoint(levelupSound, new Vector3(0, 0, -10), 0.02f);
            if(level < 6)
            {
				intervaloMax -= 0.2f;
				intervaloMin -= 0.05f;
			}
        }
    }

	private void criarObstaculo()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			posicaoObstaculo.y = Random.Range(posMin, posMax);
			Instantiate(obstaculo, posicaoObstaculo, Quaternion.identity);
			timer = Random.Range(intervaloMin, intervaloMax);
		}
        
	}

	void aumentarPontuacao()
    {
        score += Time.deltaTime;
        textoScore.text = "Score: " + Mathf.Round(score).ToString();
    }

}
