using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    [SerializeField] private float velocidade = 4f;
    [SerializeField] private GameObject eu;
    [SerializeField] private GameController gameController;
    private float controladorVelocidade;
    void Start()
    {
        Destroy(eu, 5f);
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        controladorVelocidade = gameController.getLevel() + velocidade;
		transform.position += Vector3.left * controladorVelocidade * Time.deltaTime;
        
    }
}
