using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Configurações")]
    public Rigidbody2D meuRigidbody; 
    public float velocidadeX = 15f; // Mudei para X para fazer sentido
    public float tempoDeVida = 3f;

    void Start()
    {
        // 1. Busca o Rigidbody automaticamente se você esquecer de arrastar
        if (meuRigidbody == null) meuRigidbody = GetComponent<Rigidbody2D>();

        // 2. CORREÇÃO: Agora o valor vai no primeiro espaço (X) e o Y fica em 0
        meuRigidbody.linearVelocity = new Vector2(this.velocidadeX, 0);

        // 3. Destrói o laser depois de um tempo para não pesar o jogo
        Destroy(this.gameObject, tempoDeVida);
    }

    public void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Inimigo")) 
        {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }
    }
}