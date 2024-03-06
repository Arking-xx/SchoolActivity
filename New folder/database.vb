
Imports System.Data.SqlClient
Imports System.Data

Public Class database
    Dim sqlquery As String = "Select * from Table_BookInformation"
    Dim sqlCon As SqlConnection = New SqlConnection("Data Source = cslab2-05; Initial Catalog = DB_LibraryMIS;Integrated Security = True")
    Dim sqlCom As SqlCommand = New SqlCommand(sqlquery, sqlCon)
    Dim sqlAdapter As New SqlDataAdapter()
    Dim dataTable As New DataTable
    Dim c_Columname As String
    Dim C_values As String

    Public Function getdata(ByVal grid As String) As DataTable

        dataTable = New DataTable

        sqlCon.Open()

        sqlAdapter = New SqlDataAdapter("Select * from " & grid, sqlCon)
        sqlAdapter.SelectCommand.ExecuteNonQuery()
        sqlAdapter.Fill(dataTable)
        sqlCon.Close()

        Return dataTable
    End Function

    Public Sub addRecord(ByVal database As String)

        sqlCon.Open()
        sqlCom = New SqlCommand("Insert into" & database & "(" & c_Columname & ") values (" & C_values & ")", sqlCon)
        sqlCom.ExecuteNonQuery()
        sqlCon.Close()

    End Sub

    Public Sub setColumn(ByVal columnName As String)

        If c_Columname = String.Empty Then
            c_Columname = columnName
        Else
            c_Columname = c_Columname & ", " & columnName
        End If
    End Sub

    Public Sub setValues(ByVal val As String)
        If C_values = String.Empty Then
            C_values = "'" & val & "'"
        Else
            C_values = C_values & ",'" & val & "'"
        End If
    End Sub

End Class
