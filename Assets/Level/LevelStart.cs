<<<<<<< Updated upstream
﻿using GameState;
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
||||||| merged common ancestors
=======
﻿// Level/LevelStart.cs

using GameState;
using UnityEngine;

namespace Assets.Level {
    class LevelStart:MonoBehaviour {

        public void Start()
        {
            State.GetInstance()
                .Level(State.LEVEL_READY)
                .Publish();
        }
    }
}
>>>>>>> Stashed changes
