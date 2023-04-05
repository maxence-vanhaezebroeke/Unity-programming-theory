using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Food : MonoBehaviour
{
    // ENCAPSULATION - only public getters or protected variables
    public virtual float CookingTime
    {
        get
        {
            return 10f;
        }
    }

    public bool IsKinematic
    {
        get
        {
            return _rb.isKinematic;
        }
    }

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected Rigidbody _rb;

    public void SetKinematic(bool pIsKinematic)
    {
        _rb.isKinematic = pIsKinematic;
    }

    // Will add up force to the food, with a little twist (like if someone is throwing the food, not perfectly up)
    public void ThrowUp(float pForceValue)
    {
        // Flip coin for direction
        int lRandomDirection = Random.Range(0, 2) == 0 ? 1 : -1;
        // Find random force in random direction
        Vector3 lRandomXForce = new Vector3(Random.Range(.05f, .3f), 0f, 0f) * lRandomDirection;

        _rb.AddForce((Vector3.up + lRandomXForce) * pForceValue, ForceMode.Impulse);
        _rb.AddTorque(lRandomXForce * 1.5f, ForceMode.Impulse);
    }
}
