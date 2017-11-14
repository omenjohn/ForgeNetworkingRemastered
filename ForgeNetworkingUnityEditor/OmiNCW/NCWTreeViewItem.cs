using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace ForgeNetworkingUnityEditor.Community.Omi.NetworkClassEditor {
    class NCWTreeViewItem : TreeViewItem {

        public TreeViewItem BaseClass() {
            TreeViewItem ret = this;
            return ret;
        }

        public static List<TreeViewItem> BaseClassList(List<NCWTreeViewItem> list) {
            List<TreeViewItem> ret = new List<TreeViewItem>();
            foreach (NCWTreeViewItem view in list) {
                TreeViewItem newRetItem = view;
                ret.Add(newRetItem);
            }
            return ret;
        }
    }
}
