using Unity.VisualScripting;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
   
    public GameObject PickupEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ApplyEffect(collision.gameObject);
            MakePickEffect(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    
    private void MakePickEffect(GameObject go)
    {
        GameObject effect = Instantiate(PickupEffect, go.transform.position, Quaternion.identity);
        effect.transform.parent = go.transform;
    }

    protected abstract void ApplyEffect(GameObject player);

}
