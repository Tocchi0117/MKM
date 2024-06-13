using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomValue : MonoBehaviour
{
    public int minValue;
    public int maxValue;
    public int numberOfValuesToGenerate;

    int cnt = 0;
    int[] index;
    public GameObject[] obj;

    void Start()
    {
        setRandomNum();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && cnt<obj.Length)
        {
            obj[index[cnt]].SetActive(true);
            cnt++;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cnt = 0;
            setRandomNum();
        }
    }


    void setRandomNum()
    {
        index = new int[numberOfValuesToGenerate];
        for (int i = 0; i < numberOfValuesToGenerate; i++)
        {
            obj[i].SetActive(false);
        }

        if (maxValue - minValue + 1 < numberOfValuesToGenerate)
        {
            Debug.LogError("Range of values is smaller than the number of values to generate.");
            return;
        }

        System.Random rand = new System.Random();
        HashSet<int> generatedValues = new HashSet<int>();

        while (generatedValues.Count < numberOfValuesToGenerate)
        {
            int randomValue = rand.Next(minValue, maxValue + 1);
            generatedValues.Add(randomValue);
        }

        foreach (int value in generatedValues)
        {
            Debug.Log(value);
            index[cnt] = value;
            cnt++;
        }
        cnt = 0;
    }
}
