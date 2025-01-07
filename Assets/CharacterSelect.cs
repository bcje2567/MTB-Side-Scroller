using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCarType(string carType)
    {
        PlayerPrefs.SetString("CarType", carType);
        Debug.Log("Car Type Set");
    }
}
