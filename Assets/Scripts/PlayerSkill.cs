using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private Button skillButton;
    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private float cooldownTime = 15f;
    private bool isCooldown = false;
    private float cooldownTimer = 0f;
    [SerializeField] private SkillPool skillPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ActivateSkill();
        }
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownOverlay.fillAmount = 1 - (cooldownTimer / cooldownTime);

            if (cooldownTimer <= 0f)
            {
                isCooldown = false;
                cooldownOverlay.fillAmount = 1f;
                skillButton.interactable = true;
            }
        }
    }
    public void ActivateSkill()
    {
        if (!isCooldown)
        {
            skillPool.FireRockets();
            isCooldown = true;
            cooldownTimer = cooldownTime;
            cooldownOverlay.fillAmount = 0f;
            skillButton.interactable = false;
        }
    }
}
