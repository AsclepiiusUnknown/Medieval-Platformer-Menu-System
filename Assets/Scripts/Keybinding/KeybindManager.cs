using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeybindManager : MonoBehaviour
{
    [SerializeField]
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    [System.Serializable]
    public struct KeyUISetup
    {
        public string keyName;
        public TextMeshProUGUI keyDisplay;
        public string defaultKeyCode;
    }

    public KeyUISetup[] baseKeys;
    public GameObject currentKey;
    public Color32 changedKey = Color.green;
    public Color32 errorKey = Color.red;
    public Color32 selectedKey = Color.yellow;

    void Start()
    {
        if (KeybindManager.keys.Count <= 0)
        {
            SetKeys();
        }
    }

    void SetKeys()
    {
        int x = 0;
        //Loop adds the keys to the dictionary (created above) with either save or default (depending on load)
        for (int i = 0; i < baseKeys.Length; i++) //For all the keys in the base setup array
        {
            //add keys according to the sved string or default
            keys.Add(baseKeys[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(baseKeys[i].keyName, baseKeys[i].defaultKeyCode)));

            x++;
            // print("Added key " + baseKeys[i].keyName + ": " + baseKeys[i].defaultKeyCode);

            //Change the display to what the Bind is for each UI Text component
            baseKeys[i].keyDisplay.text = keys[baseKeys[i].keyName].ToString();
        }
        print(x + " total keys added.");
        SaveKeys();
    }

    //used when we want to save the keys and changes
    public void SaveKeys()
    {
        int i = 0;
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
            i++;
            // print(key.Value + " key saved.");
        }
        PlayerPrefs.Save();
        print(i + " total keys saved.");
    }

    public void ResetKeys()
    {
        int i = 0;
        foreach (var key in keys)
        {
            PlayerPrefs.DeleteKey(key.Key);
            i++;
            // print(key.Value + " key saved.");
        }
        PlayerPrefs.Save();

        SetKeys();
        print(i + " total keys reset.");
    }

    //used to change the passed key
    public void ChangeKey(GameObject clickedKey)
    {
        currentKey = clickedKey;
        if (clickedKey != null) //if we have clicked a key and its currently selected
        {
            currentKey.GetComponent<Image>().color = selectedKey; //Create a visual element that shows the user the button was succesfully pressed
        }
    }

    //Used beacuse it allows us to run events
    private void OnGUI()
    {
        string newKey = "";
        Event e = Event.current;

        if (currentKey == null) //Fixes issues for later on by exiting the function when we dont need to use it
            return;

        if (e.isKey)
        {
            newKey = e.keyCode.ToString();
        }

        //The following fixes an issue with setting the shift keys by hard coding it im
        if (Input.GetKey(KeyCode.LeftShift))
        {
            newKey = "LeftShift";
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            newKey = "RightShift";
        }

        if (newKey != "") //if a key has been set
        {
            keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey); //Changes out the jey in the dictionary to the new one we just pressed
            currentKey.GetComponentInChildren<TextMeshProUGUI>().text = newKey; //Changes the display text to match the new key
            currentKey.GetComponent<Image>().color = changedKey; //Changes the color to show we have changed the key
            currentKey = null; //Reset the variable and wait until another has been pressed and the cycle repeats
            SaveKeys();
        }
    }
}