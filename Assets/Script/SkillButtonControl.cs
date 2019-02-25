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

    public string[] skillname = { "Smash","Sting","Ground","FireWave","WaterDragon","FireDragon","GroundFire","IceSpike","GroundMana" };
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
        commandPlayer = GetComponentInParent<CommandPlayer>();
        movePlayer = GetComponentInParent<MovePlayer>();
        _button_hideTime = 0.45f;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (movePlayer._animatorStateInfo.IsTag("AttackSkill")|| movePlayer._animatorStateInfo.IsTag("Damage")|| movePlayer._animatorStateInfo.IsTag("Teleport")||isClicked) return;

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

        if (this.gameObject.name == "UpperCutButton")
        {
            commandPlayer.UpperCutSmash();
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
