using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    public GameObject PickupEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MakePickEffect(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void MakePickEffect(GameObject go)
    {
        GameObject _effect = Instantiate(PickupEffect, go.transform.position, Quaternion.identity);
        _effect.transform.parent = go.transform;
    }   


}
