// GENERATED AUTOMATICALLY FROM 'Assets/Prefabs/MainPlayerAsset/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterConrols"",
            ""id"": ""d15a7f23-34b6-46fd-a164-c1054d137949"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c14240f1-e3eb-4862-9197-92502b010d95"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""1ed94191-b8af-43eb-bd29-476fe97be6ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""137aa5dd-9866-4044-9256-5b7a281e6252"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9e9509ab-adad-4a1e-a3c5-2db4387a8771"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""85694698-5058-43ed-b760-9a1ccfc84f2d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6a665e96-9b35-4454-b1b5-ae005e028998"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a4a819f3-fdde-4769-bce5-6562dfd6407a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a7c02bad-b871-4aec-9f63-3bd0f301f3ec"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2df911e3-a7f0-4558-ab66-8370994a48d6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1b45db65-95b3-49cb-abc3-ffbdd5693c46"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7a08801-9244-4e20-b93a-a8fa499a3b06"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c58eb9d5-b885-47ab-9f04-e2d75fc4b628"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66bdbf37-f4da-4737-bb8f-c3a108b70a19"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterConrols
        m_CharacterConrols = asset.FindActionMap("CharacterConrols", throwIfNotFound: true);
        m_CharacterConrols_Move = m_CharacterConrols.FindAction("Move", throwIfNotFound: true);
        m_CharacterConrols_Run = m_CharacterConrols.FindAction("Run", throwIfNotFound: true);
        m_CharacterConrols_Jump = m_CharacterConrols.FindAction("Jump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // CharacterConrols
    private readonly InputActionMap m_CharacterConrols;
    private ICharacterConrolsActions m_CharacterConrolsActionsCallbackInterface;
    private readonly InputAction m_CharacterConrols_Move;
    private readonly InputAction m_CharacterConrols_Run;
    private readonly InputAction m_CharacterConrols_Jump;
    public struct CharacterConrolsActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterConrolsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterConrols_Move;
        public InputAction @Run => m_Wrapper.m_CharacterConrols_Run;
        public InputAction @Jump => m_Wrapper.m_CharacterConrols_Jump;
        public InputActionMap Get() { return m_Wrapper.m_CharacterConrols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterConrolsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterConrolsActions instance)
        {
            if (m_Wrapper.m_CharacterConrolsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterConrolsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_CharacterConrolsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public CharacterConrolsActions @CharacterConrols => new CharacterConrolsActions(this);
    public interface ICharacterConrolsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
