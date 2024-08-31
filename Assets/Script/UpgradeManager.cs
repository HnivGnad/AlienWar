using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {
    BulletScript bulletScript;

    [SerializeField] AudioSource cantBuy;
    [SerializeField] AudioSource buy;

    public GameObject upgradePanel;
    public GameObject upgradeButton;
    public GameObject panelCooldown;
    public GameObject panelShield;

    [SerializeField] Image[] cooldownDot;
    [SerializeField] Image[] shieldDot;

    ScoreManagerScript scoreManager;
    [SerializeField] Text costTextCooldown;
    [SerializeField] int costCooldown;

    ShieldScript shieldScript;
    [SerializeField] Text costTextShield;
    [SerializeField] int costShield;

    int costPlayer;
    int dotCooldown = 0;
    int dotShield = 0;

    float[] cooldownTime = { 1.5f, 1f, 0.5f, 0f };
    Shooting shooting;

    [SerializeField] float costMultiplier = 2.5f;

    float playerMoney;
    public int countUpgrade;
    void Start() {
        bulletScript = FindObjectOfType<BulletScript>();

        scoreManager = FindObjectOfType<ScoreManagerScript>();
        shooting = FindObjectOfType<Shooting>();
        shieldScript = FindObjectOfType<ShieldScript>();

        upgradePanel.SetActive(false);
        upgradeButton.SetActive(true);
        panelShield.SetActive(false);
        panelCooldown.SetActive(true);

    }

    void Update() {
        costPlayer = scoreManager.GetScore();
        costTextCooldown.text = "Cost:" + costCooldown.ToString();
        costTextShield.text = "Cost:" + costShield.ToString();

    }
    public void OpenUpgradePanel() {
        upgradePanel.SetActive(true);
        upgradeButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void CloseUpgradePanel() {
        upgradePanel.SetActive(false);
        upgradeButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void DotCooldownUpgrade() {
        if (dotCooldown < cooldownDot.Length && costPlayer >= costCooldown) {
            dotCooldown++;
            cooldownDot[dotCooldown - 1].color = Color.yellow;

            shooting.SetCoolDown(cooldownTime[dotCooldown - 1]);
            scoreManager.SubtractScore(costCooldown);
            costCooldown = Mathf.RoundToInt(costCooldown * costMultiplier);

            scoreManager.UpdateScore();
            countUpgrade++;
            buy.Play();
        }
        else {
            cantBuy.Play();
        }
    }
    public void DotShieldUpgrade() {
        if (dotShield < shieldDot.Length && costPlayer >= costShield) {
            dotShield++;
            shieldDot[dotShield - 1].color = Color.yellow;

            scoreManager.SubtractScore(costShield);
            costShield = Mathf.RoundToInt(costShield * costMultiplier);
            shieldScript.ShieldRepair();
            scoreManager.UpdateScore();
            countUpgrade++;
            buy.Play();

        }
        else {
            cantBuy.Play();
        }
    }
    public void CooldownButton() {
        panelShield.SetActive(false);
        panelCooldown.SetActive(true);
    }
    public void ShieldButton() {
        panelCooldown.SetActive(false);
        panelShield.SetActive(true);

    }
    public float GetCostCooldown() {
        return costCooldown;
    }
    
}
