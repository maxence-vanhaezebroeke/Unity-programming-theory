using UnityEngine;

// INHERITANCE
public class PremiumBread : Bread
{
    [SerializeField]
    [Tooltip("Particle played when premium bread is toasted (because it's so shiny...)")]
    private ParticleSystem _toastedBreadParticleSystem;

    // INHERITANCE
    public override float CookingTime
    {
        get
        {
            // Premium bread is so easy to cook...
            return .5f;
        }
    }

    protected override void Awake() 
    {
        base.Awake();

        if (_toastedBreadParticleSystem == null)
            throw new UnassignedReferenceException("_toastedBreadParticleSystem is not assigned.");    
    }

    // Called when it's toasted, not by an ordinary toaster, but by a PRE-MIUM toaster
    public void PremiumToast()
    {
        Toast();
        _toastedBreadParticleSystem.Play();
    }
}
