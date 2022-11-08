using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using TMPro;

public class PoseDetector : MonoBehaviour
{
    public List<ActiveStateSelector> poses;

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var pose in poses)
        {
            pose.WhenSelected += () => SetTextToPoseName(pose.gameObject.name);
            pose.WhenUnselected += () => SetTextToPoseName("");
        }
    }

    // Update is called once per frame
    private void SetTextToPoseName(string newText)
    {
        Console.WriteLine(newText);
    }
}
