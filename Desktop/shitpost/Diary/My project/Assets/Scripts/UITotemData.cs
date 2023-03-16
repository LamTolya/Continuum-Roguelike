using UnityEngine;
using TMPro;

public class UITotemData: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TotemNameText;
    [SerializeField] private TextMeshProUGUI TotemDescription;

    private void OnEnable()
    {
        TotemEnter.TotemEntered += UpdateTotemData;
        TotemEnter.TotemExited += ExitTotemData;
    }
    private void OnDisable()
    {
        TotemEnter.TotemEntered -= UpdateTotemData;
        TotemEnter.TotemExited -= ExitTotemData;
    }


    void UpdateTotemData(TotemData totemData)
    {
        TotemNameText.enabled = true;
        TotemDescription.enabled = true;
        TotemNameText.text = totemData.Name;
        TotemDescription.text = totemData.TotemDescription;
    }

    void ExitTotemData()
    {
        TotemNameText.enabled = false;
        TotemDescription.enabled = false;

    }
}

