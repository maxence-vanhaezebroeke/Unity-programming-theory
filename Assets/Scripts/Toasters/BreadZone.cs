using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BreadZone : MonoBehaviour
{
    public Action<Bread> OnBreadEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider pOther)
    {
        Bread lBread = pOther.GetComponent<Bread>();
        // If bread enters bread zone
        if (lBread != null)
        {
            OnBreadEnter.Invoke(lBread);
        }
    }
}
