using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ===== TIRO =====
    public Laser laserPrefab;
    private float intervaloTiro;

    // ===== MOVIMENTO =====
    public float velocidade = 10f;
    public float forcaPulo = 10f;
    public bool noChao = false;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        intervaloTiro = 0f;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ===== CONTROLE DE TIRO =====
        intervaloTiro += Time.deltaTime;

        if (intervaloTiro >= 1f)
        {
            intervaloTiro = 0f;
            Atirar();
        }

        // ===== MOVIMENTO =====
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-velocidade * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(velocidade * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
        }

        // ===== PULO =====
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            _rigidbody2D.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
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
