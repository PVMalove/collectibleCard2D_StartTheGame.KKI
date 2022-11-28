using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NextMovePanel : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private Button _okButton;
        [SerializeField] private GameObject _gameStatusPanel;

        private void Awake()
        {
            _game.moveEnded.AddListener(() =>
            {
                gameObject.SetActive(true);
                _gameStatusPanel.SetActive(false);
            });
            _okButton.onClick.AddListener(MoveNext);
        }

        private void MoveNext()
        {
            _game.NextMove();
            gameObject.SetActive(false);
            _gameStatusPanel.SetActive(true);
        }
    }
}
