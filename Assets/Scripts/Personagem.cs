using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float velocidade = 100;
    public float velomax = 5;
    public float forcaPulo = 10;
    public Transform checker;
    bool podePular = true;

    Rigidbody2D rigib;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigib = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lógica do movimento
        float horizontal = Input.GetAxis("Horizontal");
        horizontal = horizontal * velocidade * Time.deltaTime;

        Vector2 movimento = new Vector2 (horizontal, 0);

        rigib.linearVelocity += movimento;
        rigib.linearVelocityX = Mathf.Clamp(rigib.linearVelocityX, -velomax, velomax);

        //if (movimento.x == 0)
        //{
        //    rigib.linearVelocityX = 0;
        //}

        // Lógica de pulo

        //Forma 3 de fazer o pulo: raycast
        podePular = Physics2D.Raycast(
            transform.position, 
            Vector2.down, 0.6f, 
            LayerMask.GetMask("Ground")
        );

        // Forma 2 de pulo: sobreposição
        //podePular = Physics2D.OverlapBox(
        //    checker.position,
        //    checker.GetComponent<BoxCollider2D>().bounds.size,
        //    0,
        //    LayerMask.GetMask("Chao")
        //);

        bool pulo = Input.GetButtonDown("Jump");
        if (pulo == true && podePular == true)
        {
            rigib.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false;
        }
    }

    //Forma 1 de pulo: colisões
    //void //OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == Constraints.camadaChao)
    //    {
    //        podePular = true;
    //    }
    //}


}
