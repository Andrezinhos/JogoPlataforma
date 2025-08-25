using UnityEngine;

public class PlatHorin : MonoBehaviour
{
    // A distância horizontal máxima que a plataforma vai percorrer
    public float distanciaLimite = 5f;

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
        float novaPosicaoX = posicaoInicial.x + Mathf.Sin(Time.time * velocidade) * distanciaLimite;

        // Atualiza a posição da plataforma
        transform.position = new Vector3(novaPosicaoX, posicaoInicial.y, posicaoInicial.z);
    }
}
