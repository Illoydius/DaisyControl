using System.Collections.Generic;
using System.Linq;
using DaisyControl.Common.DaisyCommon.Managers;
using DaisyControl.Server.DaisyMind.Modules.Memory.Objects;

namespace DaisyControl.Server.DaisyMind.Modules.Memory
{
    /// <summary>
    /// A DaisyMindMemoryModel represents everything that the DaisyMind knows and could remembers.
    /// </summary>
    public class DaisyMindMemoryModel
    {
        // ********************************************************************
        //                            Public
        // ********************************************************************
        public bool AddNewUser(UserModel aUserModel)
        {
            if (this.Relations.Any(a => a.UserTarget.FirstName.Equals(aUserModel.FirstName) && a.UserTarget.LastName.Equals(aUserModel.LastName)))
            {
                LogManager.LogToFile("99A8785B-475F-4C02-BCE9-42867B5E7C42", $"User of name [{aUserModel.FirstName} {aUserModel.LastName}] already exists. Can't create user.");
                return false;
            }

            this.Relations.Add(new RelationModel
            {
                UserTarget = aUserModel
            });

            return true;
        }

        // ********************************************************************
        //                            Properties
        // ********************************************************************
        public List<RelationModel> Relations { get; set; } = new();
        public SelfMemoryModel Self { get; set; } = new();
    }
}
