using UnityEditor;
using Object = UnityEngine.Object;

namespace Space3x.NavigateBack.Editor
{
    [InitializeOnLoad]
    public static class SelectionNavigator
    {
        private static GenericNavigator<Object> m_Navigator = new GenericNavigator<Object>();
        
        static SelectionNavigator() {}
        
#if UNITY_6000_0_OR_NEWER
        [MenuItem("Edit/Navigate Back &LEFT", false, priority: 0)]
#else
        [MenuItem("Edit/Navigate Back ^&LEFT", false, priority: 0)]
#endif
        public static void Back() => m_Navigator.Back();
        
#if UNITY_6000_0_OR_NEWER
        [MenuItem("Edit/Navigate Back &LEFT", true, priority: 0)]
#else
        [MenuItem("Edit/Navigate Back ^&LEFT", true, priority: 0)]
#endif
        public static bool CanGoBack() => m_Navigator.CanGoBack();
        
#if UNITY_6000_0_OR_NEWER
        [MenuItem("Edit/Navigate Forward &RIGHT", false, priority: 0)]
#else
        [MenuItem("Edit/Navigate Forward ^&RIGHT", false, priority: 0)]
#endif
        public static void Forward() => m_Navigator.Forward();
        
#if UNITY_6000_0_OR_NEWER
        [MenuItem("Edit/Navigate Forward &RIGHT", true, priority: 0)]
#else
        [MenuItem("Edit/Navigate Forward ^&RIGHT", true, priority: 0)]
#endif
        public static bool CanGoForward() => m_Navigator.CanGoForward();
    }
}
