using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    [SerializeField]
    private BreadZone _breadZone;

    private Bread _insertedBread;

    public virtual float CookingTime { get; set; }

    void Awake()
    {
        if (_breadZone == null)
        {
            throw new UnassignedReferenceException("_breadZone");
        }

        _breadZone.OnBreadEnter += BreadZone_OnBreadEnter;
    }

    private void BreadZone_OnBreadEnter(Bread pBread)
    {
        StartCoroutine(nameof(CookBread));
    }

    private IEnumerator CookBread()
    {
        yield return new WaitForSeconds(CookingTime);
        _insertedBread.Toast();
    }

    void OnDestroy()
    {
        _breadZone.OnBreadEnter -= BreadZone_OnBreadEnter;
    }

}
