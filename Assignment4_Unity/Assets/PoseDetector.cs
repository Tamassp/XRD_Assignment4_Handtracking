using System;
using System.Collections.Generic;
using System.Linq;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class PoseDetector : MonoBehaviour
{
    public List<ActiveStateSelector> poses; 
    private string _cactusPose;
    private readonly string[] _cactusChoices = new[] { "rock", "paper", "scissors" };
    
    public Animator m_Animator;
    public SpriteRenderer rockImage;
    public SpriteRenderer paperImage;
    public SpriteRenderer scissorsImage;
    public GameObject backgroundCube;
    
    private Color green = new Color(0,255,0);
    private Color red = new Color(255,0,0);
    private Color draw = new Color(15, 15, 255);

    private readonly Dictionary<string, string> _choices = new()
    {
        { "rock", "scissors" },
        { "paper", "rock" },
        { "scissors", "paper" },
    };
    void Start()
    {
        ResetIcons();
        _cactusPose = GenerateRandomMove();
        foreach (var pose in poses)
        {   
            
            pose.WhenSelected += () => ValidateCactusMove(MapToCorrectInput(pose.gameObject.name));
            pose.WhenUnselected += RestartGame;
        }
        
        
    }

    private void RestartGame()
    {
        ResetIcons();
        _cactusPose = GenerateRandomMove();
        ValidateMoveIcon(_cactusPose);
        backgroundCube.GetComponent<Renderer>().material.color = new Color(255,255,255);
    }


    private void ValidateCactusMove(string choice)
    {
        if (_choices[choice] == _cactusPose)
        {
            print("Player won");
            m_Animator.SetTrigger("triggerGetsHit");
            backgroundCube.GetComponent<Renderer>().material.color = green;
        }
        
        if (_choices[_cactusPose] == choice)
        {
            print("Cactus won");
            m_Animator.SetTrigger("triggerAttack");
            backgroundCube.GetComponent<Renderer>().material.color = red;
        }
        
        if (choice == _cactusPose)
        {
            print("Draw");
            backgroundCube.GetComponent<Renderer>().material.color = draw;
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

    private void ValidateMoveIcon(string choice)
    {
        //rockImage.enabled = true;
        switch (choice)
        {
            case "rock":
                rockImage.enabled = true;
                break;
            case "paper":
                paperImage.enabled = true;
                break;
            case "scissors":
                scissorsImage.enabled = true;
                break;
        }
    }

    private void ResetIcons()
    {
        rockImage.enabled = false;
        paperImage.enabled = false;
        scissorsImage.enabled = false;
    }
}
