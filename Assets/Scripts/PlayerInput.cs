// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

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
            ""name"": ""SeedControls"",
            ""id"": ""da34893f-92f5-4455-be29-c2b0d6299f57"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7dbeff38-de40-47c2-b1bf-ecec9ef23beb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""e85838ff-8346-44aa-b896-1adde36f2b8f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""6aa7feda-579c-4e0f-8a4a-ccea0c1d9c5f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kill"",
                    ""type"": ""Button"",
                    ""id"": ""9cdee0fb-a2b5-4312-96c1-327c7ae5a676"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""74dd09c5-333b-4cc6-9067-5d09e582ac25"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""78ae911c-7427-4602-9d8c-c5b3e060db5f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1cdf74c5-0d10-4ff4-a725-3d1681c77859"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b992cb14-6437-41ab-96c6-427741e886d9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""674573af-a762-4f15-9f13-3a9158360838"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5796ad39-3fea-4d65-aec9-2690aeb429f1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a98698b1-1869-49ba-893f-73502216fdf0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72240fdb-fe7a-4e50-a7cf-d05fd114f35e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68fe329d-220c-4ecf-9691-95460968169e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff9d067b-d14f-4331-b0a7-d280d399de88"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a64b8e27-2b97-46b5-8a00-9e5723b9041e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29c9245f-5477-4ffd-8681-6d5b5b9995f7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""3c843cca-323d-4b00-a7a3-d84d21b7e836"",
            ""actions"": [
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""cdaddad9-fb33-445a-bee0-0aa4a9bceecf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""5023af85-ddc7-4d0d-b87c-4d0268bd9403"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e56e9a96-4fe4-4ecd-b213-469b19882d30"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98c37c1d-010b-4641-9200-9c5c56a92095"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5f505c3-f947-49dd-8719-03a0d0cbd9ad"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""433ea464-fc03-4371-818f-6cb819d3f18c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SeedControls
        m_SeedControls = asset.FindActionMap("SeedControls", throwIfNotFound: true);
        m_SeedControls_Movement = m_SeedControls.FindAction("Movement", throwIfNotFound: true);
        m_SeedControls_Select = m_SeedControls.FindAction("Select", throwIfNotFound: true);
        m_SeedControls_Cancel = m_SeedControls.FindAction("Cancel", throwIfNotFound: true);
        m_SeedControls_Kill = m_SeedControls.FindAction("Kill", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Start = m_MainMenu.FindAction("Start", throwIfNotFound: true);
        m_MainMenu_Quit = m_MainMenu.FindAction("Quit", throwIfNotFound: true);
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

    // SeedControls
    private readonly InputActionMap m_SeedControls;
    private ISeedControlsActions m_SeedControlsActionsCallbackInterface;
    private readonly InputAction m_SeedControls_Movement;
    private readonly InputAction m_SeedControls_Select;
    private readonly InputAction m_SeedControls_Cancel;
    private readonly InputAction m_SeedControls_Kill;
    public struct SeedControlsActions
    {
        private @PlayerInput m_Wrapper;
        public SeedControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_SeedControls_Movement;
        public InputAction @Select => m_Wrapper.m_SeedControls_Select;
        public InputAction @Cancel => m_Wrapper.m_SeedControls_Cancel;
        public InputAction @Kill => m_Wrapper.m_SeedControls_Kill;
        public InputActionMap Get() { return m_Wrapper.m_SeedControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SeedControlsActions set) { return set.Get(); }
        public void SetCallbacks(ISeedControlsActions instance)
        {
            if (m_Wrapper.m_SeedControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnMovement;
                @Select.started -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnSelect;
                @Cancel.started -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnCancel;
                @Kill.started -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnKill;
                @Kill.performed -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnKill;
                @Kill.canceled -= m_Wrapper.m_SeedControlsActionsCallbackInterface.OnKill;
            }
            m_Wrapper.m_SeedControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Kill.started += instance.OnKill;
                @Kill.performed += instance.OnKill;
                @Kill.canceled += instance.OnKill;
            }
        }
    }
    public SeedControlsActions @SeedControls => new SeedControlsActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Start;
    private readonly InputAction m_MainMenu_Quit;
    public struct MainMenuActions
    {
        private @PlayerInput m_Wrapper;
        public MainMenuActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Start => m_Wrapper.m_MainMenu_Start;
        public InputAction @Quit => m_Wrapper.m_MainMenu_Quit;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Start.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStart;
                @Quit.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    public interface ISeedControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnKill(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnStart(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
