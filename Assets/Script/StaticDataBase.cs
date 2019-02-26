using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticDataBase : MonoBehaviour {
  public  static int _TeamNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MyPlayer")
        {
            _TeamNumber = other.gameObject.GetComponent<MovePlayer>()._teamNumber;
            Invoke("SceneLoadCustom", 2.6f);
        }
    }

    public void SceneLoadCustom()
    {
        SceneManager.LoadScene("Scene/MainField");
    }
}
