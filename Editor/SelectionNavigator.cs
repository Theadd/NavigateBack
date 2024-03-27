using UnityEditor;
using Object = UnityEngine.Object;

namespace Space3x.NavigateBack.Editor
{
    public static class SelectionNavigator
    {
        private static GenericNavigator<Object> _navigator = new GenericNavigator<Object>();
        
        static SelectionNavigator() {}

        [MenuItem("Edit/Navigate Back &LEFT", false, priority: 0)]
        public static void Back() => _navigator.Back();

        [MenuItem("Edit/Navigate Back &LEFT", true, priority: 0)]
        public static bool CanGoBack() => _navigator.CanGoBack();

        [MenuItem("Edit/Navigate Forward &RIGHT", false, priority: 0)]
        public static void Forward() => _navigator.Forward();

        [MenuItem("Edit/Navigate Forward &RIGHT", true, priority: 0)]
        public static bool CanGoForward() => _navigator.CanGoForward();
    }
}
