using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ===== TIRO =====
    public Laser laserPrefab;
    
    // ===== MOVIMENTO E ANIMAÇÃO =====
    public float velocidade = 10f;
    public float forcaPulo = 10f;
    public bool noChao = false;

    // Linha 9: Referência para o Animator
    [SerializeField] private Animator _animator; 

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Tenta pegar o Animator automaticamente se não foi arrastado no Inspector
        if (_animator == null) _animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        // Atirar no z
       if(Input.GetKeyDown(KeyCode.Z)) Atirar();

        float movimentoH = 0;

        // ===== MOVIMENTO ESQUERDA =====
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimentoH = -1;
            transform.position += new Vector3(-velocidade * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;
        }
        // ===== MOVIMENTO DIREITA =====
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movimentoH = 1;
            transform.position += new Vector3(velocidade * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
        }

        // ===== CONTROLE DA ANIMAÇÃO (LINHAS 61 a 66 das fotos) =====
        if (movimentoH != 0) 
        {
            _animator.SetBool("isRunning", true); 
        }
        else 
        {
            _animator.SetBool("isRunning", false); 
        }

        // ===== PULO (Ajustado para tecla 'W' para não conflitar com Tiro) =====
        if (Input.GetKeyDown(KeyCode.W) && noChao)
        {
            _rigidbody2D.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Verifica se está tocando no chão (Tag precisa ser "chao")
        if (collision.gameObject.CompareTag("chao"))
        {
            noChao = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            noChao = false;
        }
    }

    private void Atirar()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }
}