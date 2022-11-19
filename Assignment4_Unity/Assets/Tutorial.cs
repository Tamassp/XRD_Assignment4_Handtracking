using System;
using Oculus.Interaction;
using UnityEngine;

namespace Unity.Template.VR
{
    public class Tutorial : MonoBehaviour
    {
        public GameObject mainScene;
        public GameObject tutorialScene;
        public GameObject spawnRock;
        public GameObject spawnScissors;
        public GameObject spawnPaper;
        public ActiveStateSelector thumbsUp;
        public ActiveStateSelector rock;
        public ActiveStateSelector paper;
        public ActiveStateSelector scissors;
        private readonly Vector3 _spawnPosRock = new(59.08213f, 26.66f, -27.69f);
        private readonly Vector3 _spawnPosPaper = new(62.20f, 26.69f, -27.69f);
        private readonly Vector3 _spawnPosScissors = new(60.70f, 26.63f, -27.69f);
        private void Start()
        {
            mainScene.SetActive(false);
            scissors.WhenSelected += () =>
            {
                spawnScissors.gameObject.transform.localScale = new Vector3(1, 1, 1);
                Instantiate(spawnScissors, transform.position, transform.rotation, tutorialScene.transform);
            };
            
            rock.WhenSelected += () =>
            {
                spawnRock.gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                Instantiate(spawnRock, transform.position, transform.rotation, tutorialScene.transform);
            };

            paper.WhenSelected += () =>
            {
                spawnPaper.gameObject.transform.localScale = new Vector3(1, 1, 1);
                Instantiate(spawnPaper, transform.position, transform.rotation, tutorialScene.transform);
            };

            thumbsUp.WhenSelected += () =>
            {
                Destroy(tutorialScene);
                mainScene.SetActive(true);
            };
        }   
    }
}