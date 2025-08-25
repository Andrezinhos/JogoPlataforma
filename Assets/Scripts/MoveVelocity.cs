using UnityEngine;

public class MoveVelocity : MonoBehaviour
{
    public float velocidade = 10;
    public Rigidbody2D rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity += new Vector2(movimento * velocidade, 0);
    }
}
