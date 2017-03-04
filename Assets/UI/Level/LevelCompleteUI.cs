// UI/Level/LevelCompleteUI

using GameState;
using UnityEngine;
using UnityEngine.Networking;

namespace UI.Level {
    class LevelCompleteUI : MonoBehaviour {

        public GameObject levelComplete;
        public GameObject clientLevelComplete;
        public GameObject serverLevelComplete;

        public void Start()
        {
            State.GetInstance().Subscribe(
                new StateOption()
                    .LevelState(State.LEVEL_COMPLETE),
                ShowLevelComplete
            );
        }

        public void ShowLevelComplete()
        {
            if (levelComplete == null || clientLevelComplete == null || serverLevelComplete == null) {
                return;
            }

            levelComplete.SetActive(true);
            if (State.GetInstance().Network() == State.NETWORK_CLIENT) {
                clientLevelComplete.SetActive(true);
            }
            else {
                serverLevelComplete.SetActive(true);
            }
        }

        public void ReturnToLobby()
        {
            NetworkManager.singleton.ServerChangeScene("Lobby");
        }
    }
}
