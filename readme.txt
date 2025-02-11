Unified Automation UA .NET SDK Bundle 4.1.0 (BINARY  Edition)
---------------------------------------------------------

----------------------
Content
----------------------
(0) Compiler version
(1) Release notes
(2) Known issues
----------------------

===================================================================
(0) Compiler version
===================================================================

The OPC UA .NET SDK is built with Microsoft(TM) Visual Studio 2022
and depends on the Microsoft(TM) .NET framework 4.6.2, 4.8,
.NET Standard 2.0, .NET 6 and .NET8. This means that any machine
that it is deployed on must have the matching version of the .NET 
framework  or .NET version installed. 

The OPC UA SDK .NET assemblies can also be used in later versions but
a dependency to .NET framework 4.6.2, 4.8, .NET Core, NET 6 or NET8
must be added to your project.

The example solutions delivered with the SDK are based on Microsoft(TM)
Visual Studio 2022. It is probably possible to open the examples with
later versions of Visual Studio and to automatically convert them
to the new version.

It is possible to build and deploy applications with a later framework 
that also use the OPC UA .NET SDK, however, those applications will 
require that all used frameworks are installed on the machines where
the software is used.


===================================================================
(1) Release notes
===================================================================

------------------------------------------------------------------
(1a) Package UnifiedAutomation.UaBase
------------------------------------------------------------------
This package contains all code common for OPC UA server and client
development.

------------------------------------------------------------------
(1b) Package UnifiedAutomation.UaBase.Windows
------------------------------------------------------------------
This package contains additional code for certificate handling and
application helper functionality based on .NET Framework, NET 6
and NET8 on Windows.

------------------------------------------------------------------
(1c) Package UnifiedAutomation.UaBase.BounyCastle
------------------------------------------------------------------
This package contains additional code for certificate handling and
application helper functionality based on BouncyCastle library.

------------------------------------------------------------------
(1d) Package UnifiedAutomation.UaBase.Json
------------------------------------------------------------------
This package provides support for the UA JSON encoding - mainly
used by the JSON-based PubSub mapping.

------------------------------------------------------------------
(1e) Package UnifiedAutomation.UaClient
------------------------------------------------------------------
This package contains the functionality necessary to simplify the 
OPC UA client development. This package is released.

------------------------------------------------------------------
(1f) Package UnifiedAutomation.UaServer
------------------------------------------------------------------
This package contains the functionality necessary to simplify the
OPC UA server development. This package is released.

------------------------------------------------------------------
(1g) Package UnifiedAutomation.UaPubSub
------------------------------------------------------------------
This package contains the functionality necessary for
OPC UA pub-sub development.

------------------------------------------------------------------
(1h) Package UnifiedAutomation.UaPubSub.Mqtt
------------------------------------------------------------------
This package contains support for the MQTT and JSON pub-sub
mappings.

------------------------------------------------------------------
(1i) Package UnifiedAutomation.UaClient.Controls
------------------------------------------------------------------
The controls in this package are only used internally for the
ClientGettingStarted example application. It is not released for use in 
client applications.
This package
- is not documented
- is not released
- has no source code provided
- will change in future releases
Future releases will contain enhanced, reviewed and documented
controls for use in client applications. These controls will be 
marked as released in these future releases

------------------------------------------------------------------
(1j) Sample applications
------------------------------------------------------------------

BasicClient.exe
This first example provides initial sample code in a single source 
file for a simple data access client including connection establishment, 
read, write and data monitoring. This example is a good starting point 
to get familiar with the basic functionality of OPC UA.

ClientGettingStarted.exe
The Getting Started application provides a rich set of sample code for 
the different services and features of OPC UA. The examples are designed 
in a way that they provide self-contained sample code for the different 
OPC UA services with the following features:
 - Fully functional dialogs to execute single OPC UA services
 - Self-contained sample code that can be copied from the sample 
   code dialogs. Source code can be opened directly from the dialogs
 - Detailed documentation for the sample code. Documentation can 
   be opened directly from the dialogs

FullClient.exe
The Full Client is an enhanced example showing several features 
of OPC UA in a generic user interface.

ConsoleClient.exe
The ConsoleClient is an enhanced example showing several features
of OPC UA without using a graphical user interface.

UaServerNET.exe
The .NET based demo server can be used to work with the client examples.

MachineDemoServer.exe
The MachineDemoServer is an example implementation of a server using
several UA Companion Specifications.

===================================================================
(2) Known issues
===================================================================

The packages are only tested on Windows operating systems and linux
debian 11. Using the sdk on other platforms may fail.

UWP is not tested.
There is no example for an UWP application shipped with the sdk.

The SDK does not work with Mono under Linux.

Some test case of the compliance test tool (CTT) of the OPC foundation
are failing.
