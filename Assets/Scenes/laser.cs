using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidadeX = 5f;
    public bool vaiParaDireita = true;

    void Start()
    {
        float direcao = vaiParaDireita ? 1f : -1f;
        rigidbody.linearVelocity = new Vector2(velocidadeX * direcao, 0);
    }
}