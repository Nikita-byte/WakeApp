using UnityEngine;


public class Enemy : BaseObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToStop;
    private Vector3 _currentPosition;

    public bool IsStopped = true;

    public override void Death()
    {

    }

    public override void Move()
    {
        if (Vector3.Distance(transform.position, _currentPosition) >= _distanceToStop)
        {
            GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(transform.position, _currentPosition, _speed * Time.deltaTime));
        }
        else
        {
            IsStopped = true;
        }
    }

    public override void SetPosition(Vector3 vector)
    {
        transform.position = vector;
    }

    public override void SetDistination(Vector3 vector)
    {
        _currentPosition = vector;

        IsStopped = Vector3.Distance(transform.position, _currentPosition) >= _distanceToStop ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player _player))
        {
            EventManager.Instance.Events[EventType.Death].Invoke(EventType.Death);
        }
    }
}
