using UnityEngine;
using System.Collections.Generic;


public class EnemyController : BaseController
{
    [SerializeField] private float _speed;

    private int _countOfEnemy = 5;
    private List<Enemy> _enemies;
    private System.Random _random;
    private int _hight;
    private int _width;

    public EnemyController()
    {
        _enemies = new List<Enemy>();
        _random = new System.Random();

        _hight = Camera.main.pixelHeight;
        _width = Camera.main.pixelWidth;

        for (int i = 0; i < _countOfEnemy; i++)
        {
            _enemies.Add(ObjectPool.Instance.GetEnemy().GetComponent<Enemy>());
        }

        foreach (Enemy enemy in _enemies)
        {
            enemy.gameObject.SetActive(true);

            System.Random random = new System.Random();

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector2(random.Next(0, _width),
                   random.Next(0, _hight)), 0);

            enemy.SetPosition(pos);
        }
    }

    public override void FixedUpdate()
    {
    }

    public override void LateUpdate()
    {
    }

    public override void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy.IsStopped)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector2(_random.Next(0, _width),
                   _random.Next(0, _hight)), 0);
                enemy.SetDistination(pos);
            }

            enemy.Move();
        }
    }
}
