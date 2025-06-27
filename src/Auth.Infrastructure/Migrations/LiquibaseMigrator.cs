using Auth.Infrastructure.Logging;
using System.Diagnostics;

namespace Auth.Infrastructure.Migrations
{
    public static class LiquibaseMigrator
    {

        public static void Run()
        {
            StaticLogger.Info("Starting Liquibase migration...");
            var batFilePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "scripts", "run-liquibase.bat");
            var fullPath = Path.GetFullPath(batFilePath);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fullPath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = Path.GetDirectoryName(fullPath)
                }
            };

            try
            {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    StaticLogger.Error($"Liquibase migration failed: output {output}");
                    StaticLogger.Error($"Error Message: {error}");
                    Environment.Exit(process.ExitCode);
                }

                StaticLogger.Info("Liquibase migration completed:");
                StaticLogger.Info(output);
            }
            catch (Exception ex)
            {
                StaticLogger.Error($"Failed to start Liquibase migration: {ex.Message}");
                Environment.Exit(1);
            }

        }

    }
}
