using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JSONReader : MonoBehaviour
{

    public TextAsset jsonFile;
    public TextAsset jsonFileSpanish;

    public List<Organism> OrganismList = new List<Organism>();

    public Organism selectedOrganism;

    public GameObject organismPanel;
    public Text organismName;
    public Text organismDetails;
    public bool inSpanish = false;
    public bool started = false;
    public bool paused = false;

    public GameObject languageUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        ClearUI();
        AudioSource[] audioSorces = FindObjectsOfType<AudioSource>();

        startSpanish();
    }

    public void TogglePause() {
        paused = !paused;
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void startEnglish() {
        inSpanish = false;
        ReadDatabase();

    }
    public void startSpanish() {
        inSpanish = true;
        ReadDatabase();
    }

    void ReadDatabase() {

        //languageUI.SetActive(false);

        Organisms organismsInJson;
        
        organismsInJson = JsonUtility.FromJson<Organisms>(jsonFile.text);
        
        print(organismsInJson.organisms[0].Name);
        ClearUI();
        foreach (Organism org in organismsInJson.organisms) {
            OrganismList.Add(org);
        }

        Time.timeScale = 1.0f;
        started = true;
    }

    public void ClearUI() {

        selectedOrganism = new Organism();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (selectedOrganism.ID == -1 || !started) {
            organismPanel.SetActive(false);
        }
        else {
            organismPanel.SetActive(true);
            organismName.text = selectedOrganism.Name;
            organismDetails.text = "<i>"+selectedOrganism.Desc + "</i>\n\n" + selectedOrganism.Scientific;
        }
    }

    public void SelectOrganism(int id) {
        if (!started)
            return;
        Organism o = OrganismList[id];
        if (o != null)
            selectedOrganism = o;
    }
}
