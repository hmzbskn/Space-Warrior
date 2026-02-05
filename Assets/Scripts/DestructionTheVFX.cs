using UnityEngine;

public class DestructionTheVFX : MonoBehaviour
{
    public float lifeTime;
    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }
}
