using UnityEngine;

public class PersonagemAtv : MonoBehaviour
{
    public float velo = 100f;
    float velomax = 10f;
    float forcaPulo = 10f;
    int totalMoeda = 0;
    bool podePular = true;
    Vector3 posInicial;

    Rigidbody2D rigib;

    void Start()
    {
        posInicial = transform.position;
        rigib = GetComponent<Rigidbody2D>();     
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        bool pulo = Input.GetAxisRaw("Jump") > 0;

        rigib.AddForce(new Vector2(move * velo, 0));

        rigib.linearVelocityX = Mathf.Clamp(rigib.linearVelocityX, -velomax, velomax);

        if (pulo == true && podePular == true)
        {
            rigib.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Moeda") == true) 
        {
            Destroy(collision.gameObject);
            totalMoeda++;
            Debug.Log("Moedas Coletadas: " + totalMoeda);
        }

        if (collision.CompareTag("Morte"))
        {
            transform.position = posInicial;
            totalMoeda = 0;
            Debug.Log("Você perdeu todas as moedas");
        }

        if (collision.CompareTag("Final"))
        {
            Debug.Log("Parabéns, você terminou o jogo");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constraints.camadaChao)
        {
            podePular = true;
        }
    }
}
