using UnityEngine;

public enum StatType { Strength, Speed, Defense }

public class PlayerStats : MonoBehaviour
{
    public int strength = 0;
    public int speed = 0;
    public int defense = 0;

    public void IncreaseStat(StatType statType, int amount)
    {
        switch (statType)
        {
            case StatType.Strength:
                strength += amount;
                break;
            case StatType.Speed:
                speed += amount;
                break;
            case StatType.Defense:
                defense += amount;
                break;
        }
        Debug.Log(statType + " Αυ°΅µΚ: " + amount);
    }
}
