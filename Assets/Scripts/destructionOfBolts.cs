using UnityEngine;

public class destructionOfBolts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
