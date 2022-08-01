using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;

public class Multilanguage : MonoBehaviour
{
    void Awake()
    {
        LocalizationManager.Read();
        LocalizationManager.Language = "Russian";
    }
}
