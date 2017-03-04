// Player/SyncedData/LocalPlayerDataManager.cs

using GameState;
using UnityEngine;
using UnityEngine.Networking;

namespace Player.SyncedData {
    public class LocalPlayerDataManager : NetworkBehaviour {

        public PlayerDataForClients clientData;

        private string[] names = new string[] { "Adam", "Betty", "Charles", "Deborah", "Eddy", "Francis", "Gerald", "Holly" };
        private int[] teams = new int[] { PlayerDataForClients.TEAM_VIP, PlayerDataForClients.TEAM_INHUMER };

        public override void OnStartLocalPlayer()
<<<<<<< Updated upstream
        {
            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();

            State.GetInstance().Subscribe(
                new StateOption().GameState(State.GAME_OFFLINE), 
                () => {
                    if (clientData != null) {
                        clientData.SetName("");
                        clientData.SetTeam(0);
                        clientData.SetIsServerFlag(false);
                        clientData.SetIsReadyFlag(false);
                    }
                    else {
                        store.playerName = "";
                        store.team = 0;
                        store.isReady = false;
                        store.isServer = false;
                    }
                }
            );
||||||| merged common ancestors
        {
            CreateDefaultValues();
=======
        {
            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();

>>>>>>> Stashed changes
            State.GetInstance().Subscribe(
<<<<<<< Updated upstream
                new StateOption().LevelState(State.LEVEL_IN_LOBBY),
                () => {
                    if (clientData != null) {
                        clientData.SetIsReadyFlag(false);
                    }
                    else {
                        store.isReady = false;
                    }
                }
||||||| merged common ancestors
                new StateOption()
                    .GameState(State.GAME_OFFLINE), 
                ResetValues
=======
                new StateOption().GameState(State.GAME_OFFLINE), 
                () => {
                    if (clientData != null) {
                        clientData.SetName("");
                        clientData.SetTeam(0);
                        clientData.SetIsServerFlag(false);
                        clientData.SetIsReadyFlag(false);
                    }
                    else {
                        store.playerName = "";
                        store.team = 0;
                        store.isReady = false;
                        store.isServer = false;
                    }
                }
            );
            State.GetInstance().Subscribe(
                new StateOption().LevelState(State.LEVEL_IN_LOBBY),
                () => {
                    if (clientData != null) {
                        clientData.SetIsReadyFlag(false);
                    }
                    else {
                        store.isReady = false;
                    }
                }
>>>>>>> Stashed changes
            );

<<<<<<< Updated upstream
            CreateDefaultValues();
            
            clientData.SetName(store.playerName);
            clientData.SetTeam(store.team);
            clientData.SetIsReadyFlag(store.isReady);
||||||| merged common ancestors
            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();
            clientData.SetName(store.playerName);
            clientData.SetTeam(store.team);
            clientData.SetIsReadyFlag(store.isReady);
=======
            CreateDefaultValues();
            
            clientData.SetName(store.playerName);
            clientData.SetTeam(store.team);
            clientData.SetIsReadyFlag(store.isReady);
>>>>>>> Stashed changes
            clientData.SetIsServerFlag(store.isServer);

            clientData.OnNameUpdated += OnNameUpdated;
            clientData.OnTeamUpdated += OnTeamUpdated;
            clientData.OnIsReadyFlagUpdated += OnIsReadyFlagUpdated;
            clientData.OnIsServerFlagUpdated += OnIsServerFlagUpdated;
        }

        private void CreateDefaultValues ()
        {
            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();
            if (store.playerName != "" || store.team != 0 | store.isServer != false || store.isReady != false) {
                return;
            }

            store.playerName = names[Random.Range(0, 8)];
            store.team = teams[Random.Range(0, 2)];

            if (State.GetInstance().Network() == State.NETWORK_SERVER) {
                store.isServer = true;
<<<<<<< Updated upstream
            }
        }

        private void ResetValues ()
        {
            clientData.SetName("");
            clientData.SetTeam(0);
            clientData.SetIsServerFlag(false);
            clientData.SetIsReadyFlag(false);
            // LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();
            /*store.playerName = "";
            store.team = 0;
            store.isServer = false;
            store.isReady = false;*/
        }

||||||| merged common ancestors
            }
        }

        private void ResetValues ()
        {
            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();
            store.playerName = "";
            store.team = 0;
            store.isServer = false;
            store.isReady = false;
        }
        
=======
            }
        }

>>>>>>> Stashed changes
        public void OnNameUpdated(GameObject player, string newName)
        {
            LocalPlayerDataStore.GetInstance().playerName = newName;
        }

        public void OnTeamUpdated(GameObject player, int newTeam)
        {
            LocalPlayerDataStore.GetInstance().team = newTeam;
        }

        public void OnIsReadyFlagUpdated(GameObject player, bool isReady)
        {
            LocalPlayerDataStore.GetInstance().isReady = isReady;
        }

        public void OnIsServerFlagUpdated (GameObject player, bool isServer)
        {
            LocalPlayerDataStore.GetInstance().isServer = isServer;
        }
    }
}