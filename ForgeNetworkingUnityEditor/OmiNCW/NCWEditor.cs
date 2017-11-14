using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEditor.IMGUI.Controls;

namespace ForgeNetworkingUnityEditor.Community.Omi.NetworkClassEditor {
    class NCWEditorWindow : EditorWindow {

        public const string EDITOR_RESOURCES_DIR = "BMS_Forge_Editor";

        NCWTreeView m_NCWTreeView;

        public static Texture2D tex_Class;
        public static Texture2D tex_Rpc;
        public static Texture2D tex_Attr;

        [SerializeField]
        TreeViewState m_NCWTreeViewState;

        [MenuItem("Window/Forge Networking/Network Contract Wizard (Omi)")]
        public static void ShowWindow() {
            // Get existing open window or if none, make a new one:

            var window = GetWindow<NCWEditorWindow>();
            window.titleContent = new GUIContent("Network Behaviors");
            window.Show();
        }

        void OnEnable() {
            // Check if we already had a serialized view state (state 
            // that survived assembly reloading)
            if (m_NCWTreeViewState == null)
                m_NCWTreeViewState = new TreeViewState();

            tex_Class = Resources.Load<Texture2D>("Star");
            tex_Attr = Resources.Load<Texture2D>("SideArrow");
            tex_Rpc = Resources.Load<Texture2D>("Add");

            m_NCWTreeView = new NCWTreeView(m_NCWTreeViewState);
        }

        void OnGUI() {
            DrawToolStrip();
            GUILayout.BeginHorizontal();
            m_NCWTreeView.OnGUI(new Rect(0, 16, position.width, position.height-16));
            GUILayout.EndHorizontal();
            
        }

        void DrawToolStrip() {
            GUILayout.BeginHorizontal(EditorStyles.toolbar);
            if (GUILayout.Button("Create New", EditorStyles.toolbarButton)) {
                OnMenu_Create();
                EditorGUIUtility.ExitGUI();
            }
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Reimport", EditorStyles.toolbarButton)) {
                OnMenu_Create();
                EditorGUIUtility.ExitGUI();
            }
            if (GUILayout.Button("Rebuild", EditorStyles.toolbarButton)) {
                OnMenu_Create();
                EditorGUIUtility.ExitGUI();
            }
            if (GUILayout.Button("Resources", EditorStyles.toolbarDropDown)) {
                GenericMenu toolsMenu = new GenericMenu();
                toolsMenu.AddItem(new GUIContent("Open GitHub Wiki"), false, OnTools_Wiki);
                toolsMenu.AddItem(new GUIContent("Open User Manual"), false, OnTools_Manual);
                // Offset menu from right of editor window
                toolsMenu.DropDown(new Rect(Screen.width - 216 - 40, 0, 0, 16));
                EditorGUIUtility.ExitGUI();
            }
            GUILayout.EndHorizontal();
        }
        void OnMenu_Create() {
            // Do something!
        }
        void OnTools_OptimizeSelected() {
            // Do something!
        }
        void OnTools_Wiki() {
            Help.BrowseURL("https://github.com/BeardedManStudios/ForgeNetworkingRemastered/wiki");
        }
        void OnTools_Manual() {
            Help.BrowseURL("http://docs.forgepowered.com/");
        }
    }
}
