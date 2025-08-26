using NUnit.Framework;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public Vector3 direcao;
    public float velocidade = 20;

    void Start()
    {
        Destroy(transform.gameObject, 3);     
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direcao * velocidade * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       Destroy(collision.gameObject);   
    }
}
