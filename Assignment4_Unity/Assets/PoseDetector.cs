using System;
using System.Collections.Generic;
using System.Linq;
using Oculus.Interaction;
using UnityEngine;
using Random = System.Random;

public class PoseDetector : MonoBehaviour
{
    public List<ActiveStateSelector> poses; 
    private string _cactusPose;
    private readonly string[] _cactusChoices = new[] { "rock", "paper", "scissors" };

    private readonly Dictionary<string, string> _choices = new()
    {
        { "rock", "scissors" },
        { "paper", "rock" },
        { "scissors", "paper" },
    };
    void Start()
    {
        
        _cactusPose = GenerateRandomMove();
        foreach (var pose in poses)
        {
            pose.WhenSelected += () => ValidateCactusMove(MapToCorrectInput(pose.gameObject.name));
            pose.WhenUnselected += RestartGame;
        }
    }

    private void RestartGame()
    {
        _cactusPose = GenerateRandomMove();
    }


    private void ValidateCactusMove(string choice)
    {
        if (_choices[choice] == _cactusPose)
        {
            print("Player won");
        }
        
        if (_choices[_cactusPose] == choice)
        {
            print("Cactus won");
        }
        
        if (choice == _cactusPose)
        {
            print("Draw");
        }
    }

    private string GenerateRandomMove()
    {
        var rnd = new Random();
        return  _cactusChoices.ElementAt(rnd.Next(_cactusChoices.Length));
    }

    private string MapToCorrectInput(string choice)
    {
        return choice switch
        {
            "ScissorsPose" => "scissors",
            "RockPose" => "rock",
            "PaperPose" => "paper",
            _ => ""
        };
    }
}
