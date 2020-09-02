using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temp : MonoBehaviour
{
    #region |Variables
    [SerializeField]
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode> ();

    public KeyUiSetup[] baseKeys;
    public GameObject currentKey;
    public Color selectedColor = Color.yellow;
    public Color changedColor = Color.green;
    public Color errorColor = Color.red;
    #endregion

    private void Start ()
    {
        // if ()
    }
}

[System.Serializable]
public struct KeyUiSetup
{
    public string name;
    public TextMeshProUGUI display;
    public string defaultCode;
}