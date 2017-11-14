using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace ForgeNetworkingUnityEditor.Community.Omi.NetworkClassEditor {
    class NCWTreeView : TreeView {

        public NCWTreeView(TreeViewState treeViewState) : base(treeViewState) {
            Reload();
        }

        void AddChildren(NCWTreeViewItem parent, List<NCWTreeViewItem> children) {
            foreach (NCWTreeViewItem child in children) {
                parent.AddChild(child);
            }
        }

        protected override TreeViewItem BuildRoot() {
            // BuildRoot is called every time Reload is called to ensure that TreeViewItems 
            // are created from data. Here we just create a fixed set of items, in a real world example
            // a data model should be passed into the TreeView and the items created from the model.

            // This section illustrates that IDs should be unique and that the root item is required to 
            // have a depth of -1 and the rest of the items increment from that.

            var root = new NCWTreeViewItem { id = 0, depth = -1, displayName = "Root" };

            var list0 = new List<NCWTreeViewItem> {
                new NCWTreeViewItem {id = 2, depth = 1, displayName = "position", icon = NCWEditorWindow.tex_Attr},
                new NCWTreeViewItem {id = 3, depth = 1, displayName = "velocity", icon = NCWEditorWindow.tex_Attr},
                new NCWTreeViewItem {id = 4, depth = 1, displayName = "Jump", icon = NCWEditorWindow.tex_Rpc}
            };

            var list1 = new List<NCWTreeViewItem> {
                new NCWTreeViewItem {id = 6, depth = 1, displayName = "movement", icon = NCWEditorWindow.tex_Attr},
                new NCWTreeViewItem {id = 7, depth = 1, displayName = "buttons", icon = NCWEditorWindow.tex_Attr}
            };

            var list2 = new List<NCWTreeViewItem> {
                new NCWTreeViewItem {id = 10, depth = 1, displayName = "lastSpawnTime", icon = NCWEditorWindow.tex_Attr},
                new NCWTreeViewItem {id = 9, depth = 1, displayName = "SpawnPlayer", icon = NCWEditorWindow.tex_Rpc}
            };

            var allItems = new List<NCWTreeViewItem> {
                new NCWTreeViewItem {id = 1, depth = 0, displayName = "PlayerCharacter", icon = NCWEditorWindow.tex_Class},
                new NCWTreeViewItem {id = 5, depth = 0, displayName = "InputListener", icon = NCWEditorWindow.tex_Class},
                new NCWTreeViewItem {id = 8, depth = 0, displayName = "SpawnRegion", icon = NCWEditorWindow.tex_Class}
            };
            AddChildren(allItems[0], list0);
            AddChildren(allItems[1], list1);
            AddChildren(allItems[2], list2);

            // Utility method that initializes the TreeViewItem.children and .parent for all items.
            SetupParentsAndChildrenFromDepths(root, NCWTreeViewItem.BaseClassList(allItems));

            // Return root of the tree
            return root;
        }

        public override void OnGUI(Rect rect) {

            base.OnGUI(rect);

            Debug.Log("GUI rendering");

            Rect controlRect = EditorGUILayout.GetControlRect();

            Event current = Event.current;

            if (rect.Contains(current.mousePosition) && current.type == EventType.ContextClick) {


                int selectionId = -1;
                IList<int> selectionItems = GetSelection();
                if (selectionItems.Count > 0) {
                    selectionId = selectionItems[0];
                }

                GenericMenu menu = new GenericMenu();

                menu.AddItem(new GUIContent("Create New NetworkBehavior"), false, Edit);

                if (selectionId > -1) {
                    menu.AddItem(new GUIContent("Edit"), false, Edit);
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("Rename"), false, Edit);
                    menu.AddItem(new GUIContent("Duplicate"), false, Edit);
                    menu.AddItem(new GUIContent("Delete"), false, Delete);
                    menu.AddSeparator("");
                    menu.AddDisabledItem(new GUIContent("Regenerate code for \"_CLASS_\" only"));
                } else {
                    menu.AddDisabledItem(new GUIContent("Edit"));
                    menu.AddSeparator("");
                    menu.AddDisabledItem(new GUIContent("Rename"));
                    menu.AddDisabledItem(new GUIContent("Duplicate"));
                    menu.AddDisabledItem(new GUIContent("Delete"));
                    menu.AddSeparator("");
                    menu.AddDisabledItem(new GUIContent("Regenerate code for \"_CLASS_\" only"));
                }
                menu.ShowAsContext();

                current.Use();
            }
        }
        void Edit() {

        }
        void Delete() {

        }
    }
}
