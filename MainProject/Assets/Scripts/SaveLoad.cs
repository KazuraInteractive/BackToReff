using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveLoad : MonoBehaviour {

    public int saveLvl;
    public int loadLvl = 0;
    public string fileName = "SaveData";
    public bool isCrypt;

    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("saveInt", saveLvl);
    }

    public void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("saveInt")) loadLvl = PlayerPrefs.GetInt("saveInt");
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter(Application.dataPath + "/" + fileName + ".ncs");
        string sp = " ";
        sw.WriteLine(Crypt("key_int" + sp + saveLvl));

        sw.Close();
    }

    void LoadFile()
    {
        if (File.Exists(Application.dataPath + "/" + fileName + ".ncs"))
        {
            string[] rows = File.ReadAllLines(Application.dataPath + "/" + fileName + ".ncs");

            int _i;
            if (int.TryParse(GetValue(rows, "key_int"), out _i)) loadLvl = _i;

            rows = new string[0];
        }
    }

    string Crypt(string text)
    {
        if (!isCrypt) return text;

        string result = string.Empty;
        foreach (char j in text)
        {
            result += (char)((int)j ^ 49);
        }

        return result;
    }

    string GetValue(string[] line, string pattern)
    {
        string result = "";
        foreach (string key in line)
        {
            if (key.Trim() != string.Empty)
            {
                string value = "";
                if (isCrypt) value = Crypt(key); else value = key;

                if (pattern == value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0])
                {
                    result = value.Remove(0, value.IndexOf(' ') + 1);
                }
            }
        }
        return result;
    }
}
