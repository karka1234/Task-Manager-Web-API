namespace Task_Manager_Web_API.Enums
{
    public class Enums
    {
        public enum AssignmentVisibility
        {
            publicView,
            privateView
        }
        public enum JobTitle
        {
            NotAssigned,
            SoftEngineer,
            SoftDeveloper,
            SoftArchitect,
            Manager,
            TeamLead
        }
        public enum Status
        {
            NotAssigned,
            Running,
            Suspended,
            Done
        }
        public enum Role
        {
            User,
            Editor,
            Admin
        }
    }
}
