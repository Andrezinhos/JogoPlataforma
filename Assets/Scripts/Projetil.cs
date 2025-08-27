using NUnit.Framework;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public Vector3 direcao;
    public float velocidade = 20;

    void Start()
    {
        Destroy(transform.gameObject, 0.7f);     
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direcao * velocidade * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(transform.gameObject);

        if (collision.gameObject.layer == Constraints.camadaInimigo)
        {
            Destroy(collision.gameObject);
        }
    }
}
