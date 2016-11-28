﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34014
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34014.
'
Namespace NAVApp
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="NAVAppServer_Binding", [Namespace]:="urn:microsoft-dynamics-schemas/codeunit/NAVAppServer")>  _
    Partial Public Class NAVAppServer
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private ExecuteCodeunitOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://skyrr-sql-kro-1:7047/DynamicsNAVKappi/WS/S%C3%A9rkerfapr%C3%B3fun%20G%C3%9"& _ 
                "EG/Codeunit/NAVAppServer"
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event ExecuteCodeunitCompleted As ExecuteCodeunitCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/NAVAppServer:ExecuteCodeunit", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/NAVAppServer", ResponseElementName:="ExecuteCodeunit_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/NAVAppServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ExecuteCodeunit(ByVal codeunitID As Integer, ByVal log As Boolean) As <System.Xml.Serialization.XmlElementAttribute("return_value")> Boolean
            Dim results() As Object = Me.Invoke("ExecuteCodeunit", New Object() {codeunitID, log})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ExecuteCodeunitAsync(ByVal codeunitID As Integer, ByVal log As Boolean)
            Me.ExecuteCodeunitAsync(codeunitID, log, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ExecuteCodeunitAsync(ByVal codeunitID As Integer, ByVal log As Boolean, ByVal userState As Object)
            If (Me.ExecuteCodeunitOperationCompleted Is Nothing) Then
                Me.ExecuteCodeunitOperationCompleted = AddressOf Me.OnExecuteCodeunitOperationCompleted
            End If
            Me.InvokeAsync("ExecuteCodeunit", New Object() {codeunitID, log}, Me.ExecuteCodeunitOperationCompleted, userState)
        End Sub
        
        Private Sub OnExecuteCodeunitOperationCompleted(ByVal arg As Object)
            If (Not (Me.ExecuteCodeunitCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ExecuteCodeunitCompleted(Me, New ExecuteCodeunitCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")>  _
    Public Delegate Sub ExecuteCodeunitCompletedEventHandler(ByVal sender As Object, ByVal e As ExecuteCodeunitCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ExecuteCodeunitCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
    End Class
End Namespace