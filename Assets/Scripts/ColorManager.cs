using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;


    public Color[] CellColors;

    [Space(5)]
    public Color PoinstDarkColor;
    public Color PointsLightColor;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
