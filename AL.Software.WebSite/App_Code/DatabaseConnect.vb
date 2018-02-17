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

    Public Function GetCategoryValue(CategoryName As String, Type As Integer) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + Config.TableCategory + " WHERE CatName LIKE '" + CategoryName + "'"
            Dim ReadItem = Command.ExecuteReader()
            While ReadItem.Read()
                If Type = 1 Then Return ReadItem.Item("CatCaption").ToString
                If Type = 2 Then Return ReadItem.Item("IsTileGrid").ToString
            End While
        Catch ex As Exception
            Return ex.ToString
        End Try
        Return ""
    End Function

    Public Function GetMenuItem(Type As Integer, NumberRow As Integer) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + Config.TableCategory + " WHERE ID=" + NumberRow.ToString
            Dim ReadItem = Command.ExecuteReader()
            While ReadItem.Read()
                If Type = 1 Then Return ReadItem.Item("CatCaption").ToString
                If Type = 2 Then Return ReadItem.Item("CatName").ToString
            End While
        Catch ex As Exception
            Return ex.ToString
        End Try
        Return ""
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

    Public Function GetDescriptionPage(NameTable As String, Category As String) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + NameTable + " WHERE CatName LIKE '" + Category + "'"
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

