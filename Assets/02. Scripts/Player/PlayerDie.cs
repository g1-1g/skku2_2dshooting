using UnityEngine;

public class PlayerDie : MonoBehaviour
{

    [Header("게임종료")]
    [SerializeField]
    private GameObject _diePrefab;

    [SerializeField]
    private AudioClip _dieSound;

    [SerializeField]
    private GameObject[] _pets;

    public void Die()
    {
        MakeExplosionEffect();
        PetKill();
        Destroy(gameObject);
        Debug.Log("Player Die");
    }

    private void MakeExplosionEffect()
    {
        SFXManager.Instance.SoundPlay(_dieSound);
        Instantiate(_diePrefab, transform.position, Quaternion.identity);
    }

    private void PetKill()
    {
        for (int i = 0 ; i < _pets.Length; i++)
        {
            Destroy( _pets[i] );
        }
    }
}
