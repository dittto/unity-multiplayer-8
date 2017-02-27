using GameState;
using UnityEngine;

namespace Assets.Level {
    class LevelStart:MonoBehaviour {

        public void Start()
        {
            Debug.Log("Level Start");
            State.GetInstance()
                .Level(State.LEVEL_READY)
                .Publish();
        }
    }
}
