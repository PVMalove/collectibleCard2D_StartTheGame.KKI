using System.Linq;
using Cards.UnitEffects;
using Core;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Cards.Base
{
    public class UnitCard : Card, IPointerClickHandler
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [CanBeNull] [SerializeField] private UnitStartEffect _startEffect;

       
        
        private Status _status = Status.NonBoard;
        private int _startHealth;

        public Status Status => _status;
        public int Damage => _damage;
        public int Health => _health;

        public UnityEvent<Status> statusChanged;
        public UnityEvent<int> healthChanged;
        public UnityEvent<UnitCard> cardClicked;

        private void Awake()
        {
            _startHealth = _health;
        }

        // На доске
        public void OnGoInBoard(bool isStart)
        {
            _status = Status.FirstTurn;
            statusChanged?.Invoke(_status);
            
            if (isStart && _startEffect)
                _startEffect.MakeStartEffect();
            
            Debug.Log($"{Owner.name}: {Name} вступает в бой");
        }

        public void ResetCard()
        {
            _status = Status.NonBoard;
            _health = _startHealth;
        }

        public void SetCanAct()
        {
            _status = Status.CanAct;
            statusChanged?.Invoke(_status);
        }

        public void SetCannotAct()
        {
            _status = Status.NotCanAct;
            statusChanged?.Invoke(_status);
        }

        public void Attack()
        {
            _status = Status.Attacker;
            statusChanged?.Invoke(_status);
            Debug.Log(_status);
        }

        public void Defend()
        {
            if (!Owner.InBoardCards.FirstOrDefault(card => card.Status == Status.Defender)
                && Game.Enemy.InBoardCards.FirstOrDefault(card => card.Status == Status.Attacker))
            {
                _status = Status.Defender;
                statusChanged?.Invoke(_status);
            }
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            healthChanged?.Invoke(_health);
            if (_health <= 0)
                Debug.Log($"{Name} ушла в отбой");
        }
        
        //
        public void SetHealth(int value)
        {
            _health = value;
            healthChanged?.Invoke(_health);
        }
        //

        public void OnPointerClick(PointerEventData eventData)
        {
            cardClicked?.Invoke(this);
            
            Debug.LogWarning("OnPointerClick == UnitCard");
            
            if (_status == Status.CanAct)
            {
                if (Owner.CurrentPhase == Phase.Attack)
                    Attack();
                if (Owner.CurrentPhase == Phase.Defend)
                    Defend();
            }
        }
    }

    public enum Status
    {
        OnGoInBoard,
        NonBoard,
        FirstTurn,
        NotCanAct,
        CanAct,
        Attacker,
        Defender
    }
}