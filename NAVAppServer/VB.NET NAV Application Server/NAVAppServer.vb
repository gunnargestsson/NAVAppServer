Imports System
Imports System.Timers
Imports System.Net

Public Class NAVAppServer
    Dim NAVApp1 As NAVApp.NAVAppServer
    Dim Timer1 As System.Timers.Timer
    Dim NAVServiceName As String = Me.ServiceName
    Dim LastSuccess As DateTime = Nothing
    Dim LastFailed As DateTime = Nothing


    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        NAVApp1 = New NAVApp.NAVAppServer
        NAVApp1.UseDefaultCredentials = True

        Timer1 = New System.Timers.Timer(1000)
        AddHandler Timer1.Elapsed, AddressOf OnTimedEvent

        Timer1.Interval = 1000
        Timer1.Enabled = True
        Timer1.Start()

        ' If the timer is declared in a long-running method, use
        ' KeepAlive to prevent garbage collection from occurring
        ' before the method ends.
        GC.KeepAlive(Timer1)
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Timer1.Stop()
        Timer1.Enabled = False
    End Sub

    Protected Sub OnTimedEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)
        Timer1.Enabled = False
        Timer1.Stop()
        If ExecuteCodeunit() Then
            Timer1.Interval = My.Settings.TimerInterval
        Else
            Timer1.Interval = My.Settings.RetryTimerInterval
        End If
        Timer1.Enabled = True
        Timer1.Start()
    End Sub
    Protected Function ExecuteCodeunit() As Boolean
        Try
            If NAVApp1.ExecuteCodeunit(My.Settings.CodeunitID, My.Settings.LogMode) Then
                LastSuccess = DateTime.Now
                LastFailed = Nothing
                Return True
            Else
                If LastFailed = Nothing Then
                    WriteToEventLog("Execution of codeunit " & My.Settings.CodeunitID.ToString & " failed", EventLogEntryType.Error)
                    LastFailed = DateTime.Now
                ElseIf DateTime.Now - LastFailed > My.Settings.LogFrequency Then
                    WriteToEventLog("Execution of codeunit " & My.Settings.CodeunitID.ToString & " failed", EventLogEntryType.Error)
                    LastFailed = DateTime.Now
                End If
                Return False
            End If
        Catch ex As Exception
            If LastFailed = Nothing Then
                WriteToEventLog("Execution of codeunit " & My.Settings.CodeunitID.ToString & " failed", EventLogEntryType.Error)
                SendEmail(ex.Message)
                LastFailed = DateTime.Now
            ElseIf DateTime.Now - LastFailed > My.Settings.LogFrequency Then
                WriteToEventLog("Execution of codeunit " & My.Settings.CodeunitID.ToString & " failed", EventLogEntryType.Error)
                SendEmail(ex.Message)
                LastFailed = DateTime.Now
            End If
            Return False
        End Try
    End Function
    Protected Sub WriteToEventLog(ByVal Message As String, ByVal EntryType As EventLogEntryType)
        Dim MyLog As New EventLog() ' create a new event log
        ' Check if the the Event Log Exists
        If Not Diagnostics.EventLog.SourceExists(Me.ServiceName) Then
            Diagnostics.EventLog.CreateEventSource(Me.ServiceName, Me.ServiceName & " Log")
            ' Create Log
        End If
        MyLog.Source = Me.ServiceName
        ' Write to the Log
        Diagnostics.EventLog.WriteEntry(MyLog.Source, Message, EntryType)        
    End Sub
    Protected Sub SendEmail(ByVal Message As String)
        If My.Settings.ToAddress = "" Then
            Return
        End If
        Try
            Dim Server As New Mail.SmtpClient
            Dim MailMessage As New Mail.MailMessage
            MailMessage.From = New Mail.MailAddress(My.Settings.FromAddress)
            MailMessage.To.Add(My.Settings.ToAddress)
            MailMessage.Subject = Me.ServiceName
            MailMessage.Body = Message
            Server.Host = My.Settings.SMTPHost
            Server.Send(MailMessage)
        Catch ex As Exception
            WriteToEventLog(ex.Message, EventLogEntryType.Error)
        End Try

    End Sub
End Class
