using UnityEngine;

public class PlatVert : MonoBehaviour
{
    // A altura m�xima que a plataforma vai subir e descer
    public float alturaLimite = 5f;

    // A velocidade da plataforma
    public float velocidade = 2f;

    // A posi��o inicial da plataforma
    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Usa a fun��o seno para criar um movimento suave de vai e vem
        float novaPosicaoY = posicaoInicial.y + Mathf.Sin(Time.time * velocidade) * alturaLimite;

        // Atualiza a posi��o da plataforma
        transform.position = new Vector3(posicaoInicial.x, novaPosicaoY, posicaoInicial.z);
    }
}
