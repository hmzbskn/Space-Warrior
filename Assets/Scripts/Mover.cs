using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody physic;
    public int boltSpeed;
    void Start()
    {
        physic = GetComponent<Rigidbody>();

        //normalde transform.forward z ekseni
        physic.linearVelocity = transform.forward * boltSpeed;
    }

}
