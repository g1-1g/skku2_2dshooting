using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [Header("게임종료")]
    [SerializeField]
    private GameObject _diePrefab;

    [SerializeField]
    private SFXManager _sfxManager;
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
        _sfxManager.SoundPlay(_dieSound);
        Instantiate(_diePrefab, transform.position, Quaternion.identity);
    }
}
