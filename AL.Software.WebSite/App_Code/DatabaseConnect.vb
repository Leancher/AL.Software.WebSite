Imports System.Data.SQLite

Public Class DatabaseConnect
    Public RecordDB As String = ""
    Public CountRecords As Integer
    Dim Database As SQLiteConnection
    Dim Command As New SQLiteCommand

    Public Sub DatabaseOpen()
        Try
            Database = New SQLiteConnection("Data Source=" + Config.AppPath + "\Database\Database.db; Version=3;")
            Database.Open()
        Catch ex As Exception
            RecordDB = ex.ToString
        End Try
    End Sub

    Private Function GetNameTable(NumberTable As Integer) As String
        If NumberTable = 1 Then Return "TableMyProjects"
        If NumberTable = 2 Then Return "ListCategory"
        If NumberTable = 3 Then Return "PhotoAlbum"
        Return ""
    End Function

    Public Function GetCountRow(NameTable As String) As Integer
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT Count (*) From " + NameTable
            Dim ReadItem = Command.ExecuteReader()
            ReadItem.Read()
            Return CInt(ReadItem(0))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRecordDB(NameTable As String, NumberRow As Integer, NumberColumn As Integer) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + NameTable + " WHERE ID=" + NumberRow.ToString
            Dim ReadItem = Command.ExecuteReader()
            While ReadItem.Read()
                Return ReadItem.GetValue(NumberColumn)
            End While
        Catch ex As Exception
            Return ex.ToString
        End Try
        Return ""
    End Function

    Public Function GetDescriptionPage(NameTable As String, NumberRow As Integer) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + NameTable + " WHERE ID=" + NumberRow.ToString
            Dim ReadItem = Command.ExecuteReader()
            While ReadItem.Read()
                Return ReadItem.Item("Description").ToString
            End While
        Catch ex As Exception
            Return ex.ToString
        End Try
        Return ""
    End Function

    Public Sub DatabaseClose()
        Database.Dispose()
    End Sub
End Class

