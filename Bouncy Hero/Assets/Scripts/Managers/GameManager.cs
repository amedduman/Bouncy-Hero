using System;
using UnityEngine;
using Bouncy.Obstacles;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Bouncy.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 1;
        }

        private void OnEnable()
        {
            Enemy.OnLevelEnd += LevelEnd;
            BadFigure.OnLevelFailed += LevelFailed;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }

        void LevelFailed()
        {
            Time.timeScale = 0;
        }

        void LevelEnd()
        {
            Time.timeScale = 0;
        }

        public void ReStartLevel()
        {
            SceneManager.LoadScene(0);
        }
        
    }
}