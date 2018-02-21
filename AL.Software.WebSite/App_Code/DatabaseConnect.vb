Imports System.Data.SQLite

Public Class DatabaseConnect
    Public RecordDB As String = ""
    Public CountRecords As Integer
    Dim Database As SQLiteConnection
    Dim Command As New SQLiteCommand

    Public Sub DatabaseOpen()
        Try
            Database = New SQLiteConnection("Data Source=" + Config.AppPath + "\Database.db; Version=3;")
            Database.Open()
        Catch ex As Exception
            RecordDB = ex.ToString
        End Try
    End Sub

    Public Sub UpdateDB()
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "UPDATE " + Config.TableCategory + " SET Viewed='10' WHERE Name LIKE 'MyProjects'"
            Command.ExecuteNonQuery()
            RecordDB = "Ok"
        Catch ex As Exception
            RecordDB = ex.ToString
        End Try
    End Sub

    Public Function GetCountItem(NameTable As String) As Integer
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

    Public Function GetCategoryProperty(CatName As String, CatProperty As String) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + Config.TableCategory + " WHERE Name LIKE '" + CatName + "'"
            Dim ReadItem = Command.ExecuteReader()
            While ReadItem.Read()
                Return ReadItem.Item(CatProperty).ToString
            End While
        Catch ex As Exception
            Return ex.ToString
        End Try
        Return ""
    End Function

    Public Function GetDatabaseItem(NameTable As String, ID As Integer, ItemProperty As String) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + NameTable + " WHERE ID=" + ID.ToString
            Dim ReadItem = Command.ExecuteReader()
            While ReadItem.Read()
                Return ReadItem.Item(ItemProperty).ToString
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

