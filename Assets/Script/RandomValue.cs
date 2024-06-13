using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomValue : MonoBehaviour
{
    public int minValue;
    public int maxValue;
    public int numberOfValuesToGenerate;

    public GameObject[] Q;
    public GameObject panel;
    public static int[] index;

    bool flag;

    void Start()
    {
        //setRandomNum();
    }

    private void Update()
    {
        if(panel.GetComponent<EventPanel>().flag)
        {
            if (!flag)
            {
                flag = true;

                setRandomNum();
                for (int i = 0; i < Q.Length; i++)
                {
                    Q[i].GetComponent<Question>().question = index[i];
                }
            }
        }
        else
        {
            flag = false;
        }
    }


    void setRandomNum()
    {
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

        int cnt = 0;
        index = new int[generatedValues.Count];

        foreach (int value in generatedValues)
        {
            //Debug.Log(value);
            index[cnt] = value;
            cnt++;
        }
    }
}
