using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        if (!SaveLoadManager.isNewGame)
        {
            try
            {
                CubeData data = SaveSystem.LoadCube();

                float x, y, z, w;
                x = data.cubeRotation[0];
                y = data.cubeRotation[1];
                z = data.cubeRotation[2];
                w = data.cubeRotation[3];
                transform.rotation = new Quaternion(x, y, z, w);
            }
            catch
            {
                Debug.LogError("**ERROR CAUGHT** \n Save file contained no related data.");
            }

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        float x = 0, z = 0;

        if (Input.GetKey(KeybindManager.keys["Up"]))
        {
            print(KeybindManager.keys["Up"]);
            z++;
        }
        if (Input.GetKey(KeybindManager.keys["Down"]))
        {
            z--;
        }
        if (Input.GetKey(KeybindManager.keys["Left"]))
        {
            x--;
        }
        if (Input.GetKey(KeybindManager.keys["Right"]))
        {
            x++;
        }

        x *= speed * Time.deltaTime;
        z *= speed * Time.deltaTime;

        Vector3 temp = new Vector3(x, speed * Time.deltaTime, z);
        transform.Rotate(temp);
    }
}