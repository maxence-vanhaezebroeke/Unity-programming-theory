using UnityEngine;

public class Food : MonoBehaviour
{
    protected virtual float FoodValue
    {
        get
        {
            return _durability * 1.5f;
        }
    }

    // Durability percentage : 1 means perfect, 0 means non-eatable
    protected float _durability = 1f;

    protected virtual void Cook() { }

    public virtual void TimePassed()
    {
        _durability -= 0.1f;
    }
}
