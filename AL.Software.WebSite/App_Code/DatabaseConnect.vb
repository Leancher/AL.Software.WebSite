Imports System.Data.SQLite

Public Class DatabaseConnect
    Public Item As String = ""
    Public CountRecords As Integer
    Dim Database As SQLiteConnection
    Dim Command As New SQLiteCommand
    Dim ReadItem As SQLiteDataReader

    Public Sub DatabaseOpen()
        Try
            Database = New SQLiteConnection("Data Source=" + Config.AppPath + "\Database.db; Version=3;")
            Database.Open()
        Catch ex As Exception
            Item = ex.ToString
        End Try
    End Sub

    Public Sub UpdateViewed(NameTable As String, ItemID As Integer)
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "UPDATE " + Config.TableCategory + " SET Viewed='10' WHERE Name LIKE 'MyProjects'"
            Command.ExecuteNonQuery()
            Item = "Ok"
        Catch ex As Exception
            Item = ex.ToString
        End Try
    End Sub

    Public Function GetCountItem(NameTable As String) As Integer
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT Count (*) From " + NameTable
            ReadItem = Command.ExecuteReader()
            ReadItem.Read()
            Item = ReadItem(0)
            ReadItem.Close()
            Return CInt(Item)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetCategoryProperty(CatName As String, CatProperty As String) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + Config.TableCategory + " WHERE Name LIKE '" + CatName + "'"
            ReadItem = Command.ExecuteReader()
            While ReadItem.Read()
                Item = ReadItem.Item(CatProperty).ToString
                ReadItem.Close()
                Return Item
            End While
        Catch ex As Exception
            Return ex.ToString
        End Try
        Return ""
    End Function

    Public Function GetDatabaseItem(NameTable As String, ItemID As Integer, ItemProperty As String) As String
        Try
            Command = Database.CreateCommand()
            Command.CommandText = "SELECT * FROM " + NameTable + " WHERE ID=" + ItemID.ToString
            ReadItem = Command.ExecuteReader()
            While ReadItem.Read()
                Item = ReadItem.Item(ItemProperty).ToString
                ReadItem.Close()
                Return Item
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

