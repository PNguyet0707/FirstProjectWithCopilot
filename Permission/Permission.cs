namespace Permission
{
    public class Permission
    {
        public UserType UserType { get; set; }
        public PermissionCategory Category  {get; set;}
        public ActionUnit Action { get; set;}

    }
    [Flags]
    public enum UserType
    {
        None = 0,
        User = 1,
        Addmin = 2,        
    }
    [Flags]
    public enum PermissionCategory
    {
        None = 0,
        Cat = 1,
        Dog = 2,
        Panda = 4,
    }
    [Flags]
    public enum ActionUnit
    {
        None = 0,
        Post = 1,
        React = 2,
        Share = 4,
        Comment = 8,
    }
}
