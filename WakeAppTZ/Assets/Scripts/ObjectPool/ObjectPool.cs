using System;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool
{
    public static ObjectPool Instance = new ObjectPool();

    private Queue<GameObject> _enemies;
    private Queue<GameObject> _fruits;
    private List<GameObject> _players;
    private int _countOfEnemies = 20;
    private int _countOfFruits = 20;
    private int _countOfPlayers = 1;
    private GameObject _poolOnScene;

    public ObjectPool()
    {
        _poolOnScene = new GameObject("[ObjectPool]");

        _enemies = new Queue<GameObject>();
        _fruits = new Queue<GameObject>();
        _players = new List<GameObject>();

        for (int i = 0; i < _countOfEnemies; i++)
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Objects/Enemy"), _poolOnScene.transform);
            _enemies.Enqueue(go);
            go.SetActive(false);
        }

        for (int i = 0; i < _countOfFruits; i++)
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Objects/Fruit"), _poolOnScene.transform);
            _fruits.Enqueue(go);
            go.SetActive(false);
        }

        for (int i = 0; i < _countOfPlayers; i++)
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Objects/Player"), _poolOnScene.transform);
            _players.Add(go);
            go.SetActive(false);
        }
    }

    public GameObject GetPlayer(int number)
    {
        return _players[number];
    }

    public GameObject GetFruit()
    {
        return _fruits.Dequeue();
    }

    public GameObject GetEnemy()
    {
        return _enemies.Dequeue();
    }

    public void ReturnInPool(ObjectType objectType, GameObject go)
    {
        go.SetActive(false);

        switch (objectType)
        {
            case ObjectType.Player:
                _players.Add(go);
                break;
            case ObjectType.Fruit:
                _fruits.Enqueue(go);
                break;
            case ObjectType.Enemy:
                _enemies.Enqueue(go);
                break;
        }
    }
}