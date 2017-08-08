# IIS Manager Troubleshooting



### Error message
```
An exception of type 'System.UnauthorizedAccessException' occurred in Microsoft.Web.Administration.dll but was not handled in user code

Additional information: Filename: redirection.config

Error: Cannot read configuration file due to insufficient permissions
```

### Solution
* Make sure your running the as an administrator. 
* Running the test from within Visual Studio Test Explorer will not work



### Error message
```
Unable to cast COM object of type 'System.__ComObject' to interface type 'Microsoft.Web.Administration.Interop.IAppHostWritableAdminManager'. 
```

### Solution
* Make sure you have IIS installed on the machine you are running the script from.



### Error message
```
Error: The configuration section 'webFarms' cannot be read because it is missing a section declaration
```

### Solution
* Install WebFarm Framework
http://www.microsoft.com/en-us/download/details
```
Microsoft.Web.Administration.ServerManagerException : Application pools cannot be started unless the Windows Activation Service (WAS) is running.
```

### Solution
* Check IIS is installed on the machine your trying to manage



### Error message
```
Retrieving the COM class factory for remote component with CLSID {2B72133B-3F5B-4602-8952-803546CE3344} from machine failed due to the following error: 800706ba
```

### Solution
* Windows Firewall is blocking DCOM access.  Adjust your firewall to allow DCOM port mapper (RpcSs service) on TCP port 135 & allow DCOM to access IIS configuration COM objects (windows\system32\dllhost.exe).

Firewall rule for DCOM port mapper (command line)

netsh advfirewall firewall add rule name="AllowDCOMPortMapperForIISConfiguration" dir=in action=allow profile=domain protocol=tcp localport=135 service=RpcSs

Things to consider:  
Add remoteip restrictions based on your network.  For example, to lock down to a static ip, you would add remoteip=198.168.10.25  

remoteip can be based on a subnet as well.

Firewall rule for DCOM access to IIS configuration COM objects (command line)

netsh advfirewall firewall add rule name="AHADMINAccessForIISConfiguration" dir=in action=allow profile=domain protocol=tcp program=%windir%\system32\dllhost.exe

Things to consider:  
Adding remoteip restrictions to the firewall rule and restricting the AHADMIN to a specific port

See http://mvolo.com/connecting-to-iis-70-configuration-remotely-with-microsoftwebadministration/ for more information and explanation.

* Last option - Disable windows firewall
