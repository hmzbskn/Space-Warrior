using UnityEngine;

public class AsteroidRandomRotater : MonoBehaviour
{
    Rigidbody physic;
    [SerializeField] int speed;
    void Start()
    {
        physic = this.GetComponent<Rigidbody>();

        physic.angularVelocity = speed * Random.insideUnitSphere; // Hazýr random hareket veriyor
    }
}
