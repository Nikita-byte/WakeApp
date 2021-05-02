using UnityEngine;


public class PlayerController : BaseController
{
    private Player _player;

    public PlayerController()
    {
        _player = ObjectPool.Instance.GetPlayer(0).GetComponent<Player>();
        _player.gameObject.SetActive(true);

        System.Random random = new System.Random();

        //Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector2(random.Next(0, Camera.main.pixelWidth),
        //           random.Next(0, Camera.main.pixelHeight)), 0);

        _player.SetPosition(Vector3.zero);
    }

    public override void FixedUpdate()
    {
    }

    public override void LateUpdate()
    {
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _player.SetDistination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        _player.Move();
    }

}
