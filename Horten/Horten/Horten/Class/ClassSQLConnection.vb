Imports System.Net
Imports System.Net.Sockets
Imports System.Net.Dns
Public Class ClassSqlConnection
    Public conSQL As SqlClient.SqlConnection
    Public Function sqlConnectPrisma()
        Dim sHostName As String = Dns.GetHostName()
        Dim ipE As IPHostEntry = Dns.GetHostByName(sHostName)
        Dim IpA As IPAddress() = ipE.AddressList
        Dim str As String = ""
        str = IpA(0).ToString()

        conSQL = New SqlClient.SqlConnection()
        If str.Length > 8 Then
            If str.Substring(0, 9) = "192.168.1" Then
                conSQL.ConnectionString = "Integrated Security=False; Data Source=192.168.1.1; User ID=sa; Pwd=classica98!; Initial Catalog=PrismaAcesso;"
            Else
                Try
                    conSQL.ConnectionString = "Integrated Security=False; Data Source=192.168.0.1; User ID=sa; Pwd=alado69*; Initial Catalog=PrismaAcesso;"
                Catch
                    conSQL.ConnectionString = "Integrated Security=False; Data Source=192.168.1.1; User ID=sa; Pwd=classica98!; Initial Catalog=PrismaAcesso;"
                End Try
            End If
        Else
            '#Pela VPN
            conSQL.ConnectionString = "Integrated Security=False; Data Source=192.168.1.1; User ID=sa; Pwd=classica98!; Initial Catalog=PrismaAcesso;"
        End If
        Return conSQL
    End Function

    Public Sub sqlDisconnect()
        conSQL.Close()
    End Sub

    Public Function sqlConnect(ByVal sDataSource As String, ByVal sUserID As String, ByVal sPWD As String, ByVal sInitialCatalog As String)
        conSQL = New SqlClient.SqlConnection()
        conSQL.ConnectionString = "Integrated Security=False; Data Source=" & sDataSource & "; User ID=" & sUserID & "; Pwd=" & sPWD & "; Initial Catalog=" & sInitialCatalog & ";"
        Return conSQL
    End Function

    Public Function sqlConnectLegado(ByVal sDataSourceLegado As String, ByVal sUserIDLegado As String, ByVal sPWDLegado As String, ByVal sInitialCatalogLegado As String)
        conSQL = New SqlClient.SqlConnection()
        conSQL.ConnectionString = "Integrated Security=False; Data Source=" & sDataSourceLegado & "; User ID=" & sUserIDLegado & "; Pwd=" & sPWDLegado & "; Initial Catalog=" & sInitialCatalogLegado & ";"
        Return conSQL
    End Function
End Class
