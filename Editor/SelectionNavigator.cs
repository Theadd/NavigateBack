using UnityEditor;
using Object = UnityEngine.Object;

namespace Space3x.NavigateBack.Editor
{
    [InitializeOnLoad]
    public static class SelectionNavigator
    {
        private static GenericNavigator<Object> m_Navigator = new GenericNavigator<Object>();
        
        static SelectionNavigator() {}

        [MenuItem("Edit/Navigate Back &LEFT", false, priority: 0)]
        public static void Back() => m_Navigator.Back();

        [MenuItem("Edit/Navigate Back &LEFT", true, priority: 0)]
        public static bool CanGoBack() => m_Navigator.CanGoBack();

        [MenuItem("Edit/Navigate Forward &RIGHT", false, priority: 0)]
        public static void Forward() => m_Navigator.Forward();

        [MenuItem("Edit/Navigate Forward &RIGHT", true, priority: 0)]
        public static bool CanGoForward() => m_Navigator.CanGoForward();
    }
}
