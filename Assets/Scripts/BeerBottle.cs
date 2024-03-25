using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerBottle : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> allParts = new List<Rigidbody>();

    public void Shatter() 
    {
        foreach (Rigidbody part in allParts)
        {
            part.isKinematic = false;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
