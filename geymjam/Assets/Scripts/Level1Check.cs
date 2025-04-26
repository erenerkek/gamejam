using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Check : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetInt("listindex", 0) == 0) PlayerPrefs.SetInt("listindex", 1);
    }
}
