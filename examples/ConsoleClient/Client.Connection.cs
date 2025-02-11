/******************************************************************************
** Copyright (c) 2006-2023 Unified Automation GmbH All rights reserved.
**
** Software License Agreement ("SLA") Version 2.8
**
** Unless explicitly acquired and licensed from Licensor under another
** license, the contents of this file are subject to the Software License
** Agreement ("SLA") Version 2.8, or subsequent versions
** as allowed by the SLA, and You may not copy or use this file in either
** source code or executable form, except in compliance with the terms and
** conditions of the SLA.
**
** All software distributed under the SLA is provided strictly on an
** "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
** AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
** LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
** PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the SLA for specific
** language governing rights and limitations under the SLA.
**
** Project: .NET based OPC UA Client Server SDK
**
** Description: OPC Unified Architecture Software Development Kit.
**
** The complete license agreement can be found here:
** http://unifiedautomation.com/License/SLA/2.8/
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace ConsoleClient
{
    partial class Client
    {
        #region Simple Connect
        ClientState SimpleConnect()
        {
            return SimpleConnect(false);
        }

        ClientState SimpleConnectWithSecurity()
        {
            return SimpleConnect(true);
        }

        ClientState SimpleConnect(bool security)
        {
            try
            {
                //! [Simple Connect]
                Session.Connect(Settings.Connection.DiscoveryUrl, security ? SecuritySelection.BestAvailable : SecuritySelection.None);
                //! [Simple Connect]
                Output($"\nSuccessfully connected to {Settings.Connection.DiscoveryUrl}");
                Output($"    RevisedSessionTimeout: {Session.RevicedSessionTimeout}");
                try
                {
                    //! [Access Namespaces]
                    Settings.CurrentNamespaceTable = Session.NamespaceUris;
                    //! [Access Namespaces]
                }
                catch (Exception e)
                {
                    Output($"Mapping of nodes failed. Check the configuration. {e.Message}");
                }
                return ClientState.Connected;
            }
            catch (Exception e)
            {
                LogException(e, $"\nConnecting to {Settings.Connection.DiscoveryUrl} failed");
            }
            return ClientState.Disconnected;
        }
        #endregion

        #region Advanced Connect
        ClientState ConnectToEndpoint()
        {
            try
            {
                //! [Connect Endpoint]
                Session.Connect(SelectedEndpoint, ValidateEndpoints, Endpoints, null);
                //! [Connect Endpoint]
                Output($"\nSuccessfully connected to {SelectedEndpoint.EndpointUrl}");
                Output($"    RevisedSessionTimeout: {Session.RevicedSessionTimeout}");
                try
                {
                    Settings.CurrentNamespaceTable = Session.NamespaceUris;
                }
                catch (Exception e)
                {
                    Output($"Mapping of nodes failed. Check the configuration. {e.Message}");
                }
                return ClientState.Connected;
            }
            catch (Exception e)
            {
                LogException(e, $"\nConnecting to {Settings.Connection.DiscoveryUrl} failed");
            }
            return ClientState.Disconnected;
        }

        //! [Connect Endpoint Validate]
        bool ValidateEndpoints(EndpointDescriptionCollection endpointsFromCreateSession, IList<EndpointDescription> endpointsFromGetEndpoints)
        {
            return endpointsFromCreateSession.IsEquivalentTo(endpointsFromGetEndpoints);
        }
        //! [Connect Endpoint Validate]
        #endregion

        #region Disconnect
        ClientState Disconnect()
        {
            try
            {
                Session.Disconnect();
                Output("\nDisconnect.");
                return ClientState.Disconnected;
            }
            catch (Exception e)
            {
                Output($"\nDisconnect failed with message {e.Message}");
                return State;
            }
        }
        #endregion

        #region User Identity
        ClientState SetUsername()
        {
            //! [Set UserName]
            if (Session.UserIdentity == null)
            {
                Session.UserIdentity = new UserIdentity();
            }
            Session.UserIdentity.IdentityType = UserIdentityType.UserName;
            Session.UserIdentity.UserName = Settings.Connection.UserName;
            Session.UserIdentity.Password = Settings.Connection.Password;
            //! [Set UserName]

            return ClientState.Disconnected;
        }

        ClientState SetUserToAnonymous()
        {
            if (Session.UserIdentity == null)
            {
                Session.UserIdentity = new UserIdentity();
            }

            Session.UserIdentity.IdentityType = UserIdentityType.Anonymous;
            return ClientState.Disconnected;
        }
        #endregion

        #region Change User
        ClientState ChangeUser()
        {
            try
            {
                if (Session.UserIdentity == null)
                {
                    Session.UserIdentity = new UserIdentity();
                }

                if (Session.UserIdentity.IdentityType == UserIdentityType.Anonymous)
                {
                    //! [change User]
                    Session.UserIdentity.IdentityType = UserIdentityType.UserName;
                    Session.UserIdentity.UserName = Settings.Connection.UserName;
                    Session.UserIdentity.Password = Settings.Connection.Password;
                    //! [change User]
                }
                else
                {
                    Session.UserIdentity.IdentityType = UserIdentityType.Anonymous;
                 }
                //! [apply changed User]
                Session.ChangeUser();
                //! [apply changed User]
                Output("\nChangeUser succeeded.");
            }
            catch(Exception e)
            {
                Output($"\nChangeUser failed with message: {e.Message}");
            }
            return ClientState.Connected;
        }
        #endregion

        #region Change Password
        ClientState ChangePassword()
        {
            try
            {
                if (Session.UserIdentity == null || Session.UserIdentity.IdentityType != UserIdentityType.UserName)
                {
                    Output($"\nChange Password not supported for {Session.UserIdentity.IdentityType}.");
                    return ClientState.Connected;
                }

                Console.WriteLine("\nEnter current password:");
                var oldPassword = GetPasswordInput();

                Console.WriteLine("\nEnter new password:");
                var newPassword = GetPasswordInput();

                //! [change User password]
                Session.ChangePassword(oldPassword, newPassword);
                //! [change User password]
                Settings.Connection.Password = newPassword;

                Output("\nChangePassword succeeded.");
            }
            catch (Exception e)
            {
                Output($"\nChangePassword failed with message: {e.Message}");
            }
            return ClientState.Connected;
        }

        private static string GetPasswordInput()
        {
            ConsoleKeyInfo keyInput;
            string password = "";
            do
            {
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Backspace)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b");
                }
                else if (keyInput.Key != ConsoleKey.Enter)
                {
                    password += keyInput.KeyChar;
                    Console.Write("*");
                }
            } while (keyInput.Key != ConsoleKey.Enter);
            return password;
        }
        #endregion

        #region KeyCredentials
        ClientState ListCredentials()
        {
            try
            {
                var credentials = GetKeyCredentials(Session);

                if (credentials.Length != 0)
                {
                    Output($"\nFound {credentials.Length} KeyCredentials:");
                    foreach (var credential in credentials)
                    {
                        lock (ConsoleLock)
                        {
                            Console.WriteLine($"  {credential.BrowseName}");
                            Console.WriteLine($"      ResourceUri: {credential.ResourceUri}");
                            Console.WriteLine($"      ProfileUri:  {credential.ProfileUri}");
                        }
                    }
                }
                else
                {
                    Output("\nNo key credentials could be found.");
                }
            }
            catch (Exception e)
            {
                Output($"\nListCredentials failed with message: {e.Message}");
            }
            return ClientState.Connected;
        }

        ClientState CreateCredential()
        {
            try
            {
                Console.WriteLine("\nPlease, insert the name for the key credential.");
                string name = Console.ReadLine();

                Console.WriteLine($"\nPlease, insert the resource uri for the key credential. (Default: 'urn:{name}')");
                string resourceUri = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(resourceUri))
                {
                    resourceUri = $"urn:{name}";
                }

                Console.WriteLine($"\nPlease, insert the profile uri for the key credential. (Default: '{AuthenticationProfiles.MqttUserName}')");
                string profileUri = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(profileUri))
                {
                    profileUri = AuthenticationProfiles.MqttUserName;
                }

                // Create credential
                var status = Session.Call(ObjectIds.KeyCredentialConfiguration, MethodIds.KeyCredentialConfigurationFolderType_CreateCredential, new List<Variant>()
                {
                    name,
                    resourceUri,
                    profileUri,
                    new string[] { }
                }, out var inputArgumentErrors, out var outputArguments);

                if (status.IsBad())
                {
                    throw new StatusException(status);
                }

                var nodeId = outputArguments[0].ToNodeId();

                Console.WriteLine("\nPlease, insert the CredentialId (user name).");
                string userName = Console.ReadLine();

                // GetEncryptingKey
                status = Session.Call(nodeId, MethodIds.KeyCredentialConfigurationType_GetEncryptingKey, new List<Variant>()
                {
                    userName,
                    default(string)
                }, out inputArgumentErrors, out outputArguments);

                var publicKey = outputArguments[0].ToByteString();
                var revisedSecurityPolicyUri = outputArguments[1].ToString();

                // Create encrypted secret
                Console.WriteLine("\nPlease, insert the secret (password).");
                string password = GetPasswordInput();

                ICertificate certificate = new Certificate(publicKey);
                var secret = new EncryptedSecret()
                {
                    Secret = Encoding.UTF8.GetBytes(password),
                    SecurityPolicyUri = revisedSecurityPolicyUri
                };

                var credentialSecret = secret.Encrypt(Application.SecurityProvider, certificate);

                status = Session.Call(nodeId, MethodIds.KeyCredentialConfigurationType_UpdateCredential, new List<Variant>()
                {
                    userName,
                    credentialSecret,
                    certificate.Thumbprint,
                    revisedSecurityPolicyUri
                }, out var _, out var _);

                if (status.IsBad())
                {
                    throw new StatusException(status);
                }

            }
            catch (Exception e)
            {
                Output($"\nCreateCredential failed with message: {e.Message}");
            }

            return ClientState.Connected;
        }

        ClientState DeleteCredential()
        {
            try
            {
                Console.WriteLine("\nPlease, insert the name of the key credential.");
                string name = Console.ReadLine();

                var browseResult = Session.BrowseList(new List<BrowseDescription>()
                {
                    new BrowseDescription()
                    {
                        NodeId = ObjectIds.KeyCredentialConfiguration,
                        ReferenceTypeId = ReferenceTypeIds.HasComponent,
                        NodeClassMask = (uint)NodeClass.Object,
                        ResultMask = (uint)(BrowseResultMask.BrowseName | BrowseResultMask.TypeDefinition),
                    }
                });

                var credentialToRemove = browseResult[0]
                    .Where(r => r.TypeDefinition == ObjectTypeIds.KeyCredentialConfigurationType)
                    .Where(r => r.BrowseName.Name == name)
                    .Select(r => r.NodeId.ToNodeId(Session.NamespaceUris))
                    .FirstOrDefault();

                if (credentialToRemove != null)
                {
                    Session.Call(credentialToRemove, MethodIds.KeyCredentialConfigurationType_DeleteCredential);
                }
                else
                {
                    Output("Nothing to be removed.");
                }

            }
            catch (Exception e)
            {
                Output($"\nCreateCredential failed with message: {e.Message}");
            }

            return ClientState.Connected;
        }

        [UaTypeDefinition(NodeId = ObjectTypes.KeyCredentialConfigurationType)]
        public class KeyCredentialObject
        {
            public NodeId NodeId { get; set; }

            public QualifiedName BrowseName { get; set; }

            [UaInstanceDeclaration(NamespaceUri = Namespaces.OpcUa)]
            public string ResourceUri { get; set; }

            [UaInstanceDeclaration(NamespaceUri = Namespaces.OpcUa)]
            public string ProfileUri { get; set; }

            [UaInstanceDeclaration(NamespaceUri = Namespaces.OpcUa)]
            public string[] EndpointUrls { get; set; }
        }

        private static KeyCredentialObject[] GetKeyCredentials(Session session)
        {
            var namespaceUris = session.NamespaceUris;

            var browseResult = session.BrowseList(new List<BrowseDescription>()
            {
                new BrowseDescription()
                {
                    NodeId = ObjectIds.KeyCredentialConfiguration,
                    ReferenceTypeId = ReferenceTypeIds.HasComponent,
                    NodeClassMask = (uint)NodeClass.Object,
                    ResultMask = (uint)(BrowseResultMask.BrowseName | BrowseResultMask.TypeDefinition),
                }
            });

            var credentials = browseResult[0]
                .Where(r => r.TypeDefinition == ObjectTypeIds.KeyCredentialConfigurationType)
                .Select(r => new KeyCredentialObject()
                {
                    NodeId = r.NodeId.ToNodeId(namespaceUris),
                    BrowseName = r.BrowseName,
                })
                .ToArray();

            foreach (var credential in credentials)
            {
                session.Model.Read(credential.NodeId, credential);
            }

            return credentials;
        }
        #endregion

        #region EventHandler
        void OnConnectionStatusUpdate(Session sender, ServerConnectionStatusUpdateEventArgs e)
        {
            Output($"\n{DateTime.Now}: ConnectionStatusUpdate: {e.PreviousStatus} -> {e.Status}");
            if (e.Status == ServerConnectionStatus.SessionAutomaticallyRecreated)
            {
                // Node are not re-registered when a session is recreated.
                RegisteredNodes = null;
            }
        }

        void OnPasswordChangeRequired(Session sender, EventArgs e)
        {
            Output($"\nPassword change required to get full user permissions!");
        }
        #endregion

#if !REVERSE_CONNECT_UNSUPPORTED
        #region Simple Reverse Connect
        ClientState SimpleReverseConnect()
        {
            try
            {
                if (String.IsNullOrEmpty(Settings.Connection.ClientUrlForReverseConnect))
                {
                    Output("ReverseConnect not possible because ClientUrlForReverseConnect is not set.");
                    return ClientState.Disconnected;
                }

                //! [Simple Reverse Connect]
                Session.ReverseConnect(Settings.Connection.DiscoveryUrl, SecuritySelection.None);
                //! [Simple Reverse Connect]
                Output($"\nSuccessfully connected to {Settings.Connection.DiscoveryUrl}");
                Output($"    RevicedSessionTimeout: {Session.RevicedSessionTimeout}");
                try
                {
                    Settings.CurrentNamespaceTable = Session.NamespaceUris;
                }
                catch (Exception e)
                {
                    Output($"Mapping of nodes failed. Check the configuration. {e.Message}");
                }
                return ClientState.Connected;
            }
            catch (Exception e)
            {
                LogException(e, $"\nConnecting to {Settings.Connection.DiscoveryUrl} failed");
            }
            return ClientState.Disconnected;
        }
        #endregion
#endif
    }
}
