using UnityEngine;

// INHERITANCE
[RequireComponent(typeof(Renderer))]
public class Bread : Food
{
    [SerializeField]
    private Material _toastedMaterial;

    private Renderer _renderer;

    public override float CookingTime
    {
        get
        {
            return 3f;
        }
    }

    protected override void Awake() 
    {
        base.Awake();

        if (_toastedMaterial == null)
            throw new UnassignedReferenceException("_toastedMaterial is not assigned.");

        _renderer = GetComponent<Renderer>();
    }

    public virtual void Toast()
    {
        _renderer.material = _toastedMaterial;
    }
}
