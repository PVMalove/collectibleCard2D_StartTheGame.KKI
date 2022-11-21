using Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cards.Base
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        //
        Transform parentReturnTo = null; // Return to hand canvas
        //
        
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
        public Player Owner => _owner;
        public int Price => _price;
        public string Name => _name;
        public string Description => _description;
        public CardClass Class => _class;

        private void OnValidate()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
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
            // if (!IsCanDrag) return;
            //
            // parentReturnTo = this.transform.parent;
            // transform.SetParent(this.transform.parent.parent, false);
            //
            // _canvasGroup.blocksRaycasts = false;
            
        }

        public void OnDrag(PointerEventData eventData) //Перетаскивание
        {
            // if (IsCanDrag)
            //     transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
            if (!IsCanDrag) return;

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
            // if (!IsCanDrag) return;
            //
            // transform.SetParent(parentReturnTo, false);
            // _canvasGroup.blocksRaycasts = true;

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // if (!IsCanDrag) 
            //     return;
        
            transform.localScale = new Vector2(1.2f, 1.2f);
            transform.localPosition = new Vector2(transform.localPosition.x, 205);
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            // if (!IsCanDrag) 
            //     return;
        
            transform.localScale = new Vector2(1f, 1f);
            transform.localPosition = new Vector2(transform.localPosition.x, 0);
        }
    }
}