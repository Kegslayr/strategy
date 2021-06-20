using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public enum GameState {
        Initializing = 0,
        MainMenu = 1,
        Inventory = 2,
        PlayerTurn = 4,
        EnemyTurn = 8
    };

    public class GameManager: MonoBehaviour
    {
        public static GameManager Instance;
        public Model Current;
        public UIManager UIManager;
        public GameState State { 
            get 
            { 
                if (_stateQueue.Count > 0)
                    return _stateQueue.Peek();
                return GameState.Initializing;
            }
        }

        private Stack<GameState> _stateQueue = new Stack<GameState>();

        private void Awake()
        {
            Instance = this;
            UIManager = GetComponentInChildren<UIManager>();

            // Todo: MDG For now we start in the PlayerTurn state
            PushState(GameState.PlayerTurn);
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            // Model Inventory PlayerTurn & ModelInventory
            if (Input.GetButtonUp("Inventory") && (State.HasFlag(GameState.PlayerTurn & GameState.Inventory)))
            { 
                if (Current == null)
                {
                    Debug.LogError($"Unable to access inventory because Current model is not assigned");
                    return;
                }
                ToggleCurrentInventory();
            }
        }

        private void PushState(GameState newState)
        {
            if (State != newState)
            {
                Debug.Log($"State change: {newState}");
                _stateQueue.Push(newState);
            }
        }

        private void PopState()
        {
            _stateQueue.Pop();
            Debug.Log($"State change: {_stateQueue.Peek()}");
        }

        public void ToggleCurrentInventory()
        {
            if (UIManager.ModelInventoryUI.activeSelf)
            {
                PopState();
                UIManager.ModelInventoryUI.SetActive(false);
            } else
            {
                PushState(GameState.Inventory);
                UIManager.DisplayModelInventory(Current);
            }
        }

        public void ToggleContainerInventory(Container container)
        {
            if (UIManager.ContainerInventoryUI.activeSelf)
            {
                PopState();
                UIManager.ContainerInventoryUI.SetActive(false);
            } else
            {
                PushState(GameState.Inventory);
                UIManager.DisplayContainerInventory(container);
            }
        }

        public void OnUseInventoryItem(Item item)
        {
            if (!Current) return;
            Debug.Log($"GameManager OnUseInvetoryItem: {item.name}"); 
        }

        public void OnEquipItem(Equipment equipment)
        {
            if (!Current) return;
            Debug.Log($"GameManager OnEquipItem: {equipment.name}");
            Current.Inventory.Equip(equipment);
        }

    }
}
