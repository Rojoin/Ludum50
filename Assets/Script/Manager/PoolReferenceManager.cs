using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReferenceManager : MonoBehaviour
{
 public GameObject playerOBJ;

     public static GameObject staticPlayer;
    void Awake() 
    {
        staticPlayer = playerOBJ;
    }
 }