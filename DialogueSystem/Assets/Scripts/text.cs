using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public Text UItext;
    public JsonData JD; // this script needs to have an instance of jsondata attachted
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setline()
    {
        UItext.text = "" + JD.Lines[JD.o];
    }
}
