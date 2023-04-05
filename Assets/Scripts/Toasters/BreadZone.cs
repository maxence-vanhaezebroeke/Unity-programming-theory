using System;
using System.Collections;
using UnityEngine;

// Bread detection for toasters
[RequireComponent(typeof(BoxCollider))]
public class BreadZone : MonoBehaviour
{    
    private readonly Vector3 BREAD_ZONE_OFFSET = new Vector3(0f, .02f, 0f);

    [SerializeField]
    [Tooltip("Time in seconds that will disable bread detection when bread is thrown out of the zone. NOTE : if value is too low, bread won't have time to come out, so be careful !")]
    private float _delayedDetectionTime = 1.0f;

    public Action<Bread> OnBreadEnter;

    private Bread _insertedBread;
    public Bread Bread
    {
        get { return _insertedBread; }
    }

    // Like an on/off switch for trigger detection
    private bool _isDetecting = true;

    public void ThrowOutBread()
    {
        if (_insertedBread == null)
        {
            Debug.Log("Inserted bread null?");
            return;
        }

        TurnDetectionOff();
        _insertedBread.SetKinematic(false);
        _insertedBread.ThrowUp(.4f);
        StartCoroutine(nameof(DelayedTurnDetectionOn));
    }

    private void SwitchDetection(bool pNewDetectionValue)
    {
        _isDetecting = pNewDetectionValue;
    }

    private void TurnDetectionOn()
    {
        SwitchDetection(true);
    }

    private void TurnDetectionOff()
    {
        SwitchDetection(false);
    }

    private IEnumerator DelayedTurnDetectionOn()
    {
        yield return new WaitForSeconds(_delayedDetectionTime);
        TurnDetectionOn();
    }

    void OnTriggerEnter(Collider pOther)
    {
        if (!_isDetecting)
            return;

        Bread lBread = pOther.GetComponent<Bread>();
        // If bread enters bread zone, and there is no bread currently in
        if (_insertedBread == null && lBread != null)
        {
            OnBreadTriggerEnter(lBread);
        }
    }

    void OnBreadTriggerEnter(Bread pBread)
    {
        _insertedBread = pBread;
        // Setting bread at correct place in toaster
        pBread.SetKinematic(true);
        pBread.transform.position = transform.position + BREAD_ZONE_OFFSET;
        // Will notify toaster that bread is now inserted
        OnBreadEnter.Invoke(pBread);
    }

    void OnTriggerExit(Collider pOther)
    {
        Bread lBread = pOther.GetComponent<Bread>();
        // If bread is kinematic, it means that we're manipulating it inside the toaster.
        // Bread will later exit the toaster but with kinematic, so wait for this moment !
        if (lBread && !lBread.IsKinematic && lBread == _insertedBread)
        {
            _insertedBread = null;
        }
    }
}
