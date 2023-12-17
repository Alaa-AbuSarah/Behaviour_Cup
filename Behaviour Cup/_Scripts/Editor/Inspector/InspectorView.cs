using UnityEngine.UIElements;
using UnityEditor;

namespace Behaviour_Cup
{
    public class InspectorView : VisualElement
    {
        private Editor editor;

        public new class UxmlFactory : UxmlFactory<InspectorView, VisualElement.UxmlTraits> { }
        public InspectorView() { }

        public void UpdateSelection(NodeView nodeView)
        {
            Clear();

            UnityEngine.Object.DestroyImmediate(editor);

            editor = Editor.CreateEditor(nodeView.node);

            IMGUIContainer container = new IMGUIContainer(() =>
            {
                if (editor.target) editor.OnInspectorGUI();
            });

            Add(container);
        }
    }
}