using System;
namespace AdventOfCode.src.Utilities {
    public interface IChallengeAnswerer {
        string[] ReceiveInput(); 
        string ProvideAnswer();
    }
}
