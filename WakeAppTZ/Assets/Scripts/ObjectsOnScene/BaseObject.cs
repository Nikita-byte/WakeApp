using UnityEngine;


public abstract class BaseObject : MonoBehaviour
{
    public abstract void Move();
    public abstract void Death();
    public abstract void SetPosition(Vector3 vector);
    public abstract void SetDistination(Vector3 vector);
}
