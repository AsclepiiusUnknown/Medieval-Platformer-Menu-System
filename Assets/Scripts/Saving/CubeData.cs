using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeData
{
    public float[] cubeRotation;

    public CubeData(CubeRotator cube)
    {
        cubeRotation = new float[4];

        if (cube.transform.rotation != null)
        {
            cubeRotation[0] = cube.transform.rotation.x;
            cubeRotation[1] = cube.transform.rotation.y;
            cubeRotation[2] = cube.transform.rotation.z;
            cubeRotation[3] = cube.transform.rotation.w;
        }
    }
}