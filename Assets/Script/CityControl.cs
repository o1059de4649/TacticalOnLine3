using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityControl : MonoBehaviour {

    public ArtObjectClass[] art_class;

    [System.Serializable]
    public class ArtObjectClass
    {
        public GameObject art_obj;
        public float recast_time;
        public float recast_wait_time;
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0;i < art_class.Length;i++)
        {
            if (!art_class[i].art_obj.activeSelf)
            {
                art_class[i].art_obj.SetActive(true);
            }

            art_class[i].recast_time += Time.deltaTime;
            if (art_class[i].recast_time >= art_class[i].recast_wait_time) {
                

                if (!art_class[i].art_obj.activeSelf)
                {
                   
                }
                else
                {
                    art_class[i].art_obj.SetActive(false);
                    art_class[i].recast_time = 0;
                }
               
                
            }

           
        }

       
	}
}
