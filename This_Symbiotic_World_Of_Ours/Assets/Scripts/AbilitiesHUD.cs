using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesHUD : MonoBehaviour
{
    public PlayerMovement movementScript;
    public CharacterController2D controllerScript;

    [Header("Dash")]
    public Image abilityDashImageBW;
    bool dashIsCooldown = false;

    [Header("Double Jump")]
    public Image abilityDoubleJumpImageBW;

    [Header("Ranged Attack")]
    public Image abilityAttackImageBW;
    public Image abilityAttackImage;

    [Header("Charged Attack")]
    public Image abilityChargeAttackImageBW;
    public Image abilityChargeAttackImage;

    [Header("Glide")]
    public Image abilityGlideImageBW;
    public Image abilityGlideImage;

    [Header("Luminate")]
    public Image abilityLuminateImageBW;
    public Image abilityLuminateImage;

    // Start is called before the first frame update
    void Start()
    {
        abilityDashImageBW.fillAmount = 1;
        abilityDoubleJumpImageBW.fillAmount = 1;
        abilityAttackImageBW.fillAmount = 1;
        abilityChargeAttackImageBW.fillAmount = 1;
        abilityGlideImageBW.fillAmount = 1;
        abilityLuminateImageBW.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        AbilityDash();
        AbilityDoubleJump();
        AbilityAttack();
        AbilityChargeAttack();
        AbilityGlide();
        AbilityLuminate();
    }


    void AbilityLuminate()
    {
        if (!controllerScript.LightPowerup) { abilityLuminateImageBW.fillAmount = 1; return; }
        else { abilityLuminateImageBW.fillAmount = 0; }

        if (!movementScript.isLight) { abilityLuminateImage.color = new Color(0,1,0); }
        else { abilityLuminateImage.color = new Color(1, 1, 1); }
    }
    void AbilityGlide()
    {
        if (!controllerScript.GlidePowerup) { abilityGlideImageBW.fillAmount = 1; return; }
        else { abilityGlideImageBW.fillAmount = 0; }

        //If the player is gliding, change colour of ability to show useage
        if (movementScript.isGliding){ abilityGlideImage.color = new Color(0, 1, 0); }
        else{ abilityGlideImage.color = new Color(1, 1, 1); }
    }
    void AbilityChargeAttack()
    {
        if (!controllerScript.ChargeAttackPowerup) { abilityChargeAttackImageBW.fillAmount = 1; }
        else { abilityChargeAttackImageBW.fillAmount = 0; }
    }
    void AbilityAttack()
    {
        if (!controllerScript.AttackPowerup) { abilityAttackImageBW.fillAmount = 1; }
        else { abilityAttackImageBW.fillAmount = 0; }
    }
    void AbilityDoubleJump()
    {
        if (controllerScript.extraJumps == 0) { abilityDoubleJumpImageBW.fillAmount = 1; return; }

        if (controllerScript.jumpsLeft >= 0)
        {
            abilityDoubleJumpImageBW.fillAmount = 0;
        }
        else
        {
            abilityDoubleJumpImageBW.fillAmount = 1;
        }
    }
    void AbilityDash()
    {
        if (!controllerScript.DashPowerup) { abilityDashImageBW.fillAmount = 1; return; }
        else if (controllerScript.DashPowerup && dashIsCooldown == false) { abilityDashImageBW.fillAmount = 0; }

        if (movementScript.isDashing)
        {
            dashIsCooldown = true;
            abilityDashImageBW.fillAmount = 1;
        }
        else 
        {
            abilityDashImageBW.fillAmount -= 1 / (movementScript.dashingCooldown + 0.25f) * Time.deltaTime;

            if (abilityDashImageBW.fillAmount <= 0)
            {
                abilityDashImageBW.fillAmount = 0;
                dashIsCooldown = false;
            }
        }
    }
}
