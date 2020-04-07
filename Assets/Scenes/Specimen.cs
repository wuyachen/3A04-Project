using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Specimen : MonoBehaviour
{
    [SerializeField]
    private int hunger;
    [SerializeField]
    private int happiness;
    [SerializeField]
    private string _name;

    public int count;
    private bool serverTime;
    
    void Start()
    {
        PlayerPrefs.SetString("then", "04/06/2020 12:20:12");
        UpdateStatus();
        if (!PlayerPrefs.HasKey("Name"))
                PlayerPrefs.SetString("Name", "Specimen");
            _name = PlayerPrefs.GetString("Name");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject.tag == "Speci")
                {
                    count++;
                    if (count >= 3)
                    {
                        count = 0;
                        updateHappiness(1);
                    }
                }
            }
        }
    }

    void UpdateStatus()
    {
        if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("hunger", hunger);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("hunger");
        }

        if (!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetInt("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }

        if (!PlayerPrefs.HasKey("then"))
            PlayerPrefs.SetString("then", getStringTime());

        TimeSpan ts = GetTimeSpan();

        hunger -= (int)(ts.TotalHours * 3);
        if (hunger < 0)
            hunger = 0;

        happiness -= (int)((100 - hunger) * (ts.TotalHours / 4));
        if (happiness < 0)
            happiness = 0;

        if (serverTime)
            updateServer();
        else
            InvokeRepeating("updateDevice", 0f, 30f);
    }

    private void updateServer()
    {
        throw new NotImplementedException();
    }

    TimeSpan GetTimeSpan()
    {
        if (serverTime)
            return new TimeSpan();
        else
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + "!" + now.Minute + ":" + now.Second;
    }

    void UpdateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    public int Gethunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int Gethappiness
    {
        get { return happiness; }
        set { happiness = value; }
    }

    public string Name
    {
        get { return _name;
        }
        set { _name = value; }
    }
    public void updateHappiness(int i)
    {
        Gethappiness += i;
        if (Gethappiness > 100)
            Gethappiness = 100;
    }

    public void saveRobot()
    {
        if (!serverTime)
        {
            UpdateDevice();
        }
        PlayerPrefs.SetInt("hunger", hunger);
        PlayerPrefs.SetInt("happiness", happiness);
    }
}