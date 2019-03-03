using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillButtonControl : MonoBehaviour,IPointerClickHandler
{
   public CommandPlayer commandPlayer;
    public MovePlayer movePlayer;

    public float _button_hideTime;
    public bool isClicked = false;

    public Image _image;
    public int skill_number;

    public string[] skillname = { "Smash","Sting","Ground","FireWave","WaterDragon","FireDragon","GroundFire","IceSpike","GroundMana" };
    // Start is called before the first frame update
    void Start()
    {
        _image = this.gameObject.GetComponent<Image>();
        this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
        commandPlayer = GetComponentInParent<CommandPlayer>();
        movePlayer = GetComponentInParent<MovePlayer>();
        _button_hideTime = 0.45f;

        //スキル番号抽出
        for (int i = 0;i < skillname.Length ;i++)
        {
            if (this.gameObject.name == skillname[i] + "Button")
            {
                skill_number = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _image.fillAmount = commandPlayer.skilldata[skill_number].recast_time / commandPlayer.skilldata[skill_number].recast_wait_time;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (movePlayer._animatorStateInfo.IsTag("AttackSkill")|| movePlayer._animatorStateInfo.IsTag("Damage")|| movePlayer._animatorStateInfo.IsTag("Teleport")||isClicked) return;
        if (commandPlayer.skilldata[skill_number].recast_time < commandPlayer.skilldata[skill_number].recast_wait_time) return;

        for (int i = 0;i < skillname.Length ;i++)
        {
            if (this.gameObject.name == skillname[i] + "Button" && movePlayer._mp > commandPlayer.skilldata[i]._mp)
            {
                commandPlayer.SkillAttack(i);
                Invoke("SetActiveOff", _button_hideTime);
                Invoke("SetActiveOn", 5);
            }
        }

        if (this.gameObject.name == "SuperArmorButton" && movePlayer._mp > 500)
        {
            commandPlayer.SuperArmorOn();
            Invoke("SetActiveOff", _button_hideTime);
            Invoke("SetActiveOn", 5);
        }

        
        isClicked = true;
    }

    void SetActiveOff()
    {
        isClicked = false;
        this.gameObject.SetActive(false);
    }

    void SetActiveOn()
    {
        this.gameObject.SetActive(true);
        

        
    }
}
