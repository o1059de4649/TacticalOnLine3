using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

    public class OptionControl : MonoBehaviourPunCallbacks
    {
        public GameObject[] childObj;
        public GameObject[] skill_panels;
        public string[] skill_save_data;
        bool show_mode = false;
        public bool isFirstSave = true;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OffToOn()
        {
            if (!show_mode)
            {
                for (int i = 0; i < childObj.Length; i++)
                {
                    childObj[i].SetActive(true);
                }
                show_mode = true;



            }
            else
            {
                for (int i = 0; i < childObj.Length; i++)
                {
                    childObj[i].SetActive(false);
                }
                show_mode = false;

                Save();
            }





        }

        public void Save()
        {
            if (!PlayerPrefs.HasKey("SkillNote0"))
            {
                isFirstSave = true;
            }
            else
            {
                isFirstSave = false;
            }


            for (int i = 0; i < 4; i++)
            {


                skill_save_data[i] =
                skill_panels[i * 4].GetComponent<DropObject>().skill_name + "/" +
                skill_panels[1 + i * 4].GetComponent<DropObject>().skill_name + "/" +
                skill_panels[2 + i * 4].GetComponent<DropObject>().skill_name + "/" +
                skill_panels[3 + i * 4].GetComponent<DropObject>().skill_name;
                PlayerPrefs.SetString("SkillNote" + i.ToString(), skill_save_data[i]);


            }


            //初回時
            if (isFirstSave)
            {
            GetComponentInParent<SkillSlotSetSkill>().SkillSetUpStart();



                
            }
        }

        void FirstSkillSetScene()
        {
            SceneManager.LoadScene("Scene/City");
        }
    }