// Declare the NuGet packages
// "System.Management": "[7.0.0]"

// Import the necessary namespaces
using System.Management;

string server = ".";
string scopeString = "\\\\serverip\\root\\cimv2";
scopeString = scopeString.Replace("serverip",server);
var scope = new ManagementScope(scopeString);
    scope.Connect();

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

try
{
    // Get total memory and free memory for the server
    var memoryQuery = new ObjectQuery("SELECT * FROM CIM_OperatingSystem");
    var memorySearcher = new ManagementObjectSearcher(scope, memoryQuery);
    var memoryCollection = memorySearcher.Get();
    var totalMemory = Math.Round(Convert.ToDouble(memoryCollection.Cast<ManagementObject>().First()["TotalVisibleMemorySize"]) / 1024 / 1024, 3);
    var freeMemory = Math.Round(Convert.ToDouble(memoryCollection.Cast<ManagementObject>().First()["FreePhysicalMemory"]) / 1024 / 1024, 3);
    var usedMemory = Math.Round((totalMemory - freeMemory), 3);
    var memoryUsage = Math.Round(((usedMemory / totalMemory) * 100), 3);

    // Output the memory usage information
    Console.WriteLine($"Memory usage on {server} : Used: {usedMemory} GB, Free: {freeMemory} GB, Total: {totalMemory} GB, Usage: {memoryUsage}%");
}
catch (Exception ex)
{
    // Throw an error if there was an issue with getting memory usage information
    throw new Exception($"Error: Unable to retrieve memory usage information from {server}. Exception message: {ex.Message}");
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

try
{
    // Get drive size and free space for the C drive on the server
    var driveQuery = new ObjectQuery("SELECT * FROM CIM_LogicalDisk WHERE DeviceID='C:'");
    var driveSearcher = new ManagementObjectSearcher(scope, driveQuery);
    var driveCollection = driveSearcher.Get();
    foreach (var drive in driveCollection)
    {
        var totalDrive = Math.Round(Convert.ToDouble(drive["Size"]) / 1073741824, 3);
        var freeDrive = Math.Round(Convert.ToDouble(drive["FreeSpace"]) / 1073741824, 3);
        var usedDrive = Math.Round((totalDrive - freeDrive), 3);
        var driveUsage = Math.Round(((usedDrive / totalDrive) * 100), 3);

        // Output the C drive usage information
        Console.WriteLine($"C drive occupancy on {server} : Used: {usedDrive} GB, Free: {freeDrive} GB, Total: {totalDrive} GB, Usage: {driveUsage}%");
    }
}
catch (Exception ex)
{
    // Throw an error if there was an issue with getting C drive usage information
    throw new Exception($"Error: Unable to retrieve C drive usage information from {server}. Exception message: {ex.Message}");
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

try
{
    // Get instant CPU usage for the server
    var cpuQuery = new ObjectQuery("SELECT LoadPercentage FROM CIM_Processor");
    var cpuSearcher = new ManagementObjectSearcher(scope, cpuQuery);
    var cpuCollection = cpuSearcher.Get();
    var cpuUsage = Math.Round((double)cpuCollection.Cast<ManagementObject>().Average(cpu => Convert.ToDouble(cpu["LoadPercentage"])), 3);

    // Output the instant CPU usage information
    Console.WriteLine($"Instant CPU usage on {server} : {cpuUsage}%");
}
catch (Exception ex)
{
    // Throw an error if there was an issue with getting instant CPU usage information
    throw new Exception($"Error: Unable to retrieve instant CPU usage information from {server}. Exception message: {ex.Message}");
}
