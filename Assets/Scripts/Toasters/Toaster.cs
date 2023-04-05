using System.Collections;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    [SerializeField]
    private BreadZone _breadZone;

    void Awake()
    {
        if (_breadZone == null)
            throw new UnassignedReferenceException("_breadZone is not assigned.");
        
        _breadZone.OnBreadEnter += BreadZone_OnBreadEnter;
    }

    private void BreadZone_OnBreadEnter(Bread pBread)
    {
        StartCoroutine(nameof(CookBread), pBread);
    }

    private IEnumerator CookBread(Bread pBread)
    {
        // Cook the bread
        yield return new WaitForSeconds(pBread.CookingTime);
        // It's now toasted !
        ToastBread(pBread);
        // Wait one second when the break is toasted before throwing it out
        yield return new WaitForSeconds(1);
        _breadZone.ThrowOutBread();
    }

    // ABSTRACTION
    // ENCAPSULATION - only to be called here or by children
    protected virtual void ToastBread(Bread pBread)
    {
        pBread.Toast();
    }

    void OnDestroy()
    {
        _breadZone.OnBreadEnter -= BreadZone_OnBreadEnter;
    }
}
