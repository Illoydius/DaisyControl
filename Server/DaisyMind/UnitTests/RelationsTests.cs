using System;
using DaisyControl.Server.DaisyMind.Modules.Memory.Objects;
using Xunit;

namespace DaisyControl.Server.DaisyMind.UnitTests
{
    public class RelationsTests
    {
        // ********************************************************************
        //                            Public
        // ********************************************************************
        [Fact]
        public void NewUserRelationTest()
        {
            DaisyMind _Mind = new($"{nameof(RelationsTests)}", new DaisyMindGenerationConfig
            {
                Personality = new DaisyMindGenerationConfig.DaisyMindGenerationPersonality
                {
                    CaringVsSelfish = 75,
                    Sadist = 60
                }
            });

            _Mind.GetCopyOfMemory().AddNewUser(new UserModel
            {
                FirstName = $"{nameof(RelationsTests)}001",
                LastName = "DummyLastName001",
                BirthDay = new DateTime(1992,06,17)
            });
        }
    }
}
