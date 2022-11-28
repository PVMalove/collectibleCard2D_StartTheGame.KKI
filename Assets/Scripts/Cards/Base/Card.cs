using System;
using Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Cards.Base
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField] private CardClass _class = CardClass.Non;
        [SerializeField] private bool _isLegendary;
        [SerializeField] private string _name;
        [SerializeField] [TextArea] private string _description;
        [SerializeField] public Sprite _sprite;
        [SerializeField] private int _price;
        [SerializeField] private CanvasGroup _canvasGroup;

        private Player _owner;
        private Vector2 _startPosition;
        public bool IsCanDrag;

        //
        [Header("Outline")]
        public Image CardOutline;
        [SerializeField] private Color _readyColor;
        
        private int _index;
        public bool IsCardOnBoard;
        //

        public Player Owner => _owner;

        public int Price => _price;

        public string Name => _name;

        public string Description => _description;

        public CardClass Class => _class;

        private void OnValidate()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            if (_owner.Force >= _price && !IsCardOnBoard)
            {
                CardOutline.gameObject.SetActive(true);
                CardOutline.color = _readyColor;
            }
            else
                CardOutline.color = Color.clear;
        }

        public void InitOwner(Player owner)
        {
            _owner = owner;
        }

        public void OnBeginDrag(PointerEventData eventData) //Начать перетаскивание
        {
            if (IsCanDrag)
            {
                _canvasGroup.blocksRaycasts = false;
                _startPosition = transform.position;
            }
        }

        public void OnDrag(PointerEventData eventData) //Перетаскивание
        {
            if (!IsCanDrag)
                return;

            Vector3 screenPoint = eventData.position;
            screenPoint.z = 10.0f; //distance of the plane from the camera
            transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        }

        public void OnEndDrag(PointerEventData eventData) // Закончить перетаскивание
        {
            if (IsCanDrag)
            {
                _canvasGroup.blocksRaycasts = true;
                transform.position = _startPosition;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (IsCardOnBoard || _owner.CurrentPhase == Phase.Attack || _owner.CurrentPhase == Phase.Defend)
                return;

            ShowCardInfo();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (IsCardOnBoard || _owner.CurrentPhase == Phase.Attack || _owner.CurrentPhase == Phase.Defend)
                return;

            HideCardInfo();
        }

        private void ShowCardInfo()
        {
            GetComponentInParent<HorizontalLayoutGroup>().enabled = false;

            _index = transform.GetSiblingIndex();
            transform.SetAsLastSibling();

            transform.localScale = new Vector2(1.2f, 1.2f);
            transform.localPosition = new Vector2(transform.localPosition.x, 205);
        }

        private void HideCardInfo()
        {
            GetComponentInParent<HorizontalLayoutGroup>().enabled = true;
            transform.SetSiblingIndex(_index);
            
            transform.localScale = new Vector2(1f, 1f);
            transform.localPosition = new Vector2(transform.localPosition.x, 0);
        }
    }
}