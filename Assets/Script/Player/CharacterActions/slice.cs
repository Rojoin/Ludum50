using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EzySlice;

public class slice : MonoBehaviour
{
    public GameObject objectToSlice; // non-null

     void OnShoot()
     {
         SlicedHull Slice(Vector3 planeWorldPosition, Vector3 planeWorldDirection) {
	return objectToSlice.Slice(planeWorldPosition, planeWorldDirection);
}
     }
/**
 * Example on how to slice a GameObject in world coordinates.
 */
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
