using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonData : MonoBehaviour
{
    public string filename = "";
    string path;
    public int o = 0;
    public GameObject UI;
    public text txt;
   

    public string Name;
    public string Age;
    public List<string> Lines = new List<string>();

    GameData gameData = new GameData();

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);
      
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void NL()
    {
        if (o >= Lines.Count)
            {
                o = 0;
            UI.SetActive(false);

        }
        else if(o < Lines.Count)
        {
            txt.Setline();
            Debug.Log(Lines[o]);
            o++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if (Input.GetKeyDown(KeyCode.S))
        if (other.gameObject.CompareTag("player"))
        {
            gameData.name = (Name);
            gameData.age = (Age);
            gameData.lines = (Lines);
            UI.SetActive(true);
            SaveData();
            Debug.Log("yes");
            
            ReadData();
            txt.Setline();

        }
    }


    void SaveData()
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.gameData = gameData; 
        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(path, contents);
    }

    void ReadData()

    {
        try {
            if (System.IO.File.Exists(path))
            {
                string contents = System.IO.File.ReadAllText(path);
                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                gameData = wrapper.gameData;
                Debug.Log("Hello i am " + gameData.name + ", i am " + gameData.age + " years old " + gameData.lines[o]);
            }

            else
            {
                Debug.Log("you dont exist");
                gameData = new GameData();
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }

    }
}
