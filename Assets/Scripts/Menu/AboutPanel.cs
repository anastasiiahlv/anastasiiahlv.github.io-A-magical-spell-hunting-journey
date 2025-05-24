using UnityEngine;
using TMPro;
public class AboutPanel : MonoBehaviour
{
    [Header("About section")]
    [SerializeField] private TextMeshProUGUI _aboutSection;
    [SerializeField] private string _aboutText;
    [SerializeField] private string _gameName = "Магічна Подорож: Полювання на заклинання";
    [SerializeField] private string _groupName = "ТТП-32";
    [SerializeField] private string _authorName = "Голова Анастасія Дмитрівна";

    private void Awake()
    {
        CheckFields();
        FillTextComponent();
    }

    private void OnValidate()
    {
        CheckFields();
        FillTextComponent();
    }

    private void CheckFields()
    {
        if (_aboutSection == null)
        {
            Debug.LogError($"Text component at {this.gameObject.name} was not assigned.");
        }

        if (string.IsNullOrEmpty(_aboutText))
        {
            if (string.IsNullOrEmpty(_authorName) == false &&
                string.IsNullOrEmpty(_groupName) == false &&
                string.IsNullOrEmpty(_gameName) == false)
            {
                _aboutText = $"Назва гри: {_gameName}\n" +
                    $"Виконана студенткою группи {_groupName}\n" +
                    $"{_authorName}";
            }
            else
            {
                _aboutText = $"Гра під назвою Магічна Подорож: Полювання на заклинання\n" +
                    $"Виконана студенткою группи ТТП-32\n" +
                    $"Голова Анастасія Дмитрівна";
            }
        }
    }

    private void FillTextComponent()
    {
        if (_aboutSection != null)
        {
            _aboutSection.text = _aboutText;
        }
    }
}
