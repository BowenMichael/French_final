using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options
{
    [SerializeField] string _french;
    [SerializeField] string _english;

    public Options(string french, string english)
    {
        this._french = french;
        this._english = english;
    }

    public string getFrench()
    {
        return _french;
    }
    public string getEnglish()
    {
        return _english;
    }
}
