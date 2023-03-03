using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TextMeshProUGUI HealthText;

    [SerializeField] private GameObject Heart;

    float defaultHearts = 5;
    float currentHearts = 5;
    [SerializeField] List<Image> HeartObjects;

    private void Reset()
    {
        if(HeartObjects.Count > 0)
        {
            foreach(Image heart in HeartObjects)
            {
                heart.fillAmount = 1;
            }
            return;
        }

        for(int health = 0; health < defaultHearts; health++)
        {
            HeartObjects.Add(Instantiate(Heart.GetComponent<Image>(), gameObject.transform));
        }
        HeartObjects.Reverse();
    }

    private void Start()
    {
        Reset();
    }
    private void OnEnable()
    {
        Player.PlayerDamaged += UpdateHeath;
        Player.PlayerDied += Reset;
    }

    private void OnDisable()
    {
        Player.PlayerDamaged -= UpdateHeath;
        Player.PlayerDied -= Reset;
    }
    private void UpdateHeath()
    {
        HealthText.text = playerData.Health.ToString();
        ChangeHeart();
    }

    void ChangeHeart()
    {
        
        float change = currentHearts - playerData.Health;
        currentHearts = playerData.Health;

       foreach (Image heart in HeartObjects)
        {
            if (change == 0) return;
            if (heart.fillAmount >= change)
            {
                heart.fillAmount -= change; change = 0;
            }
            else
            {
                change -= heart.fillAmount;
                heart.fillAmount = 0;
            }
        }

    }


}