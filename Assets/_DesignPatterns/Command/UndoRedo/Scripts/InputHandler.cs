using UnityEngine;
using UnityEngine.Events;

namespace DesignPatterns.Command.UndoRedo
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private UnityAction upBtnPress;
        [SerializeField] private UnityAction downBtnPress;
        [SerializeField] private UnityAction leftBtnPress;
        [SerializeField] private UnityAction rightBtnPress;
        [SerializeField] private UnityAction undoBtnPress;
        [SerializeField] private UnityAction redoBtnPress;

        private void Awake()
        {
            Locator.RegisterService(this);
        }

        private void Update()
        {
            CheckForInput();
        }

        private void CheckForInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                upBtnPress?.Invoke();
            if (Input.GetKeyDown(KeyCode.DownArrow))
                downBtnPress?.Invoke();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                leftBtnPress?.Invoke();
            if (Input.GetKeyDown(KeyCode.RightArrow))
                rightBtnPress?.Invoke();
            if (Input.GetKeyDown(KeyCode.Z))
                undoBtnPress?.Invoke();
            if (Input.GetKeyDown(KeyCode.R))
                redoBtnPress?.Invoke();
        }

        public void AddListener_upBtnPress(UnityAction callback) { upBtnPress += callback; }
        public void RemoveListener_upBtnPress(UnityAction callback) { upBtnPress -= callback; }

        public void AddListener_downBtnPress(UnityAction callback) { downBtnPress += callback; }
        public void RemoveListener_downBtnPress(UnityAction callback) { downBtnPress -= callback; }

        public void AddListener_leftBtnPress(UnityAction callback) { leftBtnPress += callback; }
        public void RemoveListener_leftBtnPress(UnityAction callback) { leftBtnPress -= callback; }

        public void AddListener_rightBtnPress(UnityAction callback) { rightBtnPress += callback; }
        public void RemoveListener_rightBtnPress(UnityAction callback) { rightBtnPress -= callback; }

        public void AddListener_undoBtnPress(UnityAction callback) { undoBtnPress += callback; }
        public void RemoveListener_undoBtnPress(UnityAction callback) { undoBtnPress -= callback; }

        public void AddListener_redoBtnPress(UnityAction callback) { redoBtnPress += callback; }
        public void RemoveListener_redoBtnPress(UnityAction callback) { redoBtnPress -= callback; }
    }
}