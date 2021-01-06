using System.IO;
using Xunit;

namespace DaisyControl.Server.DaisyMind.UnitTests
{
    public class MindTests
    {
        // ********************************************************************
        //                            Public
        // ********************************************************************
        [Fact]
        public void NewUserRelationTest()
        {
            DaisyMind _Mind = new($"{nameof(MindTests)}", new DaisyMindGenerationConfig
            {
                Personality = new DaisyMindGenerationConfig.DaisyMindGenerationPersonality
                {
                    CaringVsSelfish = 22,
                    Sadist = 11
                }
            });

            // Assure that the file doesn't exists already
            if(File.Exists(_Mind.GetFileSavePath()))
                File.Delete(_Mind.GetFileSavePath());

            _Mind.SaveMind();

            _Mind.ReloadMind();
        }
    }
}
