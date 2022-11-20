using System;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Template.VR
{
    public class Tutorial : MonoBehaviour
    {
        public GameObject mainScene;
        public GameObject objectThatHoldsScript;
        public GameObject tutorialScene;
        public GameObject spawnRock;
        public GameObject spawnScissors;
        public GameObject spawnPaper;
        public ActiveStateSelector thumbsUp;
        public ActiveStateSelector rock;
        public ActiveStateSelector paper;
        public ActiveStateSelector scissors;
        
        private void Start()
        {
            //mainScene.SetActive(false);
            //objectThatHoldsScript.GetComponent<PoseDetector>().enabled = false;
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
                if (gameObject != null)
                {
                    Destroy(tutorialScene);
                    SceneManager.LoadScene("MasterSceen", LoadSceneMode.Single);
                }
                //mainScene.SetActive(true);
                //objectThatHoldsScript.GetComponent<PoseDetector>().enabled = true;
            };
        }   
    }
}