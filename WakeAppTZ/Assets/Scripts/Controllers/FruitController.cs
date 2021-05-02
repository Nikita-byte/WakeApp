using System.Collections.Generic;
using UnityEngine;


public class FruitController : BaseController
{
    private int _countOfFruits = 5;
    private List<Fruit> _fruits;
    private System.Random _random;
    private int _hight;
    private int _width;

    public FruitController()
    {
        System.Random _random = new System.Random();
        _hight = Camera.main.pixelHeight;
        _width = Camera.main.pixelWidth;


        _fruits = new List<Fruit>();

        for (int i = 0; i < _countOfFruits; i++)
        {
            _fruits.Add(ObjectPool.Instance.GetFruit().GetComponent<Fruit>());
        }

        foreach (Fruit fruit in _fruits)
        {
            fruit.gameObject.SetActive(true);

            fruit.SetPosition(Camera.main.ScreenToWorldPoint(new Vector2(_random.Next(0, _width),
                   _random.Next(0, _hight)), 0));
        }

        EventManager.Instance.AddListener(EventType.GetFruit, AddNewFruit);
    }

    public override void FixedUpdate()
    {
    }

    public override void LateUpdate()
    {
    }

    public override void Update()
    {
    }

    public void AddNewFruit(EventType eventType)
    {
        System.Random _random = new System.Random();

        GameObject go = ObjectPool.Instance.GetFruit();
        go.SetActive(true);
        _fruits.Add(go.GetComponent<Fruit>());
        go.GetComponent<Fruit>().SetPosition(Camera.main.ScreenToWorldPoint(new Vector2(_random.Next(0, _width),
                   _random.Next(0, _hight)), 0));

    }
}