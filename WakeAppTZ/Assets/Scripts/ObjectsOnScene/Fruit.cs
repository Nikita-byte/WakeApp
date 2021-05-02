using UnityEngine;
using DG.Tweening;


public class Fruit : BaseObject
{
    private void Start()
    {
        transform.DOScale(1.2f, 0.5f).SetLoops(-1); 
    }

    public override void Death()
    {

    }

    public override void Move()
    {

    }

    public override void SetDistination(Vector3 vector)
    {

    }

    public override void SetPosition(Vector3 vector)
    {
        transform.position = vector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player _player))
        {
            EventManager.Instance.Events[EventType.GetFruit].Invoke(EventType.GetFruit);

            ObjectPool.Instance.ReturnInPool(ObjectType.Fruit,gameObject);
        }
    }
}