namespace Mupsee.Models.User
{
    /// <summary>
    /// This method holds all dummy users for login purposes
    /// </summary>
    public class DummyUsers
    {
        public static List<UserModelViewModel> Users = new List<UserModelViewModel>()
        {
            new UserModelViewModel() { Email = "dummy_user@mail.com", Password = "Dummy_user", Username = "Dummy" },
        };
    }
}
