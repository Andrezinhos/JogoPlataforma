using UnityEngine;

public class PlatVert : MonoBehaviour
{
    // A altura máxima que a plataforma vai subir e descer
    public float alturaLimite = 5f;

    // A velocidade da plataforma
    public float velocidade = 2f;

    // A posição inicial da plataforma
    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Usa a função seno para criar um movimento suave de vai e vem
        float novaPosicaoY = posicaoInicial.y + Mathf.Sin(Time.time * velocidade) * alturaLimite;

        // Atualiza a posição da plataforma
        transform.position = new Vector3(posicaoInicial.x, novaPosicaoY, posicaoInicial.z);
    }
}
