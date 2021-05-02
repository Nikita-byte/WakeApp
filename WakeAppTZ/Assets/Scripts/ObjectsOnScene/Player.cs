using UnityEngine;


public class Player : BaseObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToStop;

    private Rigidbody2D _rigidBody;
    private Vector3 _currentPosition;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public override void Death()
    {

    }

    public override void SetPosition(Vector3 vector)
    {
        transform.position = vector;
    }

    public override void Move()
    {
        if (Vector3.Distance(transform.position, _currentPosition) >= _distanceToStop)
        {
            GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(transform.position, _currentPosition, _speed * Time.deltaTime));
        }
    }

    public override void SetDistination(Vector3 vector)
    {
        _currentPosition = vector;
    }
}
