using UnityEngine;
using TMPro;

public class UIPlayerStats: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AttackStats;
    [SerializeField] private TextMeshProUGUI DefenseStats;
    [SerializeField] private TextMeshProUGUI SpeedStats;
    [SerializeField] private TextMeshProUGUI FavorStats;
    [SerializeField] private PlayerStats PlayerStats;

    private void OnEnable()
    {
        PlayerStats.StatsChanged += UpdateStats;
        TotemEnter.TotemExited += UpdateStats;
        TotemEnter.TotemEntered += TestTotem;
    }

    private void OnDisable()
    {
        PlayerStats.StatsChanged -= UpdateStats;
        TotemEnter.TotemExited -= UpdateStats;
        TotemEnter.TotemEntered -= TestTotem;
    }

    void UpdateStats()
    {
        DefenseStats.text = PlayerStats.Defense.ToString();
        DefenseStats.color = Color.white;
        AttackStats.text = PlayerStats.AttackDamage.ToString();
        AttackStats.color = Color.white;
        SpeedStats.text = PlayerStats.Speed.ToString();
        SpeedStats.color = Color.white;
        FavorStats.text = PlayerStats.Favor.ToString();
        FavorStats.color = Color.white;
    }

    void TestTotem(TotemData totemData)
    {
        ChangeText(DefenseStats, totemData.DefenseModifier);
        DefenseStats.text = (PlayerStats.Defense+ totemData.DefenseModifier).ToString();

        ChangeText(AttackStats, totemData.DamageModifier);
        AttackStats.text = (PlayerStats.AttackDamage + totemData.DamageModifier).ToString();

        ChangeText(FavorStats, totemData.FavorModifier);
        FavorStats.text = (PlayerStats.Favor + totemData.FavorModifier).ToString();

        ChangeText(SpeedStats, totemData.SpeedModifier);
        SpeedStats.text = (PlayerStats.Speed + PlayerStats.Speed * totemData.SpeedModifier).ToString();
    }

    void ChangeText(TextMeshProUGUI tmpro, float totemIncrease)
    {
        if(totemIncrease < 0)
        {
            tmpro.color = Color.red;
        }
        if(totemIncrease > 0)
        {
            tmpro.color = Color.green;
        }
    }
}

