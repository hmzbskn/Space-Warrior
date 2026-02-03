using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject shoot;
    [SerializeField] GameObject shootSpawn;

    [SerializeField] float nextFire;
    [SerializeField] float fireRate;

    Rigidbody physic;
    public Boundary borders;
    [SerializeField] int speed; // bu da public yapmadan fieldýn ekranda görünmesini saðlar
    [SerializeField] int egim;

    private void Start()
    {
        physic = this.GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shoot, shootSpawn.transform.position, shootSpawn.transform.rotation);
        }
        
    }

    private void FixedUpdate()
    {
        // fizikle ilgili scriptlerde fixed update kullanmak daha verimli

        // unitynin hazýr olarak sunduðu input manager. wasd veya yön tuþlarýna bastýðýn süre boyunca -1,0 ve 1 arasýnda deðerler döndürür zamana baðlý bir fonksiyondur.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(moveHorizontal,0,moveVertical);
        movment = movment * speed;
        physic.linearVelocity = movment;

        // karakterin kamera sýnýrlarý dýþýna taþmamasýný saðlýyor
        Vector3 brdrs = new Vector3(
            Mathf.Clamp(physic.position.x, borders.xMin , borders.xMax),
            0, // The character cannot move along the y-axis.
            Mathf.Clamp(physic.position.z, borders.zMin, borders.zMax)
            );

        physic.position = brdrs;

        // playerýn saða giderken eðim almasýný saðlýyor
        physic.rotation = quaternion.Euler(0,0,physic.linearVelocity.x/egim);
    }



}
