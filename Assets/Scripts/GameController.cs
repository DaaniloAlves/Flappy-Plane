using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float timer = 2f;
    [SerializeField] private GameObject obstaculo;
    [SerializeField] private float posMin = -1.4f;
    [SerializeField] private float posMax = 2.4f;
    private Vector3 posicaoObstaculo;
    private float score = 0;
    [SerializeField] private TextMeshProUGUI textoScore;
    [SerializeField] private TextMeshProUGUI textoLevel;
    private float level = 1;
    private float pontosNextLevel = 10;
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

	}

    void aumentarLevel()
    {
        if (pontosNextLevel < score)
        {
            pontosNextLevel *= 2;
            level++;
            textoLevel.text = "Level: " + level.ToString();
        }
    }

	private void criarObstaculo()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			posicaoObstaculo.y = Random.Range(posMin, posMax);
			Instantiate(obstaculo, posicaoObstaculo, Quaternion.identity);
			timer = Random.Range(0.7f, 2f);
		}
        
	}

	void aumentarPontuacao()
    {
        score += Time.deltaTime;
        textoScore.text = "Score: " + Mathf.Round(score).ToString();
    }

}
