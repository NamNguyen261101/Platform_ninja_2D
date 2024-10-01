using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData
{
    public float _hp;
    public int _level;
    public string _name;

    public UnitData() { }
    public UnitData(float _hp, int _level, string _name) 
    
    { 
        this._hp = _hp;
        this._level = _level;
        this._name = _name;
    }

    private string KEY_DATA;
    public void SaveUnitData(UnitData unitData)
    {
        string s = JsonConvert.SerializeObject(unitData);
        PlayerPrefs.SetString(KEY_DATA, s);
    }

    private UnitData LoadUnitData()
    {
        string s = PlayerPrefs.GetString(KEY_DATA);
        if (string.IsNullOrEmpty(s))
        {
            return new UnitData();
        }
        return JsonConvert.DeserializeObject<UnitData>(s);

    }
}
