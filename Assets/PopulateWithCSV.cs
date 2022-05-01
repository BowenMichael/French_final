using System.Collections;
using System.Collections.Generic;
using SFB;
using System.IO;
using UnityEngine;

public class PopulateWithCSV : MonoBehaviour
{
    [SerializeField] PanelPopulator pp;
    public void populateCSV()
    {
        string[] path = StandaloneFileBrowser.OpenFilePanel("Open Csv", "", "csv", false);
        //FileStream fs = File.OpenRead(path[0]);
        File.ReadAllLines(path[0]);
        TextAsset asset = new TextAsset(File.ReadAllText(path[0]));
        pp.setData(asset);
    }
}
