using UnityEngine;

public abstract class EnemyMove : MonoBehaviour
{

    private void Start()
    {

        OnStart();
    }

    protected virtual void OnStart() { }


    // Update is called once per frame
    private void Update()
    {
        BeforeMove();
        Move();
        AfterMove();
    }

    protected virtual void BeforeMove() { }

    protected abstract void Move();

    protected virtual void AfterMove() { }

}
