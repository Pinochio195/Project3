using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

namespace Ring
{
    #region Component
    [Serializable]
    public class GameController
    {
        [ChangeColorLabel(0.2f, 1, 1)] public List<BotController> _listBot;
        [ChangeColorLabel(0.2f, 1, 1)] public List<BotController> _listBotInDeathZone;
        [ChangeColorLabel(0.2f, 1, 1)] public List<Transform> _listPositionMove;

    }
    [Serializable]
    public class BotManager
    {
        [ChangeColorLabel(0.2f, 1, 1)] public Animator _animator;
        [ChangeColorLabel(0.2f, 1, 1)] public List<Material> _ShortMaterialsRandom;
        [ChangeColorLabel(0.2f, 1, 1)] public List<Texture> _ShortSpritesRandom;
        [ChangeColorLabel(0.2f, 1, 1)] public SkinnedMeshRenderer _ShortSkinnedMeshRendererBot;
        [ChangeColorLabel(0.2f, 1, 1)] public Material _ShortMaterialBot;
        [ChangeColorLabel(0.2f, 1, 1)] public SkinnedMeshRenderer _BodySkinnedMeshRendererBot;
        [Space(2)]
        [ChangeColorLabel(0.2f, 1, 1)] public List<GameObject> _listAccessory;
        [ChangeColorLabel(0.2f, 1, 1)] public CheckPlayer _checkPlayer;
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "Check State Của Enemy")]
        [ChangeColorLabel(0.2f, 1, 1)] public bool _isCheckDieEnemy;
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "AI Nav Mesh")]
        [ChangeColorLabel(0.2f, 1, 1)] public NavMeshAgent _navMeshAgent;
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "Die bot")]
        [ChangeColorLabel(0.2f, 1, 1)] public Collider _collider;
        [ChangeColorLabel(0.2f, 1, 1)] public Rigidbody _rigidbody;
        [ChangeColorLabel(0.2f, 1, 1)] public GameObject _listCirlce;
        [ChangeColorLabel(0.2f, 1, 1)] public ParticleSystem _particleSystem;

    }
    [Serializable]
    public class PlayerController
    {
        [ChangeColorLabel(0.2f, 1, 1)] public Rigidbody _rigidbody;
        [ChangeColorLabel(0.2f, 1, 1)] public Animator _animator;
        [ChangeColorLabel(0.2f, 1, 1)] public Transform _mesh;
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "Dùng để vẽ ra deadzone để hiển thị trên game / không sử dụng trong code")]
        [Range(0.1f,15f)]
        [ChangeColorLabel(0.2f, 1, 1)] public float radius;
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "Hướng bắn/di chuyển của player")]
        [ChangeColorLabel(0.2f, 1, 1)] public Vector3 _direction;
        [ChangeColorLabel(0.2f, 1, 1)] public Vector3 _currentDirection;
        [HideInInspector] public BotController _botController;
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "Điểm bắt đầu của player")]
        [ChangeColorLabel(0.2f, 1, 1)] public List<Transform> _listTransformStart;
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "Attack cho Player")]
        [ChangeColorLabel(0.2f, 1, 1)] public Attack _attackEvent;
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "Check List Enemy")]
        [ChangeColorLabel(0.2f, 1, 1)] public CheckListEnemy _checkListEnemy;

    }
    [Serializable]
    public class PlayerWeapon
    {
        [HeaderTextColor(0.8f, 1f, 1f, headerText = "Nơi sinh ra vũ khí của player")]
        [ChangeColorLabel(0.2f, 1, 1)] public Transform _transformWeapon;
        [ChangeColorLabel(0.2f, 1, 1)] public GameObject  _weaponPlayerThrowed;
        //[ChangeColorLabel(0.2f, 1, 1)] public List<GameObject>  _listWeaponPrefabs;

    }

    [Serializable]
    public class MusicController
    {
        [ChangeColorLabel(0.2f, 1, 1)] public AudioSource audioSource_;
        [ChangeColorLabel(0.9f, .55f, .95f)] public AudioClip audioClip_;
    }

    [Serializable]
    public class UiController
    {
        [ChangeColorLabel(0.2f, 1, 1)] public GameObject _winGameObject;
        [ChangeColorLabel(0.2f, 1, 1)] public GameObject _settingGameObject;
    }

    [Serializable]
    public class CheckScene
    {
        [ChangeColorLabel(.7f, 1f, 1f)] public bool _isGetCurrentNameScene;
        [ChangeColorLabel(.7f, 1f, 1f)] public string _nameSceneChange;
    }

    #endregion

    #region Text Color

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(HeaderTextColorAttribute))]
    public class HeaderTextColorDecorator : DecoratorDrawer
    {
        private GUIStyle headerStyle;
        private bool initialized;

        private void InitGUIStyle()
        {
            headerStyle = new GUIStyle(GUI.skin.label);
            headerStyle.fontStyle = FontStyle.Bold;
            headerStyle.normal.textColor = ((HeaderTextColorAttribute)attribute).color;
            initialized = true;
        }

        public override float GetHeight()
        {
            /*if (!initialized)
            {
                InitGUIStyle();
            }*/

            return EditorGUIUtility.singleLineHeight * 2;
        }

        public override void OnGUI(Rect position)
        {
            if (!initialized)
            {
                InitGUIStyle();
            }

            HeaderTextColorAttribute attribute = (HeaderTextColorAttribute)this.attribute;
            string headerText = attribute.headerText;

            Rect labelRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth + 500, 50);
            EditorGUI.LabelField(labelRect, headerText, headerStyle);
        }
    }

    [CustomPropertyDrawer(typeof(ChangeColorLabelAttribute))]
    public class RedLabelDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Get the color from the attribute
            ChangeColorLabelAttribute changeColorLabelAttribute = (ChangeColorLabelAttribute)attribute;
            Color labelColor = changeColorLabelAttribute.color;

            // Set the color
            GUIStyle coloredLabelStyle = new GUIStyle(EditorStyles.label) { normal = { textColor = labelColor } };
            float originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = EditorStyles.label.CalcSize(label).x;

            // Draw the colored label
            EditorGUI.LabelField(position, label, coloredLabelStyle);

            // Draw the property without the label
            EditorGUIUtility.labelWidth = originalLabelWidth;
            position.x += EditorGUIUtility.labelWidth;
            position.width -= EditorGUIUtility.labelWidth;
            EditorGUI.PropertyField(position, property, GUIContent.none, true);

            EditorGUI.EndProperty();
        }
    }
#endif

    public class HeaderTextColorAttribute : PropertyAttribute
    {
        public Color color;
        public string headerText;

        public HeaderTextColorAttribute(float r, float g, float b, float a = 1.0f, string headerText = "")
        {
            color = new Color(r, g, b, a);
            this.headerText = headerText;
        }
    }

    public class ChangeColorLabelAttribute : PropertyAttribute
    {
        public Color color;

        public ChangeColorLabelAttribute(float r, float g, float b, float a = 1.0f)
        {
            color = new Color(r, g, b, a);
        }
    }

    #endregion

    #region Editor Window

#if UNITY_EDITOR

    #region Save Position Object

    public class SavingPositionObject : EditorWindow
    {
        Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();

        #region Saving Position Object

        [MenuItem("Window/Save Position/Saving Position Object")]
        public static void ShowWindow()
        {
            GetWindow<SavingPositionObject>("Saving Position Object");
        }

        void OnEnable()
        {
            EditorApplication.playModeStateChanged += HandlePlayModeChange;
        }

        void OnDisable()
        {
            EditorApplication.playModeStateChanged -= HandlePlayModeChange;
        }

        void HandlePlayModeChange(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                LoadPositions();
                Debug.Log(1);
            }
        }

        void OnGUI()
        {
            if (GUILayout.Button("Save Positions"))
            {
                SavePositions();
            }
        }

        void SavePositions()
        {
            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                originalPositions[obj] = obj.transform.position;
            }
        }

        void LoadPositions()
        {
            foreach (KeyValuePair<GameObject, Vector3> entry in originalPositions)
            {
                if (entry.Key != null)
                {
                    entry.Key.transform.position = entry.Value;
                }
            }
        }

        #endregion
    }

    public class ObjectPositionSaverEditor : EditorWindow
    {
        Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();

        #region Object Position Saver

        [MenuItem("Window/Save Position/Object Position Saver")]
        public static void ShowWindow()
        {
            GetWindow<ObjectPositionSaverEditor>("Object Position Saver");
        }

        void OnGUI()
        {
            if (GUILayout.Button("Save Positions"))
            {
                SavePositions();
            }

            if (GUILayout.Button("Load Positions"))
            {
                LoadPositions();
            }
        }

        void SavePositions()
        {
            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                originalPositions[obj] = obj.transform.position;
            }
        }

        void LoadPositions()
        {
            foreach (KeyValuePair<GameObject, Vector3> entry in originalPositions)
            {
                entry.Key.transform.position = entry.Value;
            }
        }

        #endregion
    }

    #endregion

#endif

    #endregion

    #region Base Method

    public abstract class RingSingleton<T> : MonoBehaviour where T : RingSingleton<T>
    {
        private static T _instance;

        public enum ChangeDestroy
        {
            DontDestroy,
            Destroy
        }

        public ChangeDestroy _changDestroy = ChangeDestroy.Destroy;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        Debug.LogError("An instance of " + typeof(T) +
                                       " is needed in the scene, but there is none.");
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            _instance = (T)this;
            if (_changDestroy == ChangeDestroy.DontDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }
            
            
        }
    }

    #endregion
}