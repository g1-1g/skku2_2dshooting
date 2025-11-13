using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [Header("게임종료")]
    [SerializeField]
    private GameObject _diePrefab;

    [SerializeField]
    private AudioClip _dieSound;

    public void Die()
    {
        MakeExplosionEffect();
        Destroy(gameObject);
        Debug.Log("Player Die");
    }

    private void MakeExplosionEffect()
    {
        SFXManager.Instance.SoundPlay(_dieSound);
        Instantiate(_diePrefab, transform.position, Quaternion.identity);
    }
}
