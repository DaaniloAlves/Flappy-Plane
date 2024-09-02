using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject eu;
    void Start()
    {
        Destroy(eu, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime;
    }
}
