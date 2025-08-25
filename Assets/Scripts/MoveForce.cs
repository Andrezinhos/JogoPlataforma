using JetBrains.Annotations;
using UnityEngine;

public class MoveForce : MonoBehaviour
{
    public float velocidade = 100;
    public float velomax = 5;
    public float forcaPulo = 50;
    bool podePular = true;
    public Rigidbody2D rigib;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigib = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimento = Input.GetAxisRaw("Horizontal");
        bool pulo = Input.GetAxisRaw("Jump") > 0;

        rigib.AddForce(new Vector2(movimento * velocidade, 0));

        rigib.linearVelocityX = Mathf.Clamp(rigib.linearVelocityX, -velomax, velomax);

        if (pulo == true && podePular == true)
        {
            rigib.AddForce(new Vector2(0, forcaPulo));
            podePular = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.name.Contains("Moeda") == true)
       {
            Destroy(collision.gameObject);
       }   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Chao") == true)
        {
            podePular = true;
        }   
    }
}
