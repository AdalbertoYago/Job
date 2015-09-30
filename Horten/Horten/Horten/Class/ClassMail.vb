Imports System.Net.Mail
Public Class ClassMail
    Public sError As String
    Public Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal bcc As String, ByVal cc As String, ByVal subject As String, ByVal body As String, ByVal sAttach As String, ByVal sAttach2 As String, ByVal gIDEmpresa As Integer, ByVal sUsuarioEmail As String, ByVal sPWEmail As String)
        ' Set the recepient address of the mail message
        recepient = Replace(recepient, ";", ",")
        If recepient.Substring(recepient.Length - 1, 1) = "," Then
            recepient = recepient.Substring(0, recepient.Length - 1)
        End If
        Dim sArr(20) As String
        Dim i As Integer = 0
        '###quebra email quando tem varios
        sArr = recepient.Split(",")

        For i = 0 To sArr.Length - 1
            Dim mMailMessage As New MailMessage()
            mMailMessage.From = New MailAddress(from.ToLower)
            mMailMessage.ReplyTo = New MailAddress(from.ToLower)

            mMailMessage.To.Add(New MailAddress(sArr(i)))
            If Not bcc Is Nothing And bcc <> String.Empty Then
                mMailMessage.Bcc.Add(New MailAddress(bcc))
            End If

            ' Check if the cc value is nothing or an empty value
            If Not cc Is Nothing And cc <> String.Empty Then
                ' Set the CC address of the mail message
                mMailMessage.CC.Add(New MailAddress(cc))
            End If
            mMailMessage.Subject = subject
            mMailMessage.Body = body
            mMailMessage.IsBodyHtml = True
            mMailMessage.Priority = MailPriority.Normal
            mMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
            mMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure

            If sAttach <> "" Then
                Try
                    mMailMessage.Attachments.Add(New Attachment(sAttach))
                Catch
                End Try
            End If
            If sAttach2 <> "" Then
                Try
                    mMailMessage.Attachments.Add(New Attachment(sAttach2))
                Catch
                End Try
            End If
            Dim mSmtpClient As New SmtpClient()
            Try
                If gIDEmpresa <> 1 And gIDEmpresa <> 2 Then
                    mSmtpClient.Host = "smtp.alado.com.br"
                    'mSmtpClient.UseDefaultCredentials = False
                    mSmtpClient.Credentials = New System.Net.NetworkCredential(sUsuarioEmail, sPWEmail)
                    'mSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
                    mSmtpClient.Port = 587
                    'mSmtpClient.EnableSsl = False
                    mSmtpClient.Send(mMailMessage)
                Else
                    mSmtpClient.Host = "mail.classica.com.br"
                    mSmtpClient.Credentials = New System.Net.NetworkCredential("alex@classica.com.br", "haunted")
                    'mSmtpClient.UseDefaultCredentials = False
                    mSmtpClient.Port = 587
                    'mSmtpClient.EnableSsl = True
                    mSmtpClient.Send(mMailMessage)

                End If
            Catch ex As Exception
                sError = ex.Message.ToString() & " - " & ex.InnerException.ToString() & " - " & ex.StackTrace.ToString()
            End Try
        Next
    End Sub
End Class


