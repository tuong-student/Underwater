using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsManager : MonoBehaviour
{
    public GameObject PiratePrefabs;

    public static PrefabsManager i;

    private void Awake()
    {
        if (i == null) i = this;
    }
}
