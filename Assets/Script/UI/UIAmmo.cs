using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIAmmo : MonoBehaviour
{
    public TMP_Text magazine;
    public TMP_Text reserve;
    private void OnEnable()
    {
        AmmoSystem.OnMagazineChange += ChangeMagazine;
        AmmoSystem.OnReserveChange += ChangeReserve;
    }
    private void OnDisable()
    {
        AmmoSystem.OnMagazineChange -= ChangeMagazine;
        AmmoSystem.OnReserveChange -= ChangeReserve;

    }
    void ChangeMagazine(int newValue)
    {
        magazine.text = newValue.ToString();
    }
    void ChangeReserve(int newValue)
    {
        reserve.text = newValue.ToString();
    }
}
