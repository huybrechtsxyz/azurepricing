using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace AzureApp.Client.Shared
{
    public static class RazorPageHelper
    {
        public static string GetDisplayName<T>()
        {
            var attribute = typeof(T).GetCustomAttribute(typeof(System.ComponentModel.DisplayNameAttribute)) as System.ComponentModel.DisplayNameAttribute;
            return attribute?.DisplayName ?? "";
        }

        public static string GetDisplayName<T>(string propertyname)
        {
            MemberInfo property = typeof(T).GetProperty(propertyname)!;
            var attribute = property.GetCustomAttribute(typeof(System.ComponentModel.DisplayNameAttribute)) as System.ComponentModel.DisplayNameAttribute;
            return attribute?.DisplayName ?? propertyname;
        }

        public static string ValidatePageAction(string action)
        {
            action = string.IsNullOrEmpty(action) ? string.Empty : action.ToLower();
            if (action == "create" || action == "edit" || action == "delete")
                return action;
            return "list";
        }
    }
}
