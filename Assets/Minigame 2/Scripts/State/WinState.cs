using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace typeProtect {
    public class WinState : IMinigameState
    {
        private MinigameStateManager stateManager;
        public WinState(MinigameStateManager manager) {
            stateManager = manager;
        }
        public void EnterState()
        {
            stateManager.cutscene.SetActive(true);
            stateManager.animator.SetTrigger("Win");
            // if(stateManager.cutscene.activeSelf) {
            //     // play animation
            // }
            stateManager.manager.WinMinigame();
            
        }
        public void UpdateState()
        {
            
        }

        public void ExitState()
        {
            
        }

    }
}
