using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Photon.Pun.Demo.Asteroids
{

    public class GameControl : MonoBehaviourPunCallbacks {

        public LobbyMainPanel lobbyMainPanel;
    // Use this for initialization
    void Start() {
            lobbyMainPanel.JoinRoomCustomMethod();
        }

        // Update is called once per frame
        void Update() {

        }
    }
}