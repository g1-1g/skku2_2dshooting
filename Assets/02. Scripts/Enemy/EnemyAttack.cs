using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) //compareTag를 사용하면 해당 태그가 없을 경우 런타임 오류를 냄. == 보다는 comparetag를 사용할 것
        {
            AttackPlayer(collision.gameObject);

        }

    }
    public void AttackPlayer(GameObject gameObject)
    {
        PlayerMove player = gameObject.GetComponent<PlayerMove>();
        player.Hit();
        Destroy(this.gameObject);
    }

    // Update is called once per frame

}
