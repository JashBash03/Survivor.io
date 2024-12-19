using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] List<Abilities> abilities;
    int selectedAbilityIndex = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedAbilityIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedAbilityIndex = 1;
    }
}
