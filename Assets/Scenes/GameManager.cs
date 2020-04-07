using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject nameText;
    public GameObject namePanel;
    public GameObject nameInput;

    public GameObject specimen;

    void Update()
    {
        happinessText.GetComponent<Text>().text = "" + specimen.GetComponent<Specimen>().Gethappiness;
        hungerText.GetComponent<Text>().text = "" + specimen.GetComponent<Specimen>().Gethunger;
        nameText.GetComponent<Text>().text = specimen.GetComponent<Specimen>().Name;
    }

    public void triggerNamePanel(bool b)
    {
        namePanel.SetActive(!namePanel.activeInHierarchy);

        if (b)
        {
            specimen.GetComponent<Specimen>().Name = nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString("Name", specimen.GetComponent<Specimen>().Name);
        }
    }

    public void buttonBehaviour(int i)
    {
        switch (i)
        {
            case (0):
            default:
                break;
            case (1):
                break;
            case (2):
                break;
            case (3):
                specimen.GetComponent<Specimen>().saveRobot();
                Application.Quit();
                break;
        }
    }
}
