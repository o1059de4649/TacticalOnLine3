using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.Asteroids;
using Photon.Realtime;

public class StaticDataBase : MonoBehaviourPunCallbacks {
  public  static int _TeamNumber;
    public LobbyMainPanel lobby;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        // シーンの読み込みコールバックを登録.
       // SceneManager.sceneLoaded += OnLoadedScene;
    }
	
	// Update is called once per frame
	void Update () {
        if (PhotonNetwork.InRoom && _TeamNumber == 0)
        {
            _TeamNumber = lobby._TeamNumber;
        }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MyPlayer")
        {
            SceneLoadCustom();
        }
    }

    public void SceneLoadCustom()
    {


        if (PhotonNetwork.IsMasterClient)SceneManager.LoadScene("Scene/MainField");
        



    }
    /*
    private void OnLoadedScene(Scene i_scene, LoadSceneMode i_mode)
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        // シーンの遷移が完了
        if (i_scene.name == "Scene/MainField")
        {
          //  GameObject.Find("MyPlayer").GetComponent<PhotonView>().RPC("OnDestroy", RpcTarget.AllBuffered);
        }
    }*/
}
