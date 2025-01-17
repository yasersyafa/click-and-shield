using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;

namespace typeProtect {
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;
        public GameObject cutscene;
        public TextMeshProUGUI currentText;
        public bool isGamePaused = false;

        public RectTransform tutorialText;

        public GameObject cutsceneCanvas;
        public VideoPlayer cutscenePlayer;
        public VideoClip winClip, loseClip;

        public GameManager manager;
        
        // Start is called before the first frame update
        void Start()
        {
            tutorialText.DOAnchorPos(new Vector2(tutorialText.anchoredPosition.x, 10f), 0.3f);
            manager = GameManager.instance;
            SetState(new typeProtect.PlayState(this));
        }

        public void SetState(IMinigameState newState) {
            currentState?.ExitState();
            currentState = newState;
            currentState?.EnterState();
        }

        // Update is called once per frame
        void Update()
        {  
            currentState?.UpdateState();
        }

        public void PauseGame() {
            isGamePaused = true;
            Time.timeScale = 0;
        }

        public void ResumeGame() {
            isGamePaused = false;
            Time.timeScale = 1;
        }

        public void QuitGame() {
            manager.QuitGame();
        }
    }
}
