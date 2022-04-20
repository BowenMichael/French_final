using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPopulator : MonoBehaviour
{
    [SerializeField] List<Button> textOptions;
    [SerializeField] Options[] optionsData;
    [SerializeField] Text english;
    [SerializeField] object csv;
    [SerializeField] TextAsset data;
    [SerializeField] List<Options> allOptions = new List<Options>();
    [SerializeField] int numOfDemos;

    // Start is called before the first frame update
    void Start()
    {
        optionsData = new Options[textOptions.Count];
        //data = new TextAsset(csv.ToString());
        initOptions();
        PopulateOptions();
        StartCoroutine(demoPopulate(numOfDemos));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initOptions()
    {
        string[] lines = data.text.Split("\n"[0]);

        for(int i = 1; i < lines.Length; i++)
        {
            string[] lineData = lines[i].Split(","[0]);
            if (lineData.Length >= 2)
            {
                Options tmp = new Options(lineData[0], lineData[1]);
                allOptions.Add(tmp);
            }

            
        }
        Debug.LogFormat("Options init finished with {0} options loaded. Expected:{1}", allOptions.Count, lines.Length);
        
    }

    [ContextMenu("Demo Populate")]
    void PopulateOptions()
    {
        int[] indexes = new int[textOptions.Count];
        for (int i = 0; i < textOptions.Count; i++)
        {
            indexes[i] = Random.Range(0, allOptions.Count);
            Options op = allOptions[indexes[i]];
            textOptions[i].GetComponent<optionsHolder>().Option = op;
    
            
        }

        int j = indexes[Random.Range(0, indexes.Length)];
        english.text= allOptions[j].getEnglish();

    }


    IEnumerator demoPopulate(int demo = 1)
    {
        for(int i = 0; i < demo; i++)
        {
            yield return new WaitForSeconds(1.0f);
            PopulateOptions();
        }
        yield return null;
    }

    public void onButtonClick(optionsHolder oh)
    {
        if(english.text.Equals(oh.Option.getEnglish()))
        {
            english.text = "Correct!";

        }
        else
        {
            english.text = "Wrong";
        }
        StartCoroutine(demoPopulate(1));
    }
}
