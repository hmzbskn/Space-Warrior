using System;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController controller;
    private void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion,transform.position, transform.rotation);

        if (other.gameObject.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            controller.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        controller.updateScore();
        
            
    }
}
