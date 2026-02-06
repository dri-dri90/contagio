using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidadeY;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody.linearVelocity = new Vector2(this.velocidadeY,0);
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Inimigo")) {
            // Destrói o inimigo
            Destroy(collider.gameObject);
            // Destrói o próprio laser
            Destroy(this.gameObject);
        }
    }
}