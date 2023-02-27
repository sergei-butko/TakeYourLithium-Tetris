using UnityEditor;
using UnityEngine;

namespace Editor.TetrisEditorTemplates
{
    public class ConfiguratorEditorTemplatesWindow : EditorWindow
    {
        private const string TEXT_FIELD_LABEL = "Entity name:";
        private const string NAMESPACE_FIELD_LABEL = "Namespace:";

        private const string NOTE_LABEL = "Only use entity name without postfix (i.e. 'Tetromino', not 'TetrominoModel')";

        private const string TEMPLATES_PATH = "Assets/Editor/TetrisEditorTemplates/ScriptTemplates";
        private const string CREATE_BASE_BUTTON = "Create Base";
        private const string CREATE_SERVICE_BUTTON = "Create Service";
        private const string WINDOW_TITLE = "Tetris Editor Templates";
        private const string CS_TXT_EXTENSION = ".cs.txt";

        private const int LABEL_HEIGHT = 20;
        private const int TEXT_FIELD_MARGIN = 20;
        private const int BUTTON_SPACE = 75;

        private static readonly Vector2 NOTE_POSITION = new(0, 25);
        private static readonly Vector2 NAME_FIELD_POSITION = new(10, 50);
        private static readonly Vector2 NAMESPACE_FIELD_POSITION = new(10, 5);
        private static readonly Rect WINDOW_POSITION = new(Screen.width / 2, Screen.height / 2, 500, 100);

        private string _scriptName = "";

        private void OnGUI()
        {
            EditorSharedConstants.DefaultTemplatesNamespace = EditorGUI.TextField(
                new Rect(NAMESPACE_FIELD_POSITION, new Vector2(position.width - TEXT_FIELD_MARGIN, LABEL_HEIGHT)),
                NAMESPACE_FIELD_LABEL,
                EditorSharedConstants.DefaultTemplatesNamespace);

            EditorGUI.DropShadowLabel(
                new Rect(NOTE_POSITION, new Vector2(position.width, LABEL_HEIGHT)),
                NOTE_LABEL);

            _scriptName = EditorGUI.TextField(
                new Rect(NAME_FIELD_POSITION, new Vector2(position.width - TEXT_FIELD_MARGIN, LABEL_HEIGHT)),
                TEXT_FIELD_LABEL,
                _scriptName);

            GUILayout.Space(BUTTON_SPACE);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button(CREATE_BASE_BUTTON))
            {
                if (!string.IsNullOrWhiteSpace(_scriptName))
                {
                    CreateBase(_scriptName);
                }
            }

            if (GUILayout.Button(CREATE_SERVICE_BUTTON))
            {
                if (!string.IsNullOrWhiteSpace(_scriptName))
                {
                    CreateService(_scriptName);
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        [MenuItem("Assets/Create/Tetris/MVU Templates", false, 1)]
        public static void CreateBaseMenuItem()
        {
            var window = (ConfiguratorEditorTemplatesWindow) GetWindow(
                typeof(ConfiguratorEditorTemplatesWindow), true, WINDOW_TITLE);
            window.position = WINDOW_POSITION;
        }

        private static void CreateBase(string scriptName)
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                $"{TEMPLATES_PATH}/{EditorSharedConstants.MEDIATOR_POSTFIX}{CS_TXT_EXTENSION}",
                $"{scriptName}{EditorSharedConstants.MEDIATOR_POSTFIX}{EditorSharedConstants.CS_EXTENSION}");

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                $"{TEMPLATES_PATH}/{EditorSharedConstants.COMPONENT_POSTFIX}{CS_TXT_EXTENSION}",
                $"{scriptName}{EditorSharedConstants.COMPONENT_POSTFIX}{EditorSharedConstants.CS_EXTENSION}");

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                $"{TEMPLATES_PATH}/{EditorSharedConstants.MODEL_POSTFIX}{CS_TXT_EXTENSION}",
                $"{scriptName}{EditorSharedConstants.MODEL_POSTFIX}{EditorSharedConstants.CS_EXTENSION}");
        }

        private static void CreateService(string scriptName)
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                $"{TEMPLATES_PATH}/{EditorSharedConstants.SERVICE_POSTFIX}{CS_TXT_EXTENSION}",
                $"{scriptName}{EditorSharedConstants.SERVICE_POSTFIX}{EditorSharedConstants.CS_EXTENSION}");
        }
    }
}