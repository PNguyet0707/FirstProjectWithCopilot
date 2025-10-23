namespace MemeWorld.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public PermissionCategory Category  {get; set;}
        public ActionUnit Action { get; set;}
        public string Description { get; set;}
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
