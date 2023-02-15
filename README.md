
# Server Resource Monitoring

This C# code is designed to monitor various system resources on a Windows server, such as memory usage, C drive usage, and CPU usage. The code utilizes the System.Management NuGet package to gather this information.




## Prerequisites

- System.Management NuGet package
## Usage

The program requires the user to specify the target server by modifying the server variable. The user can specify the server name or IP address as a string.

To run the code, execute the code in a C# environment such as Visual Studio or JetBrains Rider.

The program will output the following information for the specified server:

- Memory usage (used, free, total, and percentage usage)
- C drive usage (used, free, total, and percentage usage)
- Instant CPU usage
## Example Output

```cs
Memory usage on example-server : Used: 6.686 GB, Free: 6.704 GB, Total: 13.391 GB, Usage: 49.898%
C drive occupancy on example-server : Used: 39.148 GB, Free: 147.858 GB, Total: 186.006 GB, Usage: 21.042%
Instant CPU usage on example-server : 2.703%
```
## Troubleshooting

If the program encounters an error, it will throw an exception with an error message that includes details of the issue encountered. Possible errors include issues with connecting to the specified server or issues with gathering resource usage information.

To troubleshoot the code, try the following:

- Ensure that the target server is online and accessible from the machine running the code.
- Ensure that the specified server name or IP address is correct.
- Check that the necessary packages and dependencies have been installed.
## Conclusion

This C# code provides a simple and easy-to-use way to monitor various system resources on a Windows server. With its customizable server input and clear output information, it is a useful tool for system administrators and developers alike.
## License

[MIT](https://github.com/seymenbahtiyar/Server_Resource_Monitoring/blob/main/LICENSE)

  
