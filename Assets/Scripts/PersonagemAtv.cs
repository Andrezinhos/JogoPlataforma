using TMPro;
using UnityEngine;

public class PersonagemAtv : MonoBehaviour
{
    TextMeshProUGUI textoMoedas;
    TextMeshProUGUI textoVidas;

    public float velo = 100;
    float velomax = 5;
    public float forcaPulo = 10;
    int totalMoeda = 0;
    int vidas = 3;
    bool podePular = true;
    bool estaOlhandoDireita = true;
    Vector3 posInicial;
    Transform projetil;
    Transform inimigo;

    Rigidbody2D rigib;

    void Start()
    {
        posInicial = transform.position;
        rigib = GetComponent<Rigidbody2D>();

        textoMoedas = GameObject.Find("Text (TMP)").transform.GetComponent<TextMeshProUGUI>();
        textoVidas = GameObject.Find("Vidas").transform.GetComponent<TextMeshProUGUI>();
        projetil = GameObject.Find("bala").transform;
        inimigo = GameObject.Find("Inimigo").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) == true)
        {
            Transform instanciado = Instantiate(projetil);
            instanciado.position = transform.position;
            instanciado.GetComponent<Projetil>().enabled = true;

            if (estaOlhandoDireita == true)
            {
                instanciado.GetComponent<Projetil>().direcao = new Vector2(1, 0);
            }
            else
            {
                instanciado.GetComponent<Projetil>().direcao = new Vector2(-1, 0);
            }
        }
    }
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move == 1)
        {
            transform.eulerAngles = new Vector2(0, 0);
            estaOlhandoDireita = true;
        }
        if (move == -1)
        {  
            transform.eulerAngles = new Vector2(0, 180);
            estaOlhandoDireita = false;
        }

        rigib.AddForce(new Vector2(move * velo, 0));

        move = move * velo * Time.deltaTime;

        bool pulo = Input.GetAxisRaw("Jump") > 0;

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
            textoMoedas.text = "Moedas: <color=yellow>"+totalMoeda+"</color>";
        }

        if (collision.CompareTag("Morte"))
        {
            transform.position = posInicial;
            totalMoeda = 0;
            textoMoedas.text = "Moedas: <color=yellow>" + totalMoeda + "</color>";
            vidas--;

            if (vidas == 3)
            {
                textoVidas.text = "Vidas: <color=green>" + vidas + "</color>";
            }
            if (vidas == 2)
            {
                textoVidas.text = "Vidas: <color=yellow>" + vidas + "</color>";
            }
            if (vidas == 1)
            {
                textoVidas.text = "Vidas: <color=red>" + vidas + "</color>";
            }
            if (vidas <= 0)
            {
                textoVidas.text = "Vidas: <color=black>" + vidas + "</color>";
            }
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
