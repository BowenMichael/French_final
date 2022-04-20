using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsHolder : MonoBehaviour
{
    public Text t;
    Options op;
    public Options Option
    {
        get
        {
            return op;
        }
        set
        {
            op = value;
            t.text = value.getFrench();
        }
    }

}
