using System;

namespace DaisyControl.Server.DaisyMind.Modules.Memory.Objects
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class UserModel
    {
        // ********************************************************************
        //                            Properties
        // ********************************************************************
        public DateTime BirthDay { get; set; } = DateTime.MinValue;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
