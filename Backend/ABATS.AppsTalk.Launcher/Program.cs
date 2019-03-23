using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime;

namespace ABATS.AppsTalk.Launcher
{
    /// <summary>
    /// ABATS.AppsTalk.Launcher - Entry Point
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Entry Point
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            using (ExecutionManager exeManager = new ExecutionManager())
            {
                exeManager.TryExecute(CoreUtilities.BuildParameters(args));
            }
        }
    }
}