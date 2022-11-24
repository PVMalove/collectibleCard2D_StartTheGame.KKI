using Cards.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class CardInfoDisplay : MonoBehaviour
    {
        [SerializeField] private Card _card;
        [SerializeField] private Image _image;
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _classText;
        [SerializeField] private Text _descriptionText;
        [SerializeField] private Text _damageText;
        [SerializeField] private Text _healthText;
        [SerializeField] private Text _priceText;
        [SerializeField] private GameObject _defendStatus;
        [SerializeField] private GameObject _attackStatus;
        [SerializeField] private GameObject _price;
        private void OnValidate()
        {
            _card = GetComponent<Card>();
        }

        private void Awake()
        {
            if (_card.TryGetComponent(out UnitCard unitCard))
            {
                unitCard.healthChanged.AddListener(health => _healthText.text = health.ToString());
                unitCard.statusChanged.AddListener(status =>
                {
                    switch (status)
                    {
                        case Status.Attacker:
                            OnAttackStatus();
                            break;
                        case Status.Defender:
                            OnDefendStatus();
                            break;
                        case Status.FirstTurn:
                            OnDisablePrice();
                            break;
                        default:
                            OnAnotherStatus();
                            break;
                    }
                });
            }
        }

        private void OnEnable()
        {
            _nameText.text = _card.Name;
            _classText.text = _card.Class.ToString();
            _descriptionText.text = _card.Description;
            _priceText.text = _card.Price.ToString();
            _image.sprite = _card != null ? _card._sprite : null;
            if (_image.sprite)
                _image.enabled = true;
            else
                _image.enabled = false;
            
            if (_card.TryGetComponent(out UnitCard unitCard))
            {
                _healthText.text = unitCard.Health.ToString();
                _damageText.text = unitCard.Damage.ToString();
            }
        }

        private void OnAttackStatus()
        {
            _attackStatus.SetActive(true);
        }

        private void OnDefendStatus()
        {
            _defendStatus.SetActive(true);
        }

        private void OnDisablePrice()
        {
            _price.SetActive(false);
        }

        private void OnAnotherStatus()
        {
            _attackStatus.SetActive(false);
            _defendStatus.SetActive(false);
        }
    }
}